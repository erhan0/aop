using System.Collections.Generic;
using Mono.Cecil;
using SheepAspect.Core;

namespace SheepAspect.MixinsAdvising
{
    public class AddMemberAdvice : AdviceBase
    {
        public AddMemberAdvice(IEnumerable<IPointcut> pointcuts, IMemberDefinition memberDefinition) : base(pointcuts)
        {
        }

        public override string FullName
        {
            get
            {
                return "AddMember";
            }
        }
    }
}