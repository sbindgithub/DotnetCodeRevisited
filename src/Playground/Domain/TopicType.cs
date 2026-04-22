using System.ComponentModel;

namespace Playground.Domain;

public enum TopicType
{
    LINQ,
    Collections,
    Async,
    DI,
    [Description("OOP Abstraction")]
    OOP_Abstraction,
    [Description("OOP Encapsulation")]
    OOP_Encapsulation,
    [Description("OOP Inheritance")]
    OOP_Inheritance,
    [Description("OOP Polymorphism")]
    OOP_Polymorphism,
    [Description("Functional Programming - Func")]
    Paradigms_FunctionalProgramming_Func,
    [Description("Functional Programming - Func Order Pricing Engine")]
    Func_OrderPricingEngine,
    [Description("Functional Programming - Func Order Pricing Engine Advanced")]
    Func_OrderPricingEngineAdvanced,
    [Description("Functional Programming - Tuple")]
    Paradigms_FunctionalProgramming_Tuple
}
