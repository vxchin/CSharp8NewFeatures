using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class NullCoalescingAssignment
    {
        public static void Demo1()
        {
            List<int>? numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);

            numbers ??= new List<int>();
            numbers.Add(i ??= 20);

            Console.WriteLine(String.Join(", ", numbers));
            Console.WriteLine($"i now is {i}");
        }

        public static void Demo2()
        {
            var a = Singleton.Instance;
            var b = Singleton.Instance;
            var c = Singleton.Instance;

            Console.WriteLine($"a is {a}");
            Console.WriteLine($"b is {b}");
            Console.WriteLine($"c is {c}");

            Console.WriteLine($"ReferenceEquals(a, b) = {ReferenceEquals(a, b)}");
        }

        class Singleton
        {
            private static Singleton? _instance;
            public static Singleton Instance => _instance ??= new Singleton();

            public Guid Guid { get; }

            private Singleton()
            {
                Guid = Guid.NewGuid();
            }

            public override string ToString() => $"Singleton: {Guid}";
        }
    }
}
