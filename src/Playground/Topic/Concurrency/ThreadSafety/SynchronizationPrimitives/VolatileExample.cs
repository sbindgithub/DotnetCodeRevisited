using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class VolatileExample : ExampleBase
{
    public VolatileExample()
        : base("Volatile Example", TopicType.VolatileExample)
    {
    }
    private volatile bool _flag = false;
    public override void Run()
    {
        Task.Run(() =>
        {
            Thread.Sleep(1000);
            _flag = true;
        });

        while (!_flag)
        {
            // waiting
        }

        Console.WriteLine("Flag detected as true");

    }

  
}
