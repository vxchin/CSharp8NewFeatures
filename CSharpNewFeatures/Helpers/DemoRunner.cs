using System;
using System.Threading.Tasks;

namespace CSharpNewFeatures
{
    partial class Program
    {

        #region helpers

        private static void PrintTitle(System.Reflection.MethodInfo method, bool async = false)
        {
            var hr = "=======================================================";
            var type = method.DeclaringType;
            Console.WriteLine(hr);
            Console.WriteLine($"  Running {type!.Name}.{method.Name}()"
                + (async ? " asynchronously." : "."));
            Console.WriteLine(hr);
        }

        private static void Run(Action demo)
        {
            PrintTitle(demo.Method);
            demo.Invoke();
            Console.WriteLine();
        }

        private static void Run(Func<Task> demo)
        {
            PrintTitle(demo.Method, async: true);
            demo.Invoke().GetAwaiter().GetResult();
            Console.WriteLine();
        }

        #endregion
    }
}
