using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class ConcurrentBagExample : ExampleBase
{
    public ConcurrentBagExample()
        : base("ConcurrentBag Example", TopicType.ConcurrentBagExample  )
    {
    }

    public override void Run()
    {

        var bag = new ConcurrentBag<int>();

        Parallel.For(0, 1000, i =>
        {
            bag.Add(i);
        });

        Console.WriteLine($"Items in bag: {bag.Count}");
    }

  
}
