using Playground.Domain;
using System;
using System.Collections;
using System.IO.Pipes;

namespace Playground.LINQ;

public class LINQ_Ordering_OrderByThenByDescending : ExampleBase
{
    public LINQ_Ordering_OrderByThenByDescending()
        : base("LINQ_Ordering_OrderBy Example", TopicType.LINQ)
    {
    }


    public override void Run()
    {
        //Ordering – OrderBy
        var numbers = new List<int> { 5, 1, 8, 3 };
        var ordered = numbers.OrderBy(x => x);

        Console.WriteLine("For simple types like int, x => x is the identity selector.");

        //Ordering – ThenBy
        var people = new List<Person>
        {
            new Person { Name = "John", Age = 30 },
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 25 }
        };

        var sortedPeople = people.OrderBy(p => p.Age).ThenBy(p => p.Name);

        Console.WriteLine("People sorted by Age, then by Name:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }

        //Ordering – OrderByDescending

        var descendingOrder = numbers.OrderByDescending(x => x);

        Console.WriteLine("Numbers in descending order:");
        foreach (var number in descendingOrder)
        {
            Console.WriteLine(number);
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}