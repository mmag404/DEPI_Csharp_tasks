## 1) Upcasting and Downcasting

### Upcasting

Upcasting is when we convert a derived class object to a base class reference.

Example:

```cs
Animal a = new Dog();
```

This is automatic and safe.  
Because Dog inherits from Animal, so every Dog is an Animal.

Why we use it:  
When we want general behavior. For example, if we have many types like Dog, Cat, Bird, we can store them all in a list of Animal and treat them in a common way.

---

### Downcasting

Downcasting is converting base reference back to derived type.

Example:

``` cs
Animal a = new Dog(); Dog d = (Dog)a;
```

This needs explicit casting.  
If the object is not actually a Dog, it throws InvalidCastException.

Safer way:

``` cs
if (a is Dog d) {     // safe use }
```

We use downcasting when we need child-specific functionality after storing it as base type.

---

## 2) Custom Exception and Real Business Use Cases

Built-in exceptions are good for system errors like null reference or divide by zero.  
But in real applications, we have business rules.

Examples of business cases:

- Bank system → withdraw more than balance.
    
- E-commerce → order with invalid payment.
    
- Login system → account is blocked.
    
- Registration → age not allowed.
    
- Inventory system → product out of stock.
    

These are not system crashes.  
They are logical rule violations.

So we create custom exceptions to represent them clearly.
``` cs
class ProductOutOfStockException : Exception
{
    public ProductOutOfStockException(string message) : base(message) { }
}


try
{
    int stock = 0;

    if (stock <= 0)
        throw new ProductOutOfStockException("Product not available");

    Console.WriteLine("Order completed");
}
catch (ProductOutOfStockException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Process ended");
}
```
---

### Try – Catch – Finally (Real Practical Meaning)

- `try` → code that might fail
    
- `catch` → handle the error
    
- `finally` → always runs no matter what
    

Finally is very important in real systems.

Common real use cases:

- Closing database connection
    
- Closing file streams
    
- Releasing unmanaged resources
    
- Logging operations
    
- Cleaning memory
    
- Finishing API request handling
    

Example cases where try-catch-finally is used:

1. Database connection  
    Open connection in try  
    Close connection in finally
    
2. File handling  
    Open file in try  
    Close file in finally
    
3. API calls  
    Call external API in try  
    Log response or clean up in finally
    

The idea is: even if error happens, resources must be released.










## 3) Global Exception Handling (Middleware in Web Apps)

In console apps, we use try-catch locally.

But in web applications (like ASP.NET Core), writing try-catch in every controller method is bad practice.

Instead, we use global exception middleware.

Why?

- Centralized error handling
    
- No repeated try-catch everywhere
    
- Cleaner code
    
- Better logging
    
- Unified error response format
    
- Security (no stack trace exposed to user)
    

Example idea:

When user sends request:  
Request → Middleware → Controller → Database/API

If any exception happens anywhere, middleware catches it.

This is very important especially when dealing with:

- Database queries
    
- External API calls
    
- File uploads/downloads
    
- Payment gateways
    
- Authentication services
    

In large systems, global error handling makes the app stable and professional.