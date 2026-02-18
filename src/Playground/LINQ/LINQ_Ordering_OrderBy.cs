using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Ordering_OrderBy : ExampleBase
{
    public LINQ_Ordering_OrderBy()
        : base("LINQ_Ordering_OrderBy Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 5, 1, 8, 3 };
        var ordered = numbers.OrderBy(x => x);

        Console.WriteLine("For simple types like int, x => x is the identity selector.");
    }
}
