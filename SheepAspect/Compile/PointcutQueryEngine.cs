using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Pointcuts;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Compile
{
    public class PointcutQueryEngine
    {
        public IEnumerable<TypeDefinition> GetTypes(AssemblyDefinition assemblies)
        {
            return assemblies.Modules.ToArray().SelectMany(m => m.Types).SelectMany(AllTypesInHierarchy);
        }

        public IEnumerable<TypeDefinition> QueryTypes(IEnumerable<TypeDefinition> types, params ITypePointcut[] pointcuts)
        {
            if(!pointcuts.Any())
            {
                return Enumerable.Empty<TypeDefinition>();
            }

            return types.Where(t => pointcuts.Any(p => p.Match(t)));
        }

        public IEnumerable<FieldDefinition> QueryFields(IEnumerable<TypeDefinition> types, IFieldPointcut[] pointcuts)
        {
            if (!pointcuts.Any())
            {
                return Enumerable.Empty<FieldDefinition>();
            }

            return from type in types
                   let typeMatchedPointcuts = pointcuts.Where(p => p.Match(type)).ToArray()
                   from method in type.Fields.Where(f => typeMatchedPointcuts.Any(pc => pc.Match(f)))
                   select method;
        }

        public IEnumerable<MethodDefinition> QueryMethods(IEnumerable<TypeDefinition> types, params IMethodPointcut[] pointcuts)
        {
            if (!pointcuts.Any())
            {
                return Enumerable.Empty<MethodDefinition>();
            }

            return from type in types
                   let typeMatchedPointcuts = pointcuts.Where(p => p.Match(type)).ToArray()
                   from method in type.Methods.Where(m => typeMatchedPointcuts.Any(p => p.Match(m)))
                   select method;
        }

        public IEnumerable<PropertyDefinition> QueryProperties(IEnumerable<TypeDefinition> types, params IPropertyPointcut[] pointcuts)
        {
            if (!pointcuts.Any())
            {
                return Enumerable.Empty<PropertyDefinition>();
            }

            return from type in types
                   let typeMatchedPointcuts = pointcuts.Where(p => p.Match(type)).ToArray()
                   from method in type.Properties.Where(p => typeMatchedPointcuts.Any(pc => pc.Match(p)))
                   select method;
        }

        public IEnumerable<KeyValuePair<MethodDefinition, Instruction>> QueryInstructions(IEnumerable<TypeDefinition> types, params IInstructionPointcut[] pointcuts)
        {
            if (!pointcuts.Any())
            {
                return Enumerable.Empty<KeyValuePair<MethodDefinition, Instruction>>();
            }

            return from type in types
                   let typeMatchedPointcuts = pointcuts.Where(p => p.Match(type)).ToArray()
                   where typeMatchedPointcuts.Any()
                   from method in type.Methods.Where(m => m.HasBody)
                   let methodMatchedPointcuts = typeMatchedPointcuts.Where(p => p.Match(method))
                   from instruction in method.Body.Instructions.Where(i => methodMatchedPointcuts.Any(p => p.Match(method, i)))
                   select new KeyValuePair<MethodDefinition, Instruction>(method, instruction);
        }

        private static IEnumerable<TypeDefinition> AllTypesInHierarchy(TypeDefinition type)
        {
            yield return type;
            foreach (var t in type.NestedTypes.SelectMany(AllTypesInHierarchy))
            {
                yield return t;
            }
        }
    }
}