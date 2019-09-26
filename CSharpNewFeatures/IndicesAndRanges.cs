using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpNewFeatures
{
    public static class IndicesAndRanges
    {
        static string[] words =
        {                   // index from start    index from end
            "The",          // 0                   ^9
            "quick",        // 1                   ^8
            "brown",        // 2                   ^7
            "fox",          // 3                   ^6
            "jumped",       // 4                   ^5
            "over",         // 5                   ^4
            "the",          // 6                   ^3
            "lazy",         // 7                   ^2
            "dog",          // 8                   ^1
        };

        public static void Demo1()
        {
            Console.WriteLine(words[^1]);
        }

        public static void Demo2()
        {
            var lazyDog = words[^2..^1];

            PrintWords(lazyDog);
        }

        public static void Demo3()
        {
            var allWords = words[..];
            var firstPhrase = words[..4];
            var lastPhrase = words[6..];

            PrintWords(allWords);
            PrintWords(firstPhrase);
            PrintWords(lastPhrase);
        }

        public static void Demo4()
        {
            Index the = ^3;
            Console.WriteLine(words[the]);

            Range phrase = 1..4;
            var text = words[phrase];
            PrintWords(text);
        }

        public static void Demo5() // Why exclusive and ^0 end of collection
        {
            var numbers = Enumerable.Range(0, 100).ToArray();
            int x = 12;
            int y = 25;
            int z = 36;
        }

        public static void Demo6()
        {

        }

        static void PrintWords(string[] words)
        {
            foreach (var word in words)
            {
                Console.Write($"< {word} >");
            }
            Console.WriteLine();
        }
    }
}
