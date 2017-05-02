using System;

namespace MixinDemo
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionalAttribute: Attribute
    {
        public string IsolationLevel { get; set; }
        public string Scope { get; set; }
    }
}