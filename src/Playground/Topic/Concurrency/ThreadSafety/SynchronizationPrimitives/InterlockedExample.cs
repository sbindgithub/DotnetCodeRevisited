using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class InterlockedExample : ExampleBase
{
    public InterlockedExample()
        : base("Interlocked Example", TopicType.InterlockedExample)
    {
    }
    private int _counter = 0;
    public override void Run()
    {

        Parallel.For(0, 10000, i =>
        {
            Interlocked.Increment(ref _counter);
        });

        Console.WriteLine($"Final Count (Interlocked): {_counter}");
    }

  
}
