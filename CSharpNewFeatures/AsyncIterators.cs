using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpNewFeatures
{
    public static class AsyncIterators
    {
        public static async Task Demo()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine($"The time is {DateTime.Now:HH:mm:ss}, Retrieved {number}");
            }
        }

        static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (var i = 0; i < 50; i++)
            {
                // every 10 elements, wait 2 seconds:
                if (i % 10 == 0)
                    await Task.Delay(TimeSpan.FromSeconds(2));
                yield return i;
            }
        }
    }
}