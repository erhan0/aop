using System;
using System.Collections.Generic;

namespace SheepAspect.Helpers
{
    public static class CollectionHelper
    {
        public static TVal GetOrPut<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key, Func<TVal> valFunc)
        {
            TVal val;
            if (!dict.TryGetValue(key, out val))
            {
                lock (dict)
                {
                    if (!dict.TryGetValue(key, out val))
                        dict[key] = val = valFunc();
                }
            }
            return val;
        }

        public static TVal GetOrDefault<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key, Func<TVal> valFunc)
        {
            TVal val;
            if (!dict.TryGetValue(key, out val))
            {
                return valFunc();
            }
            return val;
        }

        public static void TransferItemsTo<T>(this ICollection<T> source, ICollection<T> target)
        {
            foreach (var s in source)
                target.Add(s);
            
            source.Clear();
        }
    }
}