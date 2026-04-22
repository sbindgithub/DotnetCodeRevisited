using Playground.Domain;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class Dictionary_Interface_Driven : ExampleBase
{
    public Dictionary_Interface_Driven()
        : base("Dictionary_Interface_Driven Example", TopicType.Paradigms_FunctionalProgramming_Func)
    {
    }

    public interface IPaymentProcessor { 
    void ProcessPayment(decimal amount);
    }

    public override void Run()
    {
        // Step 1: Register strategies
        Dictionary<string, IPaymentProcessor> processors = new()
        {
             { "CREDIT",new CreditCardProcessor()},
            { "UPI",new UPIProcessor()},
            { "NETBANKING",new NetBankingProcessor()}
        };

        // Step 2: Process payments
        string paymentType = "CREDIT";
        decimal amount = 1500;

        if (processors.TryGetValue(paymentType, out IPaymentProcessor processor))
        {
            processor.ProcessPayment(amount);
        }
        else
        {
            Console.WriteLine("Invalid payment type");
        }

    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}");
        }
    }

    public class UPIProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing UPI payment of {amount}");
        }
    }

    public class NetBankingProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing NetBanking payment of {amount}");
        }
    }
}

