##  Parallel Programming and Concurrency

### 1.1 Introduction

Modern software systems must handle large workloads, multiple users, and real-time processing. To achieve high performance and responsiveness, developers use **Concurrency** and **Parallel Programming** techniques.

Although these terms are related, they are not the same.

---

## 1.2 Concurrency

### Definition

Concurrency is the ability of a program to handle multiple tasks **at the same time (logically)**. It does not necessarily mean tasks are executed simultaneously, but they make progress during overlapping time periods.

### Example

A web server handling multiple client requests:

- While waiting for one request’s database response,
    
- It can start processing another request.
    

### Key Characteristics

- Improves responsiveness.
    
- Useful for I/O-bound systems.
    
- Can run on single-core or multi-core CPUs.
    
- Uses threads, processes, or event loops.
    

### Common Concurrency Concepts

- Threads
    
- Processes
    
- Context Switching
    
- Race Conditions
    
- Deadlocks
    
- Critical Sections
    
- Synchronization (mutex, semaphore, locks)
    

### Example (C# Thread Example)

```cs
Thread t1 = new Thread(Task1);  
Thread t2 = new Thread(Task2);  
  
t1.Start();  
t2.Start();
```

Here, both tasks run concurrently.

---

## 1.3 Parallel Programming

### Definition

Parallel programming is executing multiple tasks **simultaneously** using multiple CPU cores.

### Key Difference from Concurrency

- Concurrency = managing multiple tasks
    
- Parallelism = executing multiple tasks at the same time
    

### Example

Splitting a large array into parts and processing each part on a different CPU core.

### Use Cases

- Scientific computing
    
- Machine learning
    
- Image processing
    
- Big data processing
    

### Example (C# Parallel.For)

```cs
Parallel.For(0, 1000, i =>  
{  
    Console.WriteLine(i);  
});
```
This distributes iterations across multiple CPU cores.

---

## 1.4 Problems in Concurrency and Parallelism

1. **Race Condition**  
    Occurs when multiple threads modify shared data simultaneously.
    
2. **Deadlock**  
    Two or more threads wait forever for each other.
    
3. **Starvation**  
    A thread never gets CPU time.
    
4. **Livelock**  
    Threads keep changing states but never progress.
    

---

## 1.5 Synchronization Techniques

- `lock` keyword (C#)
    
- Mutex
    
- Semaphore
    
- Monitor
    
- Atomic operations
    

Example:

```cs
lock(sharedObject)  
{  
    counter++;  
}
```

---

#  Unit Testing and Test-Driven Development (TDD)

---

## 2.1 Unit Testing

### Definition

Unit testing is testing **individual components (functions or methods)** of a program independently.

### Purpose

- Ensure each function works correctly.
    
- Detect bugs early.
    
- Improve code reliability.
    
- Facilitate refactoring.
    

### Example (C# using xUnit)

```cs
[Fact]  
public void Add_ReturnsCorrectSum()  
{  
    var calc = new Calculator();  
    var result = calc.Add(2, 3);  
    Assert.Equal(5, result);  
}
```

---

## 2.2 Benefits of Unit Testing

- Faster debugging
    
- Safer refactoring
    
- Documentation of behavior
    
- Higher software quality
    
- Continuous Integration support
    

---

## 2.3 Test-Driven Development (TDD)

### Definition

TDD is a development methodology where tests are written **before** writing the actual code.

### TDD Cycle (Red-Green-Refactor)

1. 🔴 Red – Write a failing test
    
2. 🟢 Green – Write minimal code to pass the test
    
3. 🔵 Refactor – Improve the code while keeping tests passing
    

### Example Workflow

1. Write test:
    

```cs
Assert.Equal(5, calc.Add(2,3));
```

2. Implement minimal code:
    

```cs
public int Add(int a, int b)  
{  
    return a + b;  
}
```

3. Refactor if necessary.
    

---

## 2.4 Advantages of TDD

- Cleaner design
    
- Reduced bugs
    
- High maintainability
    
- Better modular code
    
- Encourages thinking before coding
    

---

## 2.5 Common Testing Frameworks

- NUnit
    
- xUnit
    
- MSTest
    
- JUnit (Java)
    
- pytest (Python)
    

---

#  Asynchronous Programming with async and await

---

## 3.1 Introduction

Asynchronous programming allows programs to perform **non-blocking operations**, especially useful for I/O-bound tasks such as:

- File operations
    
- Database calls
    
- API requests
    
- Network communication
    

---

## 3.2 Problem with Synchronous Code

Synchronous code blocks execution until the operation completes.

Example:

```cs
var data = GetData(); // waits until finished
```

If the operation takes 5 seconds, the program waits 5 seconds.

---

## 3.3 Asynchronous Solution

Using `async` and `await` allows the program to continue execution without blocking the main thread.

### Example (C#)

```cs
public async Task<string> GetDataAsync()  
{  
    HttpClient client = new HttpClient();  
    var response = await client.GetStringAsync("https://example.com");  
    return response;  
}
```

### How It Works

- `async` marks a method as asynchronous.
    
- `await` pauses the method without blocking the thread.
    
- Control returns to caller until operation completes.
    

---

## 3.4 Benefits of Async/Await

- Better performance for I/O-bound tasks
    
- Improved responsiveness (especially in UI apps)
    
- Scalable web servers
    
- Cleaner syntax compared to callbacks
    








