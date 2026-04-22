using Playground.Domain;

namespace Playground.Topic.Concurrency.AsyncAwait;

public class Async_BlockingVsAwait : ExampleBase
{
    public Async_BlockingVsAwait()
        : base("Async Blocking vs Await Example", TopicType.Async)
    {
    }

    public override void Run()
    {
        Console.WriteLine("Running SYNC (blocking) version...");
        RunSync();

        Console.WriteLine("\nRunning ASYNC (await) version...");
        RunAsync().GetAwaiter().GetResult();
    }

    // ❌ BAD DESIGN – Blocking async I/O
    private void RunSync()
    {
        using var client = new HttpClient();

        for (int i = 0; i < 3; i++)
        {
            var result = client
                .GetStringAsync("https://jsonplaceholder.typicode.com/posts/1")
                .Result; // Blocking

            Console.WriteLine($"SYNC call {i + 1} length: {result.Length}");
        }

        Console.WriteLine("SYNC completed.");
    }

    // ✅ BETTER DESIGN – Proper async usage
    private async Task RunAsync()
    {
        using var client = new HttpClient();

        for (int i = 0; i < 3; i++)
        {
            var result = await client
                .GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");

            Console.WriteLine($"ASYNC call {i + 1} length: {result.Length}");
        }

        Console.WriteLine("ASYNC completed.");
    }
}
