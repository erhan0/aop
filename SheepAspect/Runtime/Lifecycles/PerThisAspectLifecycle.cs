using System;
using System.Runtime.CompilerServices;
using SheepAspect.Core;

namespace SheepAspect.Runtime.Lifecycles
{
    public class PerThisAspectLifecycle : IAspectLifecycle
    {
        private readonly Type _type;
        private readonly bool _autoInstantiate;
        private static readonly ConditionalWeakTable<object, PerObjectAspectStore> ObjectBoundAspects = new ConditionalWeakTable<object, PerObjectAspectStore>(); 

        public PerThisAspectLifecycle(Type type, bool autoInstantiate)
        {
            _type = type;
            _autoInstantiate = autoInstantiate;
        }

        public object GetAspect(IJointPoint jointPoint)
        {
            if (jointPoint.This == null)
            {
                return null;
            }

            var aspect = ObjectBoundAspects.GetOrCreateValue(jointPoint.This).Get(_type);
            if (aspect == null && _autoInstantiate)
            {
                Bind(jointPoint, _type);
                aspect = ObjectBoundAspects.GetOrCreateValue(jointPoint.This).Get(_type);
            }
            return aspect;
        }

        public static void Bind(IJointPoint jp, Type aspectType)
        {
            ObjectBoundAspects.GetOrCreateValue(jp.This).Bind(aspectType, () => AspectRuntime.Provider.GetFactory(aspectType).CreateInstance(aspectType, jp));
        }
    }
}