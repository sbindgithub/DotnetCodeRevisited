using Playground.Domain;
using System.Collections;
using System.ComponentModel;

namespace Playground.Topic.LINQ;

public class LINQ_SetOperationUnion : ExampleBase
{
    public LINQ_SetOperationUnion()
        : base("LINQ_SetOperationUnion Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        //Write a LINQ query to combine both lists without duplicates.
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 4, 5 };

        var union = list1.Union(list2);

        
        Console.WriteLine("Union of list1 and list2:");

        foreach (var n in union)
        {
            Console.WriteLine(n);
        }

    }
}
