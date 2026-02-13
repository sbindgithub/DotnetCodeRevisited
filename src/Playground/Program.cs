using Playground.Application;
using Playground.Domain;

var topicService = new TopicService();

while (true)
{
    Console.Clear();

    var grouped = topicService.GetTopics();
    var topics = grouped.Keys.ToList();

    Console.WriteLine("Select Topic:");

    for (int i = 0; i < topics.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {topics[i]}");
    }

    Console.WriteLine("0. Exit");
    Console.Write("Enter choice: ");

    var topicInput = Console.ReadLine();

    if (topicInput == "0")
        break;

    if (!int.TryParse(topicInput, out int topicIndex) ||
        topicIndex < 1 ||
        topicIndex > topics.Count)
    {
        Console.WriteLine("Invalid topic.");
        Console.ReadKey();
        continue;
    }

    var selectedTopic = topics[topicIndex - 1];
    var examples = grouped[selectedTopic];

    Console.Clear();
    Console.WriteLine($"Topic: {selectedTopic}");

    for (int i = 0; i < examples.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {examples[i].Name}");
    }

    Console.Write("Enter choice: ");
    var exampleInput = Console.ReadLine();

    if (!int.TryParse(exampleInput, out int exampleIndex) ||
        exampleIndex < 1 ||
        exampleIndex > examples.Count)
    {
        Console.WriteLine("Invalid example.");
        Console.ReadKey();
        continue;
    }

    Console.Clear();
    examples[exampleIndex - 1].Run();

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
