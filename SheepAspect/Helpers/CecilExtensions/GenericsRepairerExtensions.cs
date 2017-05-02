using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using System.Linq;

namespace SheepAspect.Helpers.CecilExtensions
{
    public static class GenericsRepairerExtensions
    {
        public static IEnumerable<MethodReference> SelectGenericSafeMethods(this TypeReference type, Func<TypeDefinition, IEnumerable<MethodDefinition>> selector)
        {
            return selector(type.Resolve()).Select(def => MakeHostInstanceGeneric(type.Module.Import(def), type));
        }

        public static void TransferGenerics(this MemberReference self, IDictionary<GenericParameter, GenericParameter> map)
        {
            var genMethod = self as GenericInstanceMethod;
            if(genMethod != null)
            {
                for(var i=0; i< genMethod.GenericArguments.Count; i++)
                    genMethod.GenericArguments[i] = TransferGenerics(genMethod.GenericArguments[i], map);
            }

            var typeRef = self as TypeReference;
            if(typeRef != null)
            {
                self = TransferGenerics(typeRef, map);
            }

            TransferGenerics(self.DeclaringType, map);
        }

        public static TypeReference TransferGenerics(this TypeReference self, IDictionary<GenericParameter, GenericParameter> map)
        {
            var array = self as ArrayType;
            if (array != null)
                return new ArrayType(TransferGenerics(array.ElementType, map), array.Rank);

            var genParam = self as GenericParameter;
            GenericParameter mapped;
            if (genParam != null && map.TryGetValue(genParam, out mapped))
                return mapped;

            var genType = self as GenericInstanceType;
            if(genType != null)
            {
                for (var i = 0; i < genType.GenericArguments.Count; i++)
                    genType.GenericArguments[i] = TransferGenerics(genType.GenericArguments[i], map);
            }
            return self;
        }

        public static MethodReference MakeHostGenericSelf(this MethodDefinition self)
        {
            TypeReference typeRef = self.DeclaringType;
            if(typeRef.HasGenericParameters)
            {
                var genType = MakeGenericSelf(typeRef);
                return self.MakeHostInstanceGeneric(genType);
            }

            return self;
        }

        public static FieldReference MakeHostGenericSelf(this FieldDefinition self)
        {
            TypeReference typeRef = self.DeclaringType;
            if (typeRef.HasGenericParameters)
            {
                var genType = MakeGenericSelf(typeRef);
                return self.MakeHostInstanceGeneric(genType);
            }

            return self;
        }

        public static GenericInstanceType MakeGenericSelf(this TypeReference typeRef)
        {
            var genType = new GenericInstanceType(typeRef);
            foreach (var p in typeRef.GenericParameters)
                genType.GenericArguments.Add(p);
            return genType;
        }

        public static MethodReference MakeGenerics(this MethodReference self, params TypeReference[] genericArgs)
        {
            if (!self.HasGenericParameters)
                return self;

            var genericMethod = new GenericInstanceMethod(self);
            foreach (var p in genericArgs)
                genericMethod.GenericArguments.Add(p);
            return genericMethod;
        }

        public static TypeReference MakeGenerics(this TypeReference self, params TypeReference[] genericArgs)
        {
            if (!self.HasGenericParameters)
                return self;
            var genericType = new GenericInstanceType(self);
            foreach (var p in genericArgs)
                genericType.GenericArguments.Add(p);
            return genericType;
        }

        public static MethodReference MakeHostInstanceGeneric(this MethodReference self, TypeReference type)
        {
            var gType = type as GenericInstanceType;
            if (gType == null)
                return self;

            var m = new MethodReference(self.Name, self.ReturnType, type)
                        {
                            HasThis = self.HasThis,
                            ExplicitThis = self.ExplicitThis,
                            CallingConvention = self.CallingConvention
                        };
            foreach (var p in self.Parameters)
                m.Parameters.Add(new ParameterDefinition(p.ParameterType));
            foreach (var p in self.GenericParameters)
                m.GenericParameters.Add(p);

            return m;
        }

        public static MethodReference MakeHostInstanceGeneric(this MethodReference self, params GenericParameter[] hostGenerics)
        {
            var type = self.DeclaringType.MakeGenerics(hostGenerics);

            var m = new MethodReference(self.Name, self.ReturnType, type)
            {
                HasThis = self.HasThis,
                ExplicitThis = self.ExplicitThis,
                CallingConvention = self.CallingConvention
            };
            foreach (var p in self.Parameters)
                m.Parameters.Add(new ParameterDefinition(p.ParameterType));
            foreach (var p in self.GenericParameters)
                m.GenericParameters.Add(p);

            return m;
        }

        public static FieldReference MakeHostInstanceGeneric(this FieldDefinition self, GenericInstanceType type)
        {
            return new FieldReference(self.Name, self.FieldType, type);
        }

    }
}