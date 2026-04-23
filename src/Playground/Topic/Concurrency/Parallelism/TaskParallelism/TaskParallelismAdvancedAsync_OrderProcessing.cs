using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Concurrency.ParallelProgramming.TaskParallelism;

public class TaskParallelismAdvancedAsync_OrderProcessing : ExampleBase
{
    public TaskParallelismAdvancedAsync_OrderProcessing()
        : base("AdvancedTaskParallelismAsync_OrderProcessing Example", TopicType.TaskParallelismAdvancedAsync)
    {
    }

    public override async void Run()
    {
        var sw = Stopwatch.StartNew();

        var validateTask = ValidateOrderAsync();
        var pricingTask = CalculatePriceAsync();
        var saveTask = SaveOrderAsync();

        await Task.WhenAll(validateTask, pricingTask, saveTask);

        sw.Stop();

        Console.WriteLine($"All tasks completed in {sw.ElapsedMilliseconds} ms");
    }


    private async Task ValidateOrderAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Validate done");
    }

    private async Task CalculatePriceAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Pricing done");
    }

    private async Task SaveOrderAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Save done");
    }
}
