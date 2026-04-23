using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class MonitorExample : ExampleBase
{
    public MonitorExample()
        : base("MonitorExample", TopicType.MonitorExample)
    {
    }
    private int _counter = 0;
    private readonly object _lock = new object();

    public override void Run()
    {
        Parallel.For(0, 10000, i =>
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(_lock, ref lockTaken);
                _counter++;
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_lock);
            }
        });

        Console.WriteLine($"Final Count (Monitor): {_counter}");

    }

  
}
