using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Concurrency.ParallelProgramming.TaskParallelism;

public class TaskParallelismBasic_OrderProcessing : ExampleBase
{
    public TaskParallelismBasic_OrderProcessing()
        : base("TaskParallelismBasic_OrderProcessing Example", TopicType.TaskParallelismBasic)
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
