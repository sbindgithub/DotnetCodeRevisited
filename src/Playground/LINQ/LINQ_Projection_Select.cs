using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Projection_Select : ExampleBase
{
    public LINQ_Projection_Select()
        : base("LINQ_Projection_Select Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };


        var numSquares = numbers.Select(x => x * x).ToList();


        foreach (var n in numSquares)
            Console.WriteLine(n);
    }
}
