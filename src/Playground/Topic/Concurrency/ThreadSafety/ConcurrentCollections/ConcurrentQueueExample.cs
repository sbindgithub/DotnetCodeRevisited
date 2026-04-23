using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class ConcurrentQueueExample  : ExampleBase
{
    public ConcurrentQueueExample()
        : base("ConcurrentQueue Example", TopicType.ConcurrentQueueExample  )
    {
    }

    public override void Run()
    {
        var queue = new ConcurrentQueue<int>();

        Parallel.For(0, 1000, i =>
        {
            queue.Enqueue(i);
        });

        Console.WriteLine($"Items in queue: {queue.Count}");

    }

  
}
