using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Windows.Threading;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Compile;
using SheepAspect.Core;
using SheepAspect.Pointcuts;
using SheepAspect.Pointcuts.Impl;
using SheepAspectQueryAnalyzer.ViewModel;
using System.Linq;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Helpers;

namespace SheepAspectQueryAnalyzer.Engine
{
    public class QueryRunner
    {
        private readonly QueryParseEngine _parser;
        private readonly PointcutQueryEngine _queryEngine;
        private readonly QueryResultVm _result;
        private readonly Dispatcher _treeDispatcher;

        public QueryRunner(QueryResultVm result, Dispatcher treeDispatcher)
        {
            _result = result;
            _treeDispatcher = treeDispatcher;
            _queryEngine = new PointcutQueryEngine();
            _parser = new QueryParseEngine();
        }

        public void Run(ICollection<string> assemblyFileNames, string queryText, ILogWriter logger)
        {
            _result.Clear();
            
            IDictionary<PointcutExpression, IPointcut> pointcuts;

            try
            {
                logger.Append("STARTED: parsing queries...");
                pointcuts = _parser.BuildPointcuts(queryText);
                logger.Append("COMPLETED: parsing queries. {0} pointcuts parsed.", pointcuts.Count);
            }
            catch(Exception e)
            {
                logger.Append("ERROR parsing query: '{0}'", e.Message);
                return;
            }

            var resolver = new DefaultAssemblyResolver();
            foreach(var dir in assemblyFileNames.Select(Path.GetDirectoryName))
                resolver.AddSearchDirectory(dir);
            var readerParams = new ReaderParameters {AssemblyResolver = resolver};

            var assemblies = assemblyFileNames.AsParallel().Select(filename =>
                        {
                            logger.Append("STARTED: reading assemblies '{0}'...", filename);
                            var asm = AssemblyDefinition.ReadAssembly(filename, readerParams);
                            var asmTypes =
                                new
                                    {
                                        Assembly = asm,
                                        Types = _queryEngine.GetTypes(asm).ToArray()
                                    };
                            logger.Append("COMPLETED: reading assemblies '{0}'.", filename);
                            return asmTypes;
                        }).ToDictionary(x=> x.Assembly, x=> x.Types);
            
            foreach(var pointcutKv in pointcuts)
            {
                var propertiesMap = new ConcurrentDictionary<PropertyDefinition, CodeTree.PropertyNode>();

                if (QueryPointcut<IInstructionPointcut, KeyValuePair<MethodDefinition, Instruction>>(logger, assemblies, pointcutKv,
                    (types, pointcut) => _queryEngine.QueryInstructions(types, pointcut),
                    instructions => 
                        instructions.GroupBy(x => x.Key, x => x.Value).GroupBy(x => x.Key.DeclaringType)
                            .Select(t => new CodeTree.TypeNode(t.Key, t.Select(
                                m => CreateNodeForMethod(propertiesMap, m.Key, m)))))
                    )
                    continue;

                if (QueryPointcut<IMethodPointcut, MethodDefinition>(logger, assemblies, pointcutKv,
                    (types, pointcut) => _queryEngine.QueryMethods(types, pointcut),
                    methods => 
                        methods.GroupBy(m => m.DeclaringType)
                            .Select(t => new CodeTree.TypeNode(t.Key, t.Select(
                                m => CreateNodeForMethod(propertiesMap, m)))))
                    )
                    continue;

                if (QueryPointcut<ITypePointcut, TypeDefinition>(logger, assemblies, pointcutKv,
                    (types, pointcut) => _queryEngine.QueryTypes(types, pointcut),
                    types => 
                        types.Select(t => new CodeTree.TypeNode(t, null)))
                    )
                    continue;
            }
        }

        private CodeTree CreateNodeForMethod(IDictionary<PropertyDefinition, CodeTree.PropertyNode> propertiesMap, MethodDefinition method, IEnumerable<Instruction> instructions=null)
        {
            var instrNodes = instructions == null ? null : instructions.Select(i => new CodeTree.InstuructionNode(i));
                
            var prop = method.GetProperty();
            if(prop != null)
            {
                var propNode = propertiesMap.GetOrPut(prop, () => new CodeTree.PropertyNode(prop));
                
                if(method.IsGetter)
                    propNode.AddGetter(instrNodes);
                else
                    propNode.AddSetter(instrNodes);
                return propNode;
            }

            return new CodeTree.MethodNode(method, instrNodes);
        }

        private bool QueryPointcut<TPointcut, TItem>(
            ILogWriter logger,
            IDictionary<AssemblyDefinition, TypeDefinition[]> asmTypes, 
            KeyValuePair<PointcutExpression, IPointcut> pointcut, 
            Func<TypeDefinition[], TPointcut, IEnumerable<TItem>> queryAction,
            Func<IEnumerable<TItem>, IEnumerable<CodeTree.TypeNode>> createTypeNodes 
            ) where TPointcut : class, IPointcut
        {
            var tPointcut = pointcut.Value as TPointcut;
            if(tPointcut == null)
                return false;

            Dictionary<AssemblyDefinition, TItem[]> filteredAsmTypes;

            try
            {
                logger.Append("STARTED: executing pointcut '{0}'...", tPointcut.Name);
                filteredAsmTypes = asmTypes.AsParallel().ToDictionary(
                    asmType => asmType.Key,
                    asmType => queryAction(asmType.Value, tPointcut).ToArray());
                logger.Append("COMPLETED: executing pointcut '{0}'", tPointcut.Name);
            }
            catch (Exception e)
            {
                logger.Append("ERROR executing pointcut '{0}'. Reason: '{1}'", tPointcut.Name, e.Message);
                filteredAsmTypes = asmTypes.ToDictionary(x=> x.Key, x=> new TItem[0]);
            }
            
            _treeDispatcher.BeginInvoke(new Action(()=>
                _result.AddPointcut(tPointcut, 
                        string.Format("[{0}(\"{1}\")]", pointcut.Key.AttributeName, pointcut.Key.Saql),
                        filteredAsmTypes.Select(x=> new CodeTree.AssemblyNode(x.Key, createTypeNodes(x.Value))))));
            return true;
        }
    }
}