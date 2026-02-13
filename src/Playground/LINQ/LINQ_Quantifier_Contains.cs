using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Quantifier_Contains : ExampleBase
{
    public LINQ_Quantifier_Contains()
        : base("LINQ_Quantifier_Contains Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 10, 20, 30, 40 };



        var containsTwenty = numbers.Contains(20);



        Console.WriteLine($"hasEven:", (bool)containsTwenty);
    }
}
