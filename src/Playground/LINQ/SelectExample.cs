using Playground.Domain;

namespace Playground.LINQ;

public class SelectExample : ExampleBase
{
    public SelectExample()
        : base("Select Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var numbers = new[] { 1, 2, 3, 4 };
        var result = numbers.Select(x => x * 2);

        foreach (var n in result)
            Console.WriteLine(n);
    }
}
