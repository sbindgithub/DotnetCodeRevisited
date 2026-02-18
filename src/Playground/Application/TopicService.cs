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
            new LINQ_Projection_Select(),
            new LINQ_Projection_SelectMany(),
            new LINQ_Quantifier_Any(),
            new LINQ_Quantifier_All(),
            new LINQ_Quantifier_Contains(),
            new LINQ_FirstOrDefault(),
            new LINQ_Element_Operator_FirstOrDefault(),
            new LINQ_Element_Operator_LastTakeSkip(),
            new LINQ_Element_Operator_Single(),
            new LINQ_Element_Operator_SingleOrDefault(),
            new LINQ_Ordering_OrderByThenByDescending(),
            new LINQ_Grouping_GroupBy(),
            new LINQ_Joining_JoinAndGroupJoin(),
            new LINQ_SetOperationDistinct(),
            new LINQ_SetOperationUnion(),
            new LINQ_SetOperationIntersect(),
            new LINQ_SetOperationExcept(),
            new LINQ_SCENARIO_BASED()

        };
    }

    public Dictionary<TopicType, List<IExample>> GetTopics()
    {
        return _examples
            .GroupBy(e => e.Topic)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
