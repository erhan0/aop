using System.Linq;
using SheepAspect.Core;

namespace SheepAspect.Saql.Ast
{
    public class ArrayValueNode : PointcutNodeBase
    {
        public ArrayValueNode(AspectDefinition aspect, IPointcutValueNode[] values): base(aspect)
        {
            Values = values;
        }
        public IPointcutValueNode[] Values { get; set; }

        protected override T[] BuildFor<T>(T[] obj)
        {
            return Values.Select(v => v.Build(new T())).Cast<T>().ToArray();
        }
    }
}