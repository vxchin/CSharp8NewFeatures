using System;
using System.Threading.Tasks;

namespace CSharpNewFeatures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Run(NullableReferenceTypes.Demo);

            Run(AsyncIterators.Demo);

            Run(Patterns.Demo);

            Run(DefaultInterfaceMembers.Demo);

            Run(IndicesAndRanges.Demo1);
            Run(IndicesAndRanges.Demo2);
            Run(IndicesAndRanges.Demo3);
            Run(IndicesAndRanges.Demo4);
            Run(IndicesAndRanges.Demo5);
            Run(IndicesAndRanges.Demo6);

            Run(UsingStatement.Demo);

            Run(StaticLocalFunc.Demo);

            Run(ReadOnlyMembers.Demo);

            Run(NullCoalescingAssignment.Demo1);
            Run(NullCoalescingAssignment.Demo2);

            Run(UnmanagedConstraint.Demo);

            Run(InterpolatedVerbatim.Demo);
        }
    }
}
