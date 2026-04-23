using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class DeadlockExample : ExampleBase
{
    public DeadlockExample()
        : base("Deadlock Example", TopicType.DeadlockExample    )
    {
    }
    private readonly object lock1 = new();
    private readonly object lock2 = new();

    public override void Run()
    {
        var t1 = Task.Run(() =>
        {
            lock (lock1)
            {
                Thread.Sleep(100);
                lock (lock2)
                {
                    Console.WriteLine("Task1 completed");
                }
            }
        });

        var t2 = Task.Run(() =>
        {
            lock (lock2)
            {
                Thread.Sleep(100);
                lock (lock1)
                {
                    Console.WriteLine("Task2 completed");
                }
            }
        });

        Task.WaitAll(t1, t2); // may deadlock

    }

  
}
