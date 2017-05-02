using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspectQueryAnalyzer.Properties;
using SheepAspectQueryAnalyzer.Helpers;

namespace SheepAspectQueryAnalyzer.ViewModel
{
    public abstract class CodeTree
    {
        private readonly ObservableCollection<CodeTree> _children = new ObservableCollection<CodeTree>();
        protected CodeTree(IEnumerable<CodeTree> children)
            : this()
        {
            if (children != null)
            {
                foreach (var child in children)
                    _children.Add(child);
            }
        }
        protected CodeTree()
        {
            Children = new ReadOnlyObservableCollection<CodeTree>(_children);
        }
        public ReadOnlyObservableCollection<CodeTree> Children { get; private set; }

        public abstract string DisplayName { get; }

        public ImageSource Icon { get; protected set; }

        public class PointcutNode: CodeTree
        {
            private readonly IPointcut _pointcut;
            private readonly string _expression;

            public PointcutNode(IPointcut pointcut, string expression, IEnumerable<AssemblyNode> asmNodes): base(asmNodes)
            {
                _expression = expression;
                _pointcut = pointcut;

                Icon = CodeTreeIcons.Pointcut.ToImageSource();
            }

            public override string DisplayName
            {
                get { return string.Format("{0}",  _pointcut.Name); }
            }
        }

        public class AssemblyNode : CodeTree
        {
            private readonly AssemblyDefinition _assembly;

            public AssemblyNode(AssemblyDefinition assemblyDefinition, IEnumerable<TypeNode> types): base(NamespacesFor(types))
            {
                _assembly = assemblyDefinition;
                Icon = CodeTreeIcons.Assembly.ToImageSource();
            }

            private static IEnumerable<CodeTree> NamespacesFor(IEnumerable<TypeNode> types)
            {
                return types.GroupBy(x => x.TypeDefinition.Namespace).Select(x => new NamespaceNode(x.Key, x)).ToArray();
            }

            public override string DisplayName
            {
                get { return _assembly.Name.Name; }
            }

        }

        public class NamespaceNode: CodeTree
        {
            private readonly string _namespace;
            private static readonly ImageSource NamespaceImage = CodeTreeIcons.Namespace.ToImageSource();

            public NamespaceNode(string ns, IEnumerable<TypeNode> types): base(types)
            {
                _namespace = ns;
                Icon = NamespaceImage;
            }

            public override string DisplayName
            {
                get { return _namespace; }
            }
        }

        public class TypeNode : CodeTree
        {
            private static ImageSource GetImage(TypeDefinition type)
            {
                if (type.IsInterface)
                    return CodeTreeIcons.Interface.ToImageSource();
                if (type.BaseType.FullName == "System.MulticastDelegate")
                    return CodeTreeIcons.Delegate.ToImageSource();
                if (type.IsValueType)
                    return CodeTreeIcons.Struct.ToImageSource();
                return CodeTreeIcons.Class.ToImageSource();
            }
            
            public TypeDefinition TypeDefinition { get; private set; }

            public TypeNode(TypeDefinition typeDefinition, IEnumerable<CodeTree> children): base(children)
            {
                TypeDefinition = typeDefinition;

                Icon = GetImage(typeDefinition);
            }

            public override string DisplayName
            {
                get { return TypeDefinition.Name; }
            }
        }

        public class MethodNode : CodeTree
        {
            private readonly MethodDefinition _method;
            private readonly string _methodSignature;

            public MethodNode(MethodDefinition method, IEnumerable<InstuructionNode> instructions): base(instructions)
            {
                _method = method;
                _methodSignature = MethodSignatureFullName(_method);

                Icon = CodeTreeIcons.Method.ToImageSource();
            }

            public override string DisplayName
            {
                get { return _methodSignature; }
            }

            public static string MethodSignatureFullName(MethodDefinition method)
            {
                var builder = new StringBuilder(method.Name);
                builder.Append("(");

                if (method.HasParameters)
                {
                    var parameters = method.Parameters;
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        var parameter = parameters[i];
                        if (i > 0)
                            builder.Append(",");

                        if (parameter.ParameterType.IsSentinel)
                            builder.Append("...,");

                        builder.Append(parameter.ParameterType.FullName);
                    }
                }

                builder.Append(") : ");
                builder.Append(method.ReturnType);

                return builder.ToString();
            }
        }

        public class InstuructionNode : CodeTree
        {
            private readonly Instruction _instruction;

            public InstuructionNode(Instruction instruction)
            {
                if(instruction == null)
                    throw new ArgumentNullException("instruction");

                _instruction = instruction;
                Icon = CodeTreeIcons.Instruction.ToImageSource();
            }

            public override string DisplayName
            {
                get { return _instruction.ToString(); }
            }
        }

        public class PropertyNode : CodeTree
        {
            private readonly PropertyDefinition _property;

            public PropertyNode(PropertyDefinition property)
            {
                _property = property;
                Icon = CodeTreeIcons.Property.ToImageSource();
            }

            public override string DisplayName
            {
                get { return _property.Name + " : " + _property.PropertyType; }
            }

            public void AddGetter(IEnumerable<InstuructionNode> instructions)
            {
                _children.Add(new AccessorNode("Get", instructions));
            }

            public void AddSetter(IEnumerable<InstuructionNode> instructions)
            {
                _children.Add(new AccessorNode("Set", instructions));
            }

            private class AccessorNode : CodeTree
            {
                private readonly string _name;

                public AccessorNode(string name, IEnumerable<InstuructionNode> instructions): base(instructions)
                {
                    _name = name;

                }

                public override string DisplayName
                {
                    get { return _name; }
                }
            }
        }
    }

}