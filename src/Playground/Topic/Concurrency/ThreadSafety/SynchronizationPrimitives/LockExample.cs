using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class LockExample : ExampleBase
{
    public LockExample()
        : base("Lock Example", TopicType.LockExample)
    {
    }

    private int _counter = 0;
    private readonly object _lock = new object();

    public override void Run()
    {
        Parallel.For(0, 10000, i =>
        {
            lock (_lock)
            {
                _counter++;
            }
        });

        Console.WriteLine($"Final Count (Lock): {_counter}");

    }

  
}
