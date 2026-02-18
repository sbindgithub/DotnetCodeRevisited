using Playground.Domain;
using System.Collections;

namespace Playground.Topic.LINQ;

public class LINQ_Element_Operator_Single : ExampleBase
{
    public LINQ_Element_Operator_Single()
        : base("LINQ_Element_Operator_Single Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };

        var numberEquals3 = numbers.Single(x => x == 3);
        Console.WriteLine($"numberEquals3:", numberEquals3);
        Console.WriteLine("Single(x => x == 3) returns the element if exactly one match exists.\r\nIf:\r\n\r\nNo match → throws exception\r\n\r\nMore than one match → throws exception\r\n\r\nThat strictness is the purpose of Single.");
    }
}
