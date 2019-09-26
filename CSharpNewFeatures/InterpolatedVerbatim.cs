using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class InterpolatedVerbatim
    {
        public static void Demo()
        {
            string expected = "Horace";
            string actual = "Larry";
            Console.WriteLine($@"She asked, ""Is your name {expected}?""");
            Console.WriteLine(@$"""No,"" he answered, ""my name is {actual}."""); // C# 8.0 only
        }
    }
}
