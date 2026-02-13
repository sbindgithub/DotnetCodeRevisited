using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_OfType : ExampleBase
{
    public LINQ_OfType()
        : base("LINQ_OfType Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        ArrayList items = new ArrayList
        {
            1,
            "hello",
            2,
            "world",
            3
        };

        var intTypes = items.OfType<int>().ToList();


        foreach (var n in intTypes)
            Console.WriteLine(n);
    }
}
