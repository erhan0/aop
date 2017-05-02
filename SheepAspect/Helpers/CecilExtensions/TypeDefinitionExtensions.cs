using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Linq;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace SheepAspect.Helpers.CecilExtensions
{
    public static class TypeDefinitionExtensions
    {
        public static IEnumerable<MethodDefinition> GetOrAddConstructors(this TypeDefinition type)
        {
            var cons = type.GetConstructors().Where(x=> !x.IsStatic).ToArray();
            if (cons.Any())
                return cons;
            
            var con = CreateDefaultConstructor(type);
            con.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));

            return new[]{con};
        }

        public static MethodDefinition CreateDefaultConstructor(this TypeDefinition type)
        {
            var cons = new MethodDefinition(".ctor",
                    MethodAttributes.Private
                    | MethodAttributes.HideBySig
                    | MethodAttributes.SpecialName
                    | MethodAttributes.RTSpecialName, type.Module.Import(typeof(void)));
            type.Methods.Add(cons);
            return cons;
        }

        public static MethodDefinition CreateStaticConstructor(this TypeDefinition type)
        {
            var cons = new MethodDefinition(".cctor",
                    MethodAttributes.Private
                    | MethodAttributes.Static
                    | MethodAttributes.HideBySig
                    | MethodAttributes.SpecialName
                    | MethodAttributes.RTSpecialName, type.Module.Import(typeof(void)));
            type.Methods.Add(cons);
            return cons;
        }

        public static bool IsAssignableFrom(this TypeReference target, TypeReference type)
        {
            target = type.Module.Import(target).Resolve();
            
            var baseType = type.Resolve();
            while (true)
            {
                if (baseType.Equals(target))
                    return true;

                if (baseType.Interfaces.Contains(target))
                    return true;

                if (baseType.BaseType == null)
                    return false;

               baseType = baseType.BaseType.Resolve();
            }
        }

        public static bool IsType(this TypeDefinition self, Type type)
        {
            var imported = self.Module.Import(type).Resolve();
            return (Equals(self.FullName, imported.FullName) && Equals(self.Scope.MetadataToken, imported.Scope.MetadataToken));
        }
    }
}