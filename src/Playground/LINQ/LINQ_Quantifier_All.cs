using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Quantifier_All : ExampleBase
{
    public LINQ_Quantifier_All()
        : base("LINQ_Quantifier_All Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 2, 4, 6, 8 };




        var AllEven = numbers.All(x => x % 2 == 0);


        Console.WriteLine($"hasEven:", (bool)AllEven);
    }
}
