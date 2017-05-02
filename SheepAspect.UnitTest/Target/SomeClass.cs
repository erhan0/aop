using System;

namespace SheepAspect.UnitTest.Target
{
    public class SomeClass: MarshalByRefObject
    {
        public int IndexOfC(string something)
        {
            return something.IndexOf('c');
        }

        private int _someField;
        public int SomeProperty { get; set; }
        public string DoSomething()
        {
            return "unmodified";
        }

        public void SetField(int val)
        {
            _someField = val;
        }
        public int GetField()
        {
            return _someField;
        }
        public int GetFieldTimes(int multiplier)
        {
            return _someField*multiplier;
        }
    }
}