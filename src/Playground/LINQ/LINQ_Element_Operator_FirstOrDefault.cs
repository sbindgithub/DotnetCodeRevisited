using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Element_Operator_FirstOrDefault : ExampleBase
{
    public LINQ_Element_Operator_FirstOrDefault()
        : base("LINQ_Element_Operator_FirstOrDefault Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 5, 10, 15, 20 };
        var firstNumber = numbers.First(x => x > 10);

        Console.WriteLine($"firstNumber greater than 10:",  firstNumber);
    }
}
