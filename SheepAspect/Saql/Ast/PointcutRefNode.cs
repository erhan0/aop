using System;
using System.Linq;
using SheepAspect.Core;
using SheepAspect.Helpers;
using SheepAspect.Pointcuts;

namespace SheepAspect.Saql.Ast
{
    public class PointcutRefNode : PointcutNodeBase    
    {
        public PointcutRefNode(AspectDefinition aspect, IPointcut referrer, string pointcutName): base(aspect)
        {
            PointcutName = pointcutName;
            Referrer = referrer;
        }

        public string PointcutName { get; set; }
        protected IPointcut Referrer { get; set; }

        public object BuildFor<T>(T pointcut) where T : ICanRef, IPointcut
        {
            pointcut.WhereRef(Referrer, Aspect, PointcutName);
            return pointcut;
        }

        public override string ToString()
        {
            return "${{{0}}}".FormatWith(PointcutName);
        }
    }
}