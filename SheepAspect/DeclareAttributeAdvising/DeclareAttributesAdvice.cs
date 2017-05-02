using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;
using ICustomAttributeProvider = Mono.Cecil.ICustomAttributeProvider;
using System.Linq;

namespace SheepAspect.DeclareAttributeAdvising
{
    public class DeclareAttributesAdvice: AdviceBase
    {
        private readonly MemberInfo _memberInfo;
        private readonly Type _exceptAttributeType;

        public DeclareAttributesAdvice(IEnumerable<IPointcut> pointcuts, MemberInfo member, Type exceptAttributeType) : base(pointcuts)
        {
            _memberInfo = member;
            _exceptAttributeType = exceptAttributeType;
        }

        public override string GetFullName()
        {
            return "DeclareAttributes/{0}::{1}".FormatWith(_memberInfo.ReflectedType.FullName, _memberInfo.Name);
        }

        protected IEnumerable<CustomAttribute> GetAttributesToBeAdded(ModuleDefinition module)
        {
            ICustomAttributeProvider provider = _memberInfo is PropertyInfo?
                module.Import(_memberInfo.DeclaringType).Resolve().Properties.First(x => x.Name == _memberInfo.Name):
                (module.Import((dynamic) _memberInfo).Resolve());
            
            var exceptAttributeTypeRef = module.Import(_exceptAttributeType).Resolve();
            return provider.CustomAttributes.Where(x => x.AttributeType.Resolve() != exceptAttributeTypeRef)
                .Select(a=> new CustomAttribute(module.Import(a.Constructor), a.GetBlob()));
        }

        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            yield return new DeclareAttributeWeaver(type, type.Module, GetAttributesToBeAdded(type.Module));
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            yield return new DeclareAttributeWeaver(method, method.Module, GetAttributesToBeAdded(method.Module));
        }

        public override IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            yield return new DeclareAttributeWeaver(property, property.Module, GetAttributesToBeAdded(property.Module));
        }

        public override IEnumerable<IWeaver> GetWeavers(FieldDefinition field)
        {
            yield return new DeclareAttributeWeaver(field, field.Module, GetAttributesToBeAdded(field.Module));
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            throw new UnsupportedPointcutToAdviseException(method, instruction, GetFullName(), "DeclareAttributes");
        }
    }

    public class DeclareAttributeWeaver: IWeaver
    {
        private readonly ICustomAttributeProvider _target;
        private readonly ModuleDefinition _module;
        private readonly IEnumerable<CustomAttribute> _attributes;

        public DeclareAttributeWeaver(ICustomAttributeProvider target, ModuleDefinition module, IEnumerable<CustomAttribute> attributes)
        {
            _target = target;
            _module = module;
            _attributes = attributes;
        }

        public int Priority
        {
            get { return 100; }
        }

        public void Weave()
        {
            foreach (var attribute in _attributes)
                _target.CustomAttributes.Add(attribute);
        }

        public ModuleDefinition Module
        {
            get { return _module; }
        }
    }
}