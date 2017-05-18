using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;

namespace SheepAspect.Pointcuts.Impl
{
    public abstract class InstructionPointcut<TConcrete> : PointcutBase<IInstructionPointcut>, IInstructionPointcut
        where TConcrete: InstructionPointcut<TConcrete>
    {
        private readonly IList<Func<MethodDefinition, Instruction, bool>> _filters = new List<Func<MethodDefinition, Instruction, bool>>();
        private readonly MemberPointcut<IMethodPointcut, MethodDefinition> _memberFilter = new MemberPointcut<IMethodPointcut, MethodDefinition>();

        public void WhereFromProperty(PropertyMethodPointcut propertyMethodPointcut)
        {
            _memberFilter.WhereAny(propertyMethodPointcut);
        }

        public void WhereFromMethod(MethodPointcut methodPointcut)
        {
            _memberFilter.WhereAny(methodPointcut);
        }

       protected void Where(Func<MethodDefinition, Instruction, bool> condition)
        {
            _filters.Add(condition);
        }

       public override void WhereAny(Func<IInstructionPointcut[]> func)
       {
            _memberFilter.WhereAny(func);

            Where((method, ins) =>
                      {
                          var pointcuts = func();
                          if (pointcuts.Length == 1)
                          {
                              return pointcuts[0].Match(method, ins);
                          }

                          return pointcuts.Any(c => c.Match(method, ins));
                      });
        }

        public void WhereNot(TConcrete pointcut)
        {
            if(pointcut._filters.Any())
            {
                Where((m, i) => !pointcut.MatchFull(m, i));
            }
            else
            {
                _memberFilter.FilterNot(pointcut._memberFilter);
            }
        }

        public bool Match(TypeDefinition type)
        {
            return _memberFilter.Match(type);
        }

        public bool MatchFull(TypeDefinition type)
        {
            return _memberFilter.MatchFull(type);
        }

        public bool Match(MethodDefinition method)
        {
            return _memberFilter.Match(method);
        }

        public bool MatchFull(MethodDefinition method)
        {
            return _memberFilter.MatchFull(method);
        }

        public bool Match(MethodDefinition method, Instruction instruction)
        {
            return _filters.All(f => f(method, instruction));
        }

        public bool MatchFull(MethodDefinition method, Instruction instruction)
        {
            return MatchFull(method) && Match(method, instruction);
        }
    }

    public interface IInstructionPointcut: IMethodPointcut
    {
        bool Match(MethodDefinition method, Instruction instruction);
        bool MatchFull(MethodDefinition method, Instruction instruction);
    }
}