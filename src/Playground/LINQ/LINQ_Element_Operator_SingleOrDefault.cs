using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Element_Operator_SingleOrDefault : ExampleBase
{
    public LINQ_Element_Operator_SingleOrDefault()
        : base("LINQ_Element_Operator_SingleOrDefault Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };


        var singleOrDefault = numbers.SingleOrDefault(x => x == 10);

        Console.WriteLine($"SingleOrDefault:", singleOrDefault);
        Console.WriteLine("If no element matches, it returns the default value (0 for int).\r\nIf more than one match exists, it still throws an exception.");

    }
}
