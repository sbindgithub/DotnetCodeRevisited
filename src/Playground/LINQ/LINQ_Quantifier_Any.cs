using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Quantifier_Any : ExampleBase
{
    public LINQ_Quantifier_Any()
        : base("LINQ_Quantifier_Any Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 1, 3, 5, 7,4,6 };


        var hasEven = numbers.Any(x => x % 2 == 0);


        Console.WriteLine($"hasEven:", (bool)hasEven);
    }
}
