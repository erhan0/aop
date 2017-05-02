using System;
using SheepAspect.Framework;
using SheepAspect.Runtime;

namespace SheepAspect.Aspects
{
    [SingletonAspect]
    public abstract class InterceptorAspectBase
    {
        protected abstract void Pointcut();

        [Around("Pointcut")]
        public object Intercept(IJointPoint jp)
        {
            var interception = new InterceptionImpl();

            try
            {
                Before(interception);

                if (!interception.IsPrevented)
                    interception.ReturnValue = jp.Execute();

                Success(jp, interception.Reset(), interception.ReturnValue);
            }
            catch (Exception e)
            {
                Error(jp, interception.Reset(), e);
                if (!interception.IsPrevented)
                    throw;
            }
            finally
            {
                Exit(jp, interception.Reset(), interception.ReturnValue);
            }

            return interception.ReturnValue;
        }

        protected void Before(IInterception interception) { }
        protected void Success(IJointPoint jp, IInterception context, object returnValue) { }
        protected void Error(IJointPoint jp, IInterception reset, Exception exception) { }
        protected void Exit(IJointPoint jp, IInterception reset, object returnValue) { }

        protected interface IInterception
        {
            void PreventDefault(object returnValue);
        }

        private class InterceptionImpl : IInterception
        {
            public bool IsPrevented { get; private set; }
            public object ReturnValue;

            public void PreventDefault(object returnValue)
            {
                IsPrevented = true;
                ReturnValue = returnValue;
            }
            public InterceptionImpl Reset()
            {
                IsPrevented = false;
                return this;
            }
        }
    }
}