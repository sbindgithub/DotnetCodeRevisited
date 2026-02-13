using Playground.Domain;
using Playground.Infrastructure;

namespace Playground.Application;

public class TopicService
{
    private readonly List<IExample> _examples;

    public TopicService()
    {
        _examples = ExampleRegistry.GetAll();
    }

    public Dictionary<TopicType, List<IExample>> GetGroupedTopics()
    {
        return _examples
            .GroupBy(e => e.Topic)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
