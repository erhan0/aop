using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;

namespace SheepAspect.Helpers.CecilExtensions
{
    public static class MethodDefinitionExtensions
    {
        public static VariableDefinition AddLocal(this MethodDefinition methodDef, Type localType)
        {
            return AddLocal(methodDef, methodDef.Module.Import(localType));
        }

        public static VariableDefinition AddLocal(this MethodDefinition methodDef, string name, Type localType)
        {
            return AddLocal(methodDef, name, methodDef.Module.Import(localType));
        }

        public static VariableDefinition AddLocal(this MethodDefinition methodDef, TypeReference variableType)
        {
            var result = new VariableDefinition(variableType);
            methodDef.Body.Variables.Add(result);
            return result;
        }

        public static VariableDefinition AddLocal(this MethodDefinition methodDef, string name, TypeReference variableType)
        {
            var result = new VariableDefinition(name, variableType);
            methodDef.Body.Variables.Add(result);
            return result;
        }

        public static bool ReturnsVoid(this MethodReference methodDef)
        {
            return methodDef.ReturnType.MetadataType == MetadataType.Void;
        }

        public static PropertyDefinition GetProperty(this MethodDefinition self)
        {
            if (self.IsGetter)
            {
                return self.DeclaringType.Properties.First(p => p.GetMethod == self);
            }

            if (self.IsSetter)
            {
                return self.DeclaringType.Properties.First(p => p.SetMethod == self);
            }

            return null;
        }
    }
}