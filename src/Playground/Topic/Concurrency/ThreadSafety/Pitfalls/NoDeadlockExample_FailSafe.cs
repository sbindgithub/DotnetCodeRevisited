using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

public class NoDeadlockExample_FailSafe : ExampleBase
{
    public NoDeadlockExample_FailSafe()
        : base("No Deadlock Example - Fail Safe", TopicType.NoDeadlockExample_FailSafe    )
    {
    }

    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();

    public override void Run()
    {
        bool lock1Taken = false;
        bool lock2Taken = false;

        try
        {
            Monitor.TryEnter(lock1, TimeSpan.FromMilliseconds(500), ref lock1Taken);
            if (!lock1Taken) return;

            Monitor.TryEnter(lock2, TimeSpan.FromMilliseconds(500), ref lock2Taken);
            if (!lock2Taken) return;

            Console.WriteLine("Both locks acquired safely");
        }
        finally
        {
            if (lock2Taken) Monitor.Exit(lock2);
            if (lock1Taken) Monitor.Exit(lock1);
        }

    }

  
}
