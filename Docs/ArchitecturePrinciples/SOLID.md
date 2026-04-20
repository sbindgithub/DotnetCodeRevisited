# SOLID design principle

The SOLID principles are five object-oriented design principles used to create maintainable, scalable, and loosely coupled software. For someone working toward an architectural role in .NET systems, these principles are fundamental because they guide how you structure classes, services, and dependencies.

## 1. Single Responsibility Principle (SRP)

A class should have only one reason to change.
It should perform one responsibility only.

Wrong design
```
public class Invoice
{
    public void CalculateTotal() { }

    public void SaveToDatabase() { }

    public void PrintInvoice() { }
}
```
This class has three responsibilities:

Business logic (calculate total)

Data access (save)

Presentation (print)

If database logic changes, the class changes. If printing changes, the class changes.

Better design
```
public class Invoice
{
    public decimal CalculateTotal() { return 0; }
}

public class InvoiceRepository
{
    public void Save(Invoice invoice) { }
}

public class InvoicePrinter
{
    public void Print(Invoice invoice) { }
}
```
Each class now has one responsibility.

Architectural impact:

easier testing

lower coupling

better maintainability
## 2. Open Closed Principle (OCP)

Software entities should be open for extension but closed for modification.

You should add new behavior without modifying existing code.

Bad example
```
public class DiscountCalculator
{
    public decimal GetDiscount(string customerType)
    {
        if (customerType == "Regular")
            return 0.1m;
        else if (customerType == "Premium")
            return 0.2m;

        return 0;
    }
}
```
If a new type appears (VIP), you must modify the method.

Better approach
```
public interface IDiscount
{
    decimal GetDiscount();
}

public class RegularCustomer : IDiscount
{
    public decimal GetDiscount() => 0.1m;
}

public class PremiumCustomer : IDiscount
{
    public decimal GetDiscount() => 0.2m;
}
```
Usage:
```
public class DiscountService
{
    public decimal CalculateDiscount(IDiscount discount)
    {
        return discount.GetDiscount();
    }
}
```
## 3. Liskov Substitution Principle (LSP)

Derived classes must be replaceable with their base class without breaking functionality.

Classic example: Rectangle vs Square problem

Wrong design
```
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int GetArea() => Width * Height;
}

public class Square : Rectangle
{
    public override int Width
    {
        set { base.Width = base.Height = value; }
    }
}
```
If code expects a Rectangle, a Square changes behavior.

Example failure:
```
Rectangle rect = new Square();
rect.Width = 5;
rect.Height = 10;

Console.WriteLine(rect.GetArea());
```
Expected = 50
Actual = 100

This violates LSP.

Correct design: avoid inheritance when behavior differs.

## 4. Interface Segregation Principle (ISP)

Clients should not be forced to depend on interfaces they do not use.

Bad interface
```
public interface IWorker
{
    void Work();
    void Eat();
}
```
Robot cannot eat.
```
public class Robot : IWorker
{
    public void Work() { }

    public void Eat()
    {
        throw new NotImplementedException();
    }
}
```
Violation.

Better design

```
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}
```
Implementation:
```
public class Human : IWorkable, IFeedable
{
    public void Work() { }
    public void Eat() { }
}

public class Robot : IWorkable
{
    public void Work() { }
}
```
Interfaces are now specific and clean.

## 5. Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules.
Both should depend on abstractions.

Bad design
```
public class EmailService
{
    public void SendEmail(string message) { }
}

public class Notification
{
    private EmailService _emailService = new EmailService();

    public void Send(string message)
    {
        _emailService.SendEmail(message);
    }
}
```
Problem:
Notification is tightly coupled to EmailService.

Better design
```
public interface IMessageService
{
    void Send(string message);
}

public class EmailService : IMessageService
{
    public void Send(string message) { }
}

public class SmsService : IMessageService
{
    public void Send(string message) { }
}
```
Dependency injection:
```
public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Send(string message)
    {
        _messageService.Send(message);
    }
}
```
Now you can inject Email, SMS, WhatsApp, Kafka, etc.

This is the foundation of modern .NET architecture (DI container).

## Real .NET Architecture Example

In ASP.NET Core Web API

Typical layering:

Controller
↓
Service
↓
Repository
↓
Database

Example:
```
Controller -> IOrderService -> OrderService
OrderService -> IOrderRepository -> OrderRepository
```
Principles applied:

SRP → each layer has one responsibility

OCP → new implementations added without changing services

LSP → implementations interchangeable

ISP → smaller interfaces

DIP → dependency injection

## The Architectural Insight

SOLID is not just theory. It enables:

Microservices readiness

Testable code (mocking interfaces)

Loose coupling

Replaceable infrastructure

Large team scalability

Without SOLID, systems become rigid and fragile.
