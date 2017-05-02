using Mono.Cecil;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Pointcuts
{
    public interface IPropertyPointcut : IMemberPointcut<PropertyDefinition>
    {
    }
}