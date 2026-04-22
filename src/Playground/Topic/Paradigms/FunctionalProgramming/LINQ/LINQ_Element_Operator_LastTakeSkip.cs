using Playground.Domain;
using System.Collections;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class LINQ_Element_Operator_LastTakeSkip : ExampleBase
{
    public LINQ_Element_Operator_LastTakeSkip()
        : base("LINQ_Element_Operator_LastTakeSkip Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        //LAST
        var numbers = new List<int> { 2, 4, 6, 8, 10 };
        var lastGreaterThan5 = numbers.Last(x => x > 5);
        Console.WriteLine("Last(x => x > 5) scans the sequence and returns the last element that matches the condition.\r\n\r\nBe aware:\r\n\r\nOn IEnumerable, it may iterate the full collection.\r\n\r\nOn IQueryable, it may translate differently depending on provider");


        //Take
        var numbers1 = new List<int> { 1, 2, 3, 4, 5, 6 };
        var firstThree = numbers1.Take(3);
        Console.WriteLine("Take(3) returns the first three elements. Deferred execution unless materialized.");

        //Skip
        var numbers2 = new List<int> { 1, 2, 3, 4, 5, 6 };

        var fastTwo = numbers.Skip(2);
        Console.WriteLine("Skip(2) ignores the first two elements and returns the rest.");

    }
}
