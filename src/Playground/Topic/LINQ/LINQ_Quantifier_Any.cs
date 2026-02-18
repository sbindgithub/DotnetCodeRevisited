using Playground.Domain;
using System.Collections;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Playground.Topic.LINQ;

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

        Console.WriteLine($"hasEven Any:", hasEven);
        Console.WriteLine("Contains(value) → checks for a specific value");
        Console.WriteLine("Any(condition) → checks if any element satisfies a condition");
    }
}
