using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Mono.Cecil;
using System.Linq;
using SheepAspect.Core;

namespace SheepAspectQueryAnalyzer.ViewModel
{
    public class QueryResultVm
    {
        private readonly ObservableCollection<CodeTree> _pointcuts = new ObservableCollection<CodeTree>();
        private readonly Dispatcher _uiDispatcher = Application.Current.Dispatcher;

        public QueryResultVm()
        {
            TreeNodes = new ReadOnlyObservableCollection<CodeTree>(_pointcuts);
        }

        public ReadOnlyObservableCollection<CodeTree> TreeNodes { get; set; }

        public IEnumerable<CodeTree.AssemblyNode> ForMethods(IEnumerable<MethodDefinition> methods)
        {
            return methods.GroupBy(x => x.DeclaringType).GroupBy(x=> x.Key.Module.Assembly)
                .Select(gAsm=> new CodeTree.AssemblyNode(gAsm.Key, 
                    gAsm.Select(gType => new CodeTree.TypeNode(gType.Key, 
                        gType.Select(method => new CodeTree.MethodNode(method, null)))))
            );
        }

        public void AddPointcut(IPointcut pointcut, string expression, IEnumerable<CodeTree.AssemblyNode> asmNodes)
        {
            _pointcuts.Add(new CodeTree.PointcutNode(pointcut,expression,asmNodes));
        }

        public void Clear()
        {
            _uiDispatcher.Invoke((Action)(() => _pointcuts.Clear()));
        }
    }
}