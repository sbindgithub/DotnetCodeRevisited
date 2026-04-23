using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class ProducerConsumer_Queue : ExampleBase
{
    public ProducerConsumer_Queue()
        : base("ConcurrentDictionary Example", TopicType.ConcurrentDictionaryExample)
    {
    }

    public override void Run()
    {
        var queue = new ConcurrentQueue<int>();

        // Producer
        var producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Produced: {i}");
                Thread.Sleep(100);
            }
        });

        // Consumer
        var consumer = Task.Run(() =>
        {
            while (!producer.IsCompleted || !queue.IsEmpty)
            {
                if (queue.TryDequeue(out int item))
                {
                    Console.WriteLine($"Consumed: {item}");
                }
            }
        });

        Task.WaitAll(producer, consumer);

    }

  
}
