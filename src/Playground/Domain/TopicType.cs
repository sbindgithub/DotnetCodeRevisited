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
    Paradigms_FunctionalProgramming_Tuple,
    [Description("Data Parallel Programming - Order Processing")]
    DataParallelism_OrderProcessing,
    [Description("Task Parallelism Basic - Order Processing")]
    TaskParallelismBasic,
    [Description("Task Parallelism Advanced Async - Order Processing")]
    TaskParallelismAdvancedAsync,
    [Description("Lock Example")]
    LockExample,
    [Description("Monitor Example")]
    MonitorExample,
    [Description("Interlocked Example")]
    InterlockedExample,
    [Description("Volatile Example")]
    VolatileExample,
    [Description("ConcurrentBag Example")]
    ConcurrentBagExample,
    [Description("ConcurrentDictionary Example")]
    ConcurrentDictionaryExample,
    [Description("ConcurrentQueue Example")]
    ConcurrentQueueExample,
    [Description("Producer-Consumer Queue Example")]
    ProducerConsumer_Queue,
    [Description("Read-Write Scenario")]
    ReadWriteScenario,
    [Description("Deadlock Example")]
    DeadlockExample,
    [Description("Race Condition Example")]
    RaceConditionExample,
    [Description("No Deadlock Example - Fail Safe")]
    NoDeadlockExample_FailSafe


}
