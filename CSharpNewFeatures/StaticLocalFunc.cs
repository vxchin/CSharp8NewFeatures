using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class StaticLocalFunc
    {
        public static void Demo()
        {
            foreach (var i in Counter(0, 10))
            {
                Console.WriteLine(i);
            }
        }

        static IEnumerable<int> Counter(int start, int end)
        {
            if (start >= end)
                throw new ArgumentOutOfRangeException(nameof(start),
                    $"{nameof(start)} must be less then {nameof(end)}.");

            return localCounter(start, end);

            static IEnumerable<int> localCounter(int start, int end)
            {
                for (var i = start; i < end; i++)
                {
                    yield return i;
                }
            }

            //return localCounter();

            //IEnumerable<int> localCounter()
            //{
            //    for (var i = start; i < end; i++)
            //    {
            //        yield return i;
            //    }
            //}
        }
    }
}
