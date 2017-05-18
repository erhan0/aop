using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Mono.Cecil;
using System.Linq;
using Mono.Cecil.Pdb;
using SheepAspect.Core;
using SheepAspect.Pointcuts;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Compile
{
    public class AspectCompiler
    {
        private readonly string[] assemblyFiles;
        private readonly CompilerSettings settings;
        private readonly PointcutQueryEngine queryEngine;

        public Func<AssemblyNameDefinition, AssemblyNameDefinition> AssemblyNameTransform { get; set; }
        public Func<string, string> FileNameTransform { get; set; }

        public AspectCompiler(CompilerSettings settings)
        {
            this.settings = settings;
            AssemblyNameTransform = x => x;
            FileNameTransform = x => x;

            assemblyFiles = settings.TargetAssemblyFiles.Select(a => Path.Combine(settings.BaseDirectory, a)).ToArray();
            queryEngine = new PointcutQueryEngine();
        }

        public void WeaveAll()
        {
            Weave(new AttributiveAspectDiscovery(settings));
        }

        public void Weave(IAspectDiscovery discovery)
        {
            Weave(discovery.DiscoverAspects());
        }

        public void Weave(IEnumerable<AspectDefinition> aspects)
        {
            // DO NOT use parallel, because Mono.Cecil is not thread-safe, and will fall apart in multi-threaded environment
            //var stopwatch = Stopwatch.StartNew();

            var resolver = new DefaultAssemblyResolver();
            foreach (var dir in assemblyFiles.Select(Path.GetDirectoryName).Distinct())
            {
                resolver.AddSearchDirectory(dir);
            }

            var readerParams = new ReaderParameters { AssemblyResolver = resolver, ReadingMode = ReadingMode.Immediate};

            var asms = assemblyFiles.Distinct().Select(a => AssemblyDefinition.ReadAssembly( a, readerParams)).ToArray();

            //Trace.TraceInformation("Finised reading assemblies at: " + stopwatch.ElapsedMilliseconds + "ms");

            typeof(PdbReaderProvider).GetType();
            Parallel.ForEach(asms.SelectMany(a => a.Modules), m =>
                {
                    try
                    {
                        m.ReadSymbols();
                    }
                    catch(Exception e)
                    {
                        Trace.TraceWarning("Failed loading PDB for module: {0} (Reason: {1}). Module will be weaved without debug information.", m.FullyQualifiedName, e.Message);
                    }
                });

            //Trace.TraceInformation("Finised reading symbol at: " + stopwatch.ElapsedMilliseconds + "ms");

            var weavers = GetWeavers(asms, aspects.ToArray()).OrderBy(x=> x.Priority).ToArray();
            var modules = weavers.Select(w => w.Module).Distinct().ToArray();

            //Trace.TraceInformation("Finised finding weaver at: " + stopwatch.ElapsedMilliseconds + "ms");

            foreach (var w in weavers)
            {
                w.Weave();
            }

            //Trace.TraceInformation("Finised weaving at: " + stopwatch.ElapsedMilliseconds + "ms");

            Parallel.ForEach(modules.Select(m => m.Assembly).Distinct(), asm =>
            {
                asm.Name = (AssemblyNameTransform(asm.Name));
                var newPath = FileNameTransform(asm.MainModule.FullyQualifiedName);
                //Trace.WriteLine("Writing to " + newPath + " at: " + stopwatch.ElapsedMilliseconds + "ms");
                var writer = new WriterParameters
                {
                    WriteSymbols = true
                };
                asm.Write(newPath, writer);
            });

            //stopwatch.Stop();
            //Trace.TraceInformation("SheepAspect compilation finised in: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        private IEnumerable<IWeaver> GetWeavers(IEnumerable<AssemblyDefinition> assemblies, IEnumerable<AspectDefinition> aspects)
        {
            var types = assemblies.SelectMany(a => queryEngine.GetTypes(a));
            
            foreach (var advice in aspects.SelectMany(a => a.Advices))
            {
                var typePointcuts = new List<ITypePointcut>();
                var methodPointcuts = new List<IMethodPointcut>();
                var propertyPointcuts = new List<IPropertyPointcut>();
                var instructionPointcuts = new List<IInstructionPointcut>();
                var fieldPointcuts = new List<IFieldPointcut>();
                
                foreach(var p in advice.Pointcuts)
                {
                    if(p is IInstructionPointcut)
                    {
                        instructionPointcuts.Add((IInstructionPointcut) p);
                    }
                    else if (p is IMethodPointcut)
                    {
                        methodPointcuts.Add((IMethodPointcut) p);
                    }
                    else if (p is IPropertyPointcut)
                    {
                        propertyPointcuts.Add((IPropertyPointcut)p);
                    }
                    else if (p is IFieldPointcut)
                    {
                        fieldPointcuts.Add((IFieldPointcut)p);
                    }
                    else if (p is ITypePointcut)
                    {
                        typePointcuts.Add((ITypePointcut) p);
                    }
                }

                foreach (var weaver in queryEngine.QueryTypes(types, typePointcuts.ToArray())
                    .SelectMany(t=> advice.GetWeavers(t)))
                {
                    yield return weaver;
                }

                foreach (var weaver in queryEngine.QueryFields(types, fieldPointcuts.ToArray())
                    .SelectMany(f => advice.GetWeavers(f)))
                {
                    yield return weaver;
                }

                foreach (var weaver in queryEngine.QueryProperties(types, propertyPointcuts.ToArray())
                    .SelectMany(p => advice.GetWeavers(p)))
                {
                    yield return weaver;
                }

                foreach (var weaver in queryEngine.QueryMethods(types, methodPointcuts.ToArray())
                    .SelectMany(m => advice.GetWeavers(m)))
                {
                    yield return weaver;
                }

                foreach (var weaver in queryEngine.QueryInstructions(types, instructionPointcuts.ToArray())
                    .SelectMany(i => advice.GetWeavers(i.Key, i.Value)))
                {
                    yield return weaver;
                }
            }
        }
    }
}