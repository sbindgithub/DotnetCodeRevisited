using Playground.Domain;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class Dictionary_Class_Driven : ExampleBase
{
    public Dictionary_Class_Driven()
        : base("Dictionary_Class_Driven Example", TopicType.Paradigms_FunctionalProgramming_Func)
    {
    }

    public interface IPaymentProcessor { 
    void ProcessPayment(decimal amount);
    }

    public override void Run()
    {
       
    }
}

