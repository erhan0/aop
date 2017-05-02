using Mono.Cecil;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Pointcuts
{
    public interface IMethodPointcut: IMemberPointcut<MethodDefinition>
    {
    }
}