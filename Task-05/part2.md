# What is copy constructor?
A **copy constructor** is a constructor that creates a new object by copying the data from another object of the same type.

In simple words:

> It builds a new object using an existing object.

C# does **not automatically create a copy constructor**

```cs
public class Person
{
    public string Name;

    public Person(string name)
    {
        Name = name;
    }

    // Copy constructor
    public Person(Person other)
    {
        Name = other.Name;
    }
}

```

Usage:
```cs
Person p1 = new Person("Ali");
Person p2 = new Person(p1);   
```

### Why is it important?

- To create a **separate object** with the same data.
    
- To avoid sharing the same reference.
    
- To control how copying happens (especially with complex objects).

------
---









# What is an Indexer in C#?

An **Indexer** is a special member in a class or struct that allows an object to be accessed like an array using square brackets `[]`.

It lets you do this:

`obj[index]`

instead of:

`obj.GetItem(index);`

---

### 🔹 Simple Example

```cs
public class Department
{
    private string[] employees = new string[3];

    public string this[int index]
    {
        get { return employees[index]; }
        set { employees[index] = value; }
    }
}

```

Usage:

```cs
Department dept = new Department();
dept[0] = "Ali";
Console.WriteLine(dept[0]);

```
---

##  When is Indexer Used?

You use an indexer when your object:

- Represents a **collection of data**
    
- Needs to behave like an **array**
    
- Stores elements internally (array, list, dictionary, etc.)
    

---

##  Business Use Cases (Real-World Scenarios)

### 1️ Custom Collection Class

If you build your own:

- `StudentCollection`
- `ProductCatalog`
- `OrderList`


You use indexer so developers can write:

`students[5] products[10]`

instead of calling methods.

---

### 2️ Data Containers (Matrix / Grid Systems)

In:
- Financial systems (2D pricing tables)
- Game development (grid maps)
- Inventory systems
Example:

`matrix[2,3]`

---

### 3️ Dictionary-like Access

If your class stores data by key:

`settings["Theme"] employee["Salary"]`

Used in:

- Configuration systems    
- Dynamic data models
- Business rule engines
    

---

### 4️ Domain Models That Logically Represent Indexed Data

For example:
- A `Week` class → access days by index
- A `Library` class → access books by ID
- A `Warehouse` → access item by code

---

## 🔹 Why Not Just Use Methods?

Without indexer:
`dept.GetEmployee(0);`

With indexer:
`dept[0];`

Cleaner. More readable. More natural.


---
---
# 🔹 Access Modifiers (AM)

Control visibility and scope of members.

### The 6 in C#:

- `private` → only inside same class/struct
    
- `protected` → accessible in inheritance
    
- `internal` → accessible inside same project
    
- `protected internal` → same project OR derived class
    
- `private protected` → derived class inside same project
    
- `public` → accessible everywhere
    

Defaults:

- Inside **namespace** → `internal`
    
- Inside **class/struct** → `private`
    

---

#  Namespace Scope

Inside namespace you can define:

- `class`
    
- `struct`
    
- `interface`
    
- `enum`
    

Allowed AM at namespace level:

- `public`
    
- `internal`
    

---

# 🔹 OOP (Object-Oriented Programming)

A way to design software by modeling real-world entities.

Each entity has:

- **State** → data (attributes)
    
- **Behavior** → methods
    

### OOP Relationships

- **Is-A** → Inheritance
    
- **Has-A** → Aggregation / Composition
    

### 4 Pillars

1. Encapsulation
    
2. Inheritance
    
3. Polymorphism
    
4. Abstraction
    

Goal: Clean, maintainable, scalable design.

---

# 🔹 Struct

- Value type
    
- Usually stored on stack
    
- Does NOT support inheritance
    
- Supports constructor overloading
    
- Has implicit default constructor
    
- Can override methods like `ToString()`
    

Used for small, lightweight data.

---

# 🔹 Class

- Reference type
    
- Stored on heap
    
- Supports inheritance
    
- Supports all access modifiers
    
- Used for complex objects
    

---

# 🔹 Constructors

- Special method used to initialize object
    
- Same name as type
    
- Called using `new`
    
- Can be overloaded
    

---

#  Encapsulation

Separating data from direct access.

Steps:

- Make fields `private`
    
- Use:
    
    - Getter / Setter
        
    - Full Property
        
    - Auto Property
        
    - Indexer
        

Purpose:

- Protect data
    
- Add validation
    
- Improve maintainability
    

