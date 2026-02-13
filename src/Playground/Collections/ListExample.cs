using Playground.Domain;

namespace Playground.Collections;

public class ListExample : ExampleBase
{
    public ListExample()
        : base("List Example", TopicType.Collections)
    {
    }

    public override void Run()
    {
        var list = new List<int> { 1, 2, 3 };
        list.Add(4);

        foreach (var item in list)
            Console.WriteLine(item);
    }
}
