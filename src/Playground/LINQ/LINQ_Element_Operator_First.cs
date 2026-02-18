using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_FirstOrDefault : ExampleBase
{
    public LINQ_FirstOrDefault()
        : base("LINQ_FirstOrDefault Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new List<int> { 5, 10, 15 };

        var greaterThan100 = numbers.FirstOrDefault(x => x > 100);
        Console.WriteLine($"greaterThan100 FirstOrDefault:", greaterThan100);

        Console.WriteLine("If no element matches, FirstOrDefault returns the default value of the type.\r\n\r\nFor int, default is 0.");
    }
}
