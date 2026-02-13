using Playground.Application;
using Playground.Domain;

var service = new TopicService();

while (true)
{
    Console.Clear();

    var topics = service.GetGroupedTopics();
    var topicList = topics.Keys.ToList();

    Console.WriteLine("Select Topic:");

    for (int i = 0; i < topicList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {topicList[i]}");
    }

    Console.WriteLine("0. Exit");
    Console.Write("Enter choice: ");

    var topicInput = Console.ReadLine();

    if (topicInput == "0")
        break;

    if (!int.TryParse(topicInput, out int topicIndex) ||
        topicIndex < 1 ||
        topicIndex > topicList.Count)
    {
        Console.WriteLine("Invalid topic.");
        Console.ReadKey();
        continue;
    }

    var selectedTopic = topicList[topicIndex - 1];
    var examples = topics[selectedTopic];

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
