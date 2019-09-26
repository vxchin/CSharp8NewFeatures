using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class UsingStatement
    {
        public static void Demo()
        {
            Console.WriteLine("Old Style of using statement w/ brace:");
            Console.WriteLine();
            OldStyleDemo();
            Console.WriteLine();
            Console.WriteLine("New Style of using statement in C# 8:");
            Console.WriteLine();
            NewStyleDemo();
        }

        static void OldStyleDemo()
        {
            using (var src = new ResourceHog("source"))
            {
                using (var dest = new ResourceHog("destination"))
                {
                    dest.CopyFrom(src);
                }
                Console.WriteLine("After closing destination block.");
            }
            Console.WriteLine("After closing source block.");
        }

        static void NewStyleDemo()
        {
            using var src = new ResourceHog("source");
            using var dest = new ResourceHog("destination");
            dest.CopyFrom(src);
            Console.WriteLine("After closing destination block.");
            Console.WriteLine("After closing source block.");
        }

        class ResourceHog : IDisposable
        {
            private bool _disposed;

            public string Name { get; }

            public ResourceHog(string name) => Name = name;

            internal void CopyFrom(ResourceHog src)
            {
                switch (_disposed, src._disposed)
                {
                    case (false, false):
                        Console.WriteLine($"Copying from {src.Name} to {Name}.");
                        return;
                    case (_, _):
                        throw new ObjectDisposedException($"Resource {Name} has already been disposed.");
                }
            }

            public void Dispose()
            {
                Console.WriteLine($"Disposing resource {Name}.");
                _disposed = true;
            }
        }
    }
}
