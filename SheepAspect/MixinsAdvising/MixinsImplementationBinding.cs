using System;
using System.Reflection;
using System.Threading;
using SheepAspect.Runtime;

namespace SheepAspect.MixinsAdvising
{
    public class CachedMixinsImplementationBinding<TAspect, TMixinImpl> : MixinsImplementationBinding<TAspect, TMixinImpl>
        where TAspect : class
        where TMixinImpl : class
    {
        private readonly Lazy<TMixinImpl> _lazyImpl;
        
        public CachedMixinsImplementationBinding(MethodInfo ctor, object instance, object[] args, Func<TAspect, TMixinImpl> selector) 
            : base(ctor, instance, args, selector)
        {
            _lazyImpl = new Lazy<TMixinImpl>(() => base.GetImplementation(), LazyThreadSafetyMode.PublicationOnly);
        }

        public override TMixinImpl GetImplementation()
        {
            return _lazyImpl.Value;
        }
    }

    public class MixinsImplementationBinding<TAspect, TMixinImpl> where TAspect: class where TMixinImpl:class
    {
        private readonly Func<TAspect, TMixinImpl> _selector;
        private readonly Lazy<TAspect> _lazyAspect;
 
        public MixinsImplementationBinding(MethodInfo ctor, object instance, object[] args, Func<TAspect, TMixinImpl> selector)
        {
            _selector = selector;
            _lazyAspect = new Lazy<TAspect>(()=>
                {
                    var aspect =
                        AspectRuntime.GetAspect<TAspect>(new MethodJointPoint(ctor, instance, args,
                            delegate{throw new NotImplementedException();}));
                    if(aspect == null)
                        throw new NotImplementedException("SheepAspect Mixin has no implementation");

                    return aspect;
                }, LazyThreadSafetyMode.PublicationOnly);
        }

        private TAspect Aspect
        {
            get
            {
                return _lazyAspect.Value;
            }
        }

        public virtual TMixinImpl GetImplementation()
        {
            var impl = _selector(Aspect);
            if(impl == null)
                throw new NotImplementedException("SheepAspect Mixin has no implementation");
            return impl;
        }
    }
}