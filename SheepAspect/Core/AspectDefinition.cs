using System;
using System.Collections.Generic;
using System.Linq;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;
using SheepAspect.Pointcuts;

namespace SheepAspect.Core
{
    public class AspectDefinition
    {
        public AspectDefinition(Type type)
        {
            Type = type;
        }

        public Type Type { get; private set; }

        private readonly IDictionary<string, IList<IPointcut>> _pointcuts = new Dictionary<string, IList<IPointcut>>();
        private readonly IList<IAdvice> _advices = new List<IAdvice>();

        public string Name
        {
            get { return Type.FullName; }
        }

        private IList<IPointcut> PointcutsFor(string name)
        {
            return _pointcuts.GetOrPut(name, () => new List<IPointcut>(1));
        }

        public IEnumerable<IPointcut> GetPointcuts(string name)
        {
            return PointcutsFor(name);
        }

        public IEnumerable<T> GetPointcutForRef<T>(string name, IPointcut referrer) where T :IPointcut
        {
            var pointcuts = GetPointcuts(name).OfType<T>().ToArray();
            if (!pointcuts.Any())
                throw new IncorrectPointcutRefTypeException(this, referrer, name, typeof (T));
            return pointcuts;
        }

        public T AddPointcut<T>(string name) where T : IPointcut, new()
        {
            var value = new T { Name = name };
            PointcutsFor(name).Add(value);
            return value;
        }

        public void Advise(IAdvice advice)
        {
            _advices.Add(advice);
        }

        public IEnumerable<IAdvice> Advices
        {
            get { return _advices; }
        }


    }
}