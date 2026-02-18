using Playground.Domain;
using System.Collections;
using System.ComponentModel;

namespace Playground.LINQ;

public class LINQ_SetOperationIntersect : ExampleBase
{
    public LINQ_SetOperationIntersect()
        : base("LINQ_SetOperationIntersect Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        //Write a LINQ query to get common elements.
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 4, 5 };

        var list = list1.Intersect(list2);

        Console.WriteLine("Common elements in list1 and list2:");
        Console.WriteLine(
            string.Join(", ", list)
        );

    }
}
