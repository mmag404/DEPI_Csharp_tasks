# Coding against interface rather than class

It means:

> Use the interface type in your variables, parameters, and design instead of using the concrete class directly.

##  Coding against class (BAD design)

```cs
class EmailService
{
    public void Send(string msg)
    {
        Console.WriteLine("Sending Email: " + msg);
    }
}

class Notification
{
    private EmailService emailService = new EmailService();

    public void Notify()
    {
        emailService.Send("Hello");
    }
}

```

### Problem:

Notification is tightly coupled to EmailService.

You cannot easily switch to:

- SMSService
    
- PushNotificationService
    
- MockService (for testing)
    

You must modify Notification itself.

This violates flexibility.

---

## Coding against interface (GOOD design)

```cs
interface IMessageService
{
    void Send(string msg);
}

class EmailService : IMessageService
{
    public void Send(string msg)
    {
        Console.WriteLine("Email: " + msg);
    }
}

class SMSService : IMessageService
{
    public void Send(string msg)
    {
        Console.WriteLine("SMS: " + msg);
    }
}

class Notification
{
    private IMessageService messageService;

    public Notification(IMessageService service)
    {
        messageService = service;
    }

    public void Notify()
    {
        messageService.Send("Hello");
    }
}

```

Usage:

```cs
Notification n = new Notification(new EmailService());
n.Notify();

Notification n2 = new Notification(new SMSService());
n2.Notify();

```

No modification needed in Notification.

This is flexible design.

---

#  Coding against abstraction not concreteness

This is the same idea but broader.

Abstraction can be:

- interface
    
- abstract class
    

Concreteness means:

- specific implementation class
    

---

##  Coding against concreteness

`Rectangle rect = new Rectangle();`

You tied your code to Rectangle.

---

##  Coding against abstraction

`Shape shape = new Rectangle();`

Now your code works with any Shape:

`shape = new Circle(); shape = new Triangle();`

No code change required.

---

#  Real-world analogy

Bad design:

"Bring me a Samsung phone"

Good design:

"Bring me a phone"

Now you can use:

- Samsung
    
- iPhone
    
- Xiaomi
    

Your system doesn't break.

---

#  Why this principle is important

This gives you:

### Flexibility

Switch implementations easily

### Loose coupling

Classes are independent

### Testability

You can inject mock objects

`class FakeService : IMessageService {     public void Send(string msg)     {         Console.WriteLine("Fake");     } }`

### Maintainability

Less modification needed

---

#  This is directly related to SOLID principles

Specifically:

## Dependency Inversion Principle (D)

> High-level modules should not depend on low-level modules.  
> Both should depend on abstractions.








---
---

## What is Abstraction as a Guideline and How Can We Implement It?

### Definition of Abstraction as a Guideline

Abstraction is a design guideline in Object-Oriented Programming (OOP) that means focusing on the essential behavior of an object while hiding the implementation details. It encourages developers to depend on abstractions (such as interfaces or abstract classes) instead of concrete classes.

The main goal of abstraction is to reduce coupling between components, improve flexibility, and make the system easier to maintain and extend.

Instead of interacting with specific implementations, abstraction allows programs to interact with general contracts that define what an object can do, without knowing how it does it.

---

### Why Abstraction is Important

Abstraction provides several benefits:

1. **Reduces coupling** between classes.
    
2. **Improves flexibility**, allowing implementations to be changed easily.
    
3. **Enhances maintainability**, since changes in one class do not affect others.
    
4. **Supports polymorphism**, allowing multiple implementations of the same abstraction.
    
5. **Improves scalability**, making systems easier to expand.
    

---

### How to Implement Abstraction

Abstraction can be implemented using:

- Interfaces
    
- Abstract classes
    
- Polymorphism and inheritance
    

---

### Example Using Interface in C#

```cs
interface IMessageService
{
    void Send(string message);
}

class EmailService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Email: " + message);
    }
}

class SMSService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine("Sending SMS: " + message);
    }
}

class Notification
{
    private IMessageService messageService;

    public Notification(IMessageService service)
    {
        messageService = service;
    }

    public void Notify()
    {
        messageService.Send("Hello");
    }
}

```

---

### Explanation

In this example:

- `IMessageService` is an abstraction.
    
- `EmailService` and `SMSService` are concrete implementations.
    
- `Notification` depends on the abstraction, not on a specific class.
    

This allows different message services to be used without modifying the Notification class.