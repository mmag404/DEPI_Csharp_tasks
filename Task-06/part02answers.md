The main difference between **class** and **struct** in C# is how they are stored and used in memory.

---

## 1. Memory type

### class

- Reference type
    
- Stored in **heap**
    
- Variable stores a **reference (address)** to the object
    

Example:

`class Person {     public string Name; }  Person p1 = new Person(); Person p2 = p1;  p2.Name = "Ali";  // p1.Name is also "Ali"`

Both refer to the same object.

---

### struct

- Value type
    
- Stored in **stack** (usually)
    
- Variable stores the **actual data**
    

Example:

`struct Point {     public int X; }  Point p1 = new Point(); Point p2 = p1;  p2.X = 10;  // p1.X is still 0`

Each has its own copy.

---

## 2. Copy behavior

|Type|Copy behavior|
|---|---|
|class|copies reference|
|struct|copies value|

---

## 3. Inheritance

### class

- Supports inheritance
    

`class Animal {} class Dog : Animal {}`

### struct

- Does NOT support inheritance
    
- Cannot inherit from another struct or class
    
- Can implement interfaces
    

---

## 4. Default constructor

### class

- Can have custom default constructor
    

### struct

- Cannot define parameterless constructor manually (before C# 10)
    
- Always has implicit default constructor
    

---

## 5. Null support

### class

Can be null:

`Person p = null;`

### struct

Cannot be null (unless nullable):

`Point p; // not null Point? p2 = null; // nullable struct`

---

## 6. Performance and usage

Use **struct** when:

- Small data
    
- Simple data container
    
- Like Point, Color, Vector
    

Use **class** when:

- Large objects
    
- Need inheritance
    
- Complex behavior
    
- Most real-world objects






---
---
# 1. Inheritance (IS-A relationship)

Means one class **is a type of another class**.

Example:


```cs
class Animal { }  class Dog : Animal { }
```

Dog **IS-A** Animal.

Use when there is a natural hierarchy.

---

# 2. Association (USES-A relationship)

Means one class **uses another class**, but both can exist independently.

Example:

```cs
class Driver
{
    public void Drive(Car car)
    {
        Console.WriteLine("Driver drives the car");
    }
}

class Car { }

```

Driver **uses** Car, but Driver can exist without Car.

Loose relationship.

---

# 3. Aggregation (HAS-A relationship, weak ownership)

Means one class **has another class as a part**, but the part can exist independently.

Example:

```cs
class Engine { }

class Car
{
    public Engine Engine;

    public Car(Engine engine)
    {
        Engine = engine;
    }
}

```

Car **HAS-A** Engine  
But Engine can exist without Car.

Weak ownership.

---

# 4. Composition (HAS-A relationship, strong ownership)

Means one class **contains another class**, and the contained object cannot exist without it.

Example:

```cs
class Engine { }

class Car
{
    private Engine engine;

    public Car()
    {
        engine = new Engine();
    }
}

```

Engine belongs only to Car.  
If Car is destroyed, Engine is destroyed too.

Strong ownership.

---

# 5. Dependency (DEPENDS-ON relationship)

Means one class depends on another temporarily.

Example:

```cs
class Printer
{
    public void Print(Document doc)
    {
        Console.WriteLine("Printing document");
    }
}

class Document { }

```

Printer depends on Document only during method execution.

Weakest relationship.