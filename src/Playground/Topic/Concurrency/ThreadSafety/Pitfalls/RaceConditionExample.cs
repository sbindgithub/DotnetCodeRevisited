using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class RaceConditionExample : ExampleBase
{
    public RaceConditionExample()
        : base("Lock Example", TopicType.LockExample)
    {
    }
    private int _counter = 0;
    public override void Run()
    {
        Parallel.For(0, 10000, i =>
        {
            _counter++; // not thread-safe
        });

        Console.WriteLine($"Final Count (Race Condition): {_counter}");

    }

  
}
