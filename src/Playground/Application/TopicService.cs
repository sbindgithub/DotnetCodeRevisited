using Playground.Domain;
using Playground.LINQ;
using Playground.Collections;

namespace Playground.Application;

public class TopicService
{
    private readonly List<IExample> _examples;

    public TopicService()
    {
        _examples = new List<IExample>
        {
            new SelectExample(),
            new ListExample(),
            new LINQ_OfType(),
            new LINQ_Projection_SelectMany(),
            new LINQ_Quantifier_Any(),
            new LINQ_Quantifier_All(),
            new LINQ_Quantifier_Contains(),
        };
    }

    public Dictionary<TopicType, List<IExample>> GetTopics()
    {
        return _examples
            .GroupBy(e => e.Topic)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
