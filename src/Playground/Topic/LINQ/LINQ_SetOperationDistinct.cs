using Playground.Domain;
using System.Collections;

namespace Playground.Topic.LINQ;

public class LINQ_SetOperationDistinct : ExampleBase
{
    public LINQ_SetOperationDistinct()
        : base("LINQ_SetOperationDistinct Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        //Write a LINQ query to remove duplicates.
        var numbers = new List<int> { 1, 2, 2, 3, 3, 4 };


        var distinct = numbers.Distinct();

        Console.WriteLine("Distinct numbers:");
        foreach (var n in distinct)
        {
            Console.WriteLine(n);
        }

    }
}
