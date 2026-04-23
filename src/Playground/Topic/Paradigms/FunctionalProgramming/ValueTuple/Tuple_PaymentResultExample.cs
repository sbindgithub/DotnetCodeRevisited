using Playground.Domain;
using System.Collections;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class Tuple_PaymentResultExample : ExampleBase
{
    public Tuple_PaymentResultExample()
        : base("Tuple_PaymentResultExample ... Example", TopicType.Paradigms_FunctionalProgramming_Func)
    {
    }

    public override void Run()
    {
        var result = ProcessPayment(1500, "UPI");

        Console.WriteLine("Access via named properties:");
        Console.WriteLine($"Success: {result.IsSuccess}");
        Console.WriteLine($"TxnId: {result.TransactionId}");
        Console.WriteLine($"Message: {result.Message}");

        Console.WriteLine();

        Console.WriteLine("Using deconstruction:");

        var (isSuccess, txnId, message) = ProcessPayment(500, "CARD");

        Console.WriteLine($"Success: {isSuccess}");
        Console.WriteLine($"TxnId: {txnId}");
        Console.WriteLine($"Message: {message}");
    }

    private (bool IsSuccess, string TransactionId, string Message)
       ProcessPayment(decimal amount, string paymentType)
    {
        if (amount <= 0)
            return (false, null, "Invalid amount");

        if (paymentType == "UPI")
            return (true, Guid.NewGuid().ToString(), "Processed via UPI");

        if (paymentType == "CARD")
            return (true, Guid.NewGuid().ToString(), "Processed via Card");

        return (false, null, "Unsupported payment type");
    }
}
