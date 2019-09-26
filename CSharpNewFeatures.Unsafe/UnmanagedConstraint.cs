using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class UnmanagedConstraint
    {
        public static void Demo()
        {
            DisplaySize<Coords<int>>();
            DisplaySize<Coords<double>>();
        }

        unsafe static void DisplaySize<T>() where T : unmanaged
        {
            Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes.");
        }

        struct Coords<T>
        {
            public T X;
            public T Y;
        }
    }
}
