using System;

namespace SmartTransactionDemo.Aspects
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NonTransactionalAttribute: Attribute
    {
    }
}