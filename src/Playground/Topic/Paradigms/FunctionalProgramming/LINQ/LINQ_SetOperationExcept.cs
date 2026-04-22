using Playground.Domain;
using System.Collections;
using System.ComponentModel;
using System.Xml.Linq;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class LINQ_SetOperationExcept : ExampleBase
{
    public LINQ_SetOperationExcept()
        : base("LINQ_SetOperationExcept Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        //Write a LINQ query to get elements in list1 that are NOT in list2.
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 4, 5 };

        var list = list1.Except(list2);

        
        Console.WriteLine("Elements in list1 that are NOT in list2:");
        Console.WriteLine(
            string.Join(", ", list)
        );

    }
}
