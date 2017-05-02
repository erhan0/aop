using System;
using FluentAssertions.Assertions;
using FluentAssertions.EventMonitoring;

namespace SheepAspect.UnitTest.TestHelper
{
    public static class AssertionExtensions
    {
        public static T CastTo<T>(this ObjectAssertions assertion)
        {
            assertion.BeOfType<T>();
            return (T) assertion.Subject;
        }
    }
}