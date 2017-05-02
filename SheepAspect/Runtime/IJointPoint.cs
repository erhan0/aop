using System.Reflection;
using System.Linq;
using Mono.Cecil;
using SheepAspect.Core;

namespace SheepAspect.Runtime
{
    public interface IJointPoint
    {
        object This { get; }
        object Execute();
    }

    public abstract class JointPointBase : IJointPoint
    {
        private readonly AdviceCallback _callback;
        protected object Target { get; set; }
        public object This { get; protected set; }
        protected readonly object[] _args;

        protected JointPointBase(AdviceCallback callback, object thisInstance, object target, object[] args)
        {
            This = thisInstance;
            Target = target;
            _args = args;
            _callback = callback;
        }

        public object Execute()
        {
            return _callback(This, Target,_args);
        }

        public abstract class StaticPart
        {
            public AdviceInvoker Advice { get; private set; }
            public AdviceCallback Callback { get; private set; }

            protected StaticPart(AdviceInvoker advice, AdviceCallback callback)
            {
                Advice = advice;
                Callback = callback;
            }

            public static StaticPart ForMethod(AdviceInvoker advice, AdviceCallback callback, MethodInfo method)
            {
                return new MethodJointPoint.StaticPart(method, advice, callback);
            }

            public static StaticPart ForPropertyGet(AdviceInvoker advice, AdviceCallback callback, MethodInfo method)
            {
                return new PropertyGetJointPoint.StaticPart(method.DeclaringType.GetProperties().First(m=> m.GetGetMethod(true) == method), advice, callback);
            }

            public static StaticPart ForPropertySet(AdviceInvoker advice, AdviceCallback callback, MethodInfo method)
            {
                return new PropertySetJointPoint.StaticPart(method.DeclaringType.GetProperties().First(m => m.GetSetMethod(true) == method), advice, callback);
            }

            public static StaticPart ForCallFieldGet(AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod, FieldInfo field)
            {
                return new GetFieldJointPoint.StaticPart(field, advice, callback, callingMethod);
            }

            public static StaticPart ForCallFieldSet(AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod, FieldInfo field)
            {
                return new SetFieldJointPoint.StaticPart(field, advice, callback, callingMethod);
            }

            public static StaticPart ForCallMethod(AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod, MethodInfo method)
            {
                return new CallMethodJointPoint.StaticPart(method, advice, callback, callingMethod);
            }

            public object Dispatch(object thisInstance, object target, object[] args, IAspectLifecycle lifecycle)
            {
                var jp = CreateJoinPoint(thisInstance, target, args);
                var aspect = lifecycle.GetAspect(jp);

                if(aspect == null)
                    return Callback(thisInstance, target, args);
                
                return Advice(aspect, jp);
            }

            public abstract IJointPoint CreateJoinPoint(object instance, object target, object[] args);
        }
    }
}