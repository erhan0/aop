using System;

namespace WeaveStaticMethodDemo
{
    public static class StringHelper
    {
        public static int CalculateAdsFee(this string text, int rate)
        {
            Console.WriteLine("Calculating {0}... ", text);
            if(text.Length < 15)
                return text.Length*rate;

            Console.WriteLine("Maximum fee!!");
            return text.Length*rate + 15;
        }

        public static int AnotherCalculateAdsFee(this string text, int rate)
        {
            Console.WriteLine("Calculating {0}... ", text);
            if (text.Length < 15)
                return text.Length * rate;

            Console.WriteLine("Maximum fee!!");
            return text.Length * rate + 15;
        }
    }
}
