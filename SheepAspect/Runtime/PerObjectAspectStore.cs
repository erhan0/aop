using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SheepAspect.Core;
using SheepAspect.Helpers;

namespace SheepAspect.Runtime
{
    public class PerObjectAspectStore
    {
        private readonly IDictionary<Type, object> _map = new ConcurrentDictionary<Type, object>();

        public void Bind(Type aspectType, Func<object> factory)
        {
            _map.GetOrPut(aspectType, factory);
        }

        public object Get(Type aspectType)
        {
            object obj;
            _map.TryGetValue(aspectType, out obj);
            return obj;
        } 
    }
}