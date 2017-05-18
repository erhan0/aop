using System;
using SheepAspect.Framework;
using SheepAspect.Runtime;

namespace SheepAspect.Core
{
    public class SimpleAspectFactory : IAspectFactory
    {
        public object CreateInstance(Type type, IJointPoint joinpoint)
        {
            var obj = Instantiate(type);

            if (obj is IAspectAware aspectAware)
            {
                aspectAware.OnCreated(joinpoint);
            }

            return obj;
        }

        protected virtual object Instantiate(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}