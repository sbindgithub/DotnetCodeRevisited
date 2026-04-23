using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class ConcurrentDictionaryExample : ExampleBase
{
    public ConcurrentDictionaryExample()
        : base("ConcurrentDictionary Example", TopicType.ConcurrentDictionaryExample    )
    {
    }

    public override void Run()
    {
        var dict = new ConcurrentDictionary<int, string>();

        Parallel.For(0, 1000, i =>
        {
            dict[i] = $"Value {i}";
        });

        Console.WriteLine($"Items in dictionary: {dict.Count}");

    }

  
}
