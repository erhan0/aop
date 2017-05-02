using System;

namespace InjectAttributesDemo.Target
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionalAttribute: Attribute
    {
        public string IsolationLevel { get; set; }
        public string Scope { get; set; }
    }
}