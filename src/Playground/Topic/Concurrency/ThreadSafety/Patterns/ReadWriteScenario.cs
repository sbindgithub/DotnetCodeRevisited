using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class ReadWriteScenario : ExampleBase
{
    public ReadWriteScenario()
        : base("Read-Write Scenario", TopicType.ReadWriteScenario   )
    {
    }
    private int _data = 0;
    private readonly ReaderWriterLockSlim _lock = new();

    public override void Run()
    {
        Parallel.Invoke(
             () =>
             {
                 _lock.EnterWriteLock();
                 try
                 {
                     _data++;
                     Console.WriteLine("Write operation");
                 }
                 finally { _lock.ExitWriteLock(); }
             },
             () =>
             {
                 _lock.EnterReadLock();
                 try
                 {
                     Console.WriteLine($"Read: {_data}");
                 }
                 finally { _lock.ExitReadLock(); }
             }
         );

    }

  
}
