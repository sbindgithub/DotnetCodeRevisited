using Playground.Domain;
using Playground.Topic.Paradigms.FunctionalProgramming.LINQ;
using Playground.Topic.DataStructures.List;
using Playground.Topic.Concurrency.AsyncAwait;
using Playground.Topic.Architecture.DI;
using Playground.Topic.Paradigms.OOP.Abstraction.Interface;

namespace Playground.Application;

public class TopicService
{
    private readonly List<IExample> _examples;

    public TopicService()
    {
        _examples = new List<IExample>
        {
            new SelectExample(),

            #region LINQ
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
            new LINQ_SCENARIO_BASED(),
            #endregion

            #region AsyncAwait
            new Async_BlockingVsAwait(),

            #endregion

            #region DI
            new DI_Basic_Constructor_Injection(),
            new DI_Lifetime_Comparison(),
            new DI_Method_Injection(),
            new DI_Strategy_Pattern(),
            new DI_Property_Injection(),
            new DI_Singleton_With_Transient(),
            new DI_Transient_vs_Scoped_vs_Singleton_Behavior(),

            #endregion

            #region OOP
            
            new OOP_Abstraction_Interface_Event(),
            new OOP_Abstraction_Interface_Delegate(),
            #endregion,

            #region OOP
            new Func_OrderPricingEngineAdvanced(),
            new Func_OrderPricingEngineAdvanced(),
            new Tuple_PaymentResultExample()

            #endregion
        };
    }

    public Dictionary<TopicType, List<IExample>> GetTopics()
    {
        return _examples
            .GroupBy(e => e.Topic)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
