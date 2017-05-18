using SheepAspect.Core;
using SheepAspect.Framework;

namespace SheepAspect.Runtime
{
    public static class AspectRuntime
    {
        public static IAspectProvider Provider { get; set; }
        static AspectRuntime()
        {
            Provider = new AttributiveAspectProvider();
        }

        public static TAspect GetAspect<TAspect>(IJointPoint jointpoint)
        {
            return (TAspect) Provider.GetLifecycle(typeof (TAspect)).GetAspect(jointpoint);
        }

        public static object Dispatch<TAspect>(object target, object thisInstance, JointPointBase.StaticPart jpStatic, object[] args) where TAspect : class
        {
            return jpStatic.Dispatch(thisInstance, target, args, Provider.GetLifecycle(typeof(TAspect)));
        }
    }
}