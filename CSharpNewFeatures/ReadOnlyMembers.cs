using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpNewFeatures
{
    public static class ReadOnlyMembers
    {
        public static void Demo()
        {
            var p = new Point { X = 30, Y = 40 };
            Console.WriteLine(p);
        }

        struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public readonly double Distance => Math.Sqrt((X * X) + (Y * Y));

            public readonly override string ToString() => $"({X}, {Y}) is {Distance} from the origin";

            public void Translate(int xOffset, int yOffset)
            {
                X += xOffset;
                Y += yOffset;
            }
        }
    }
}
