
# part 02:
### 2) What is `enum` in C#?

An **enum (enumeration)** is a value type that defines a set of named constants.

It makes your code more readable and type-safe by replacing “magic numbers” with meaningful names.

Example:

`enum Day {     Monday,     Tuesday,     Wednesday,     Thursday,     Friday,     Saturday,     Sunday }`

By default:

- The underlying type is `int`
    
- Values start from `0` unless specified otherwise
    

You can also define custom values:

`enum Status {     Success = 1,     Failed = 2,     Pending = 3 }`

---

### When is enum used?

Enums are used when:

1. You have a fixed set of related constant values.
    
2. You want to improve readability.
    
3. You want type safety instead of using raw integers.
4. 
    
4. You want to restrict possible values to a predefined list.
    

For example:

- Order status
    
- User roles
    
- Days of week
    
- File access modes
    
- HTTP methods
    

Instead of:

`int status = 1; // what is 1?`

You use:

`Status status = Status.Success;`

Much clearer and safer.

---

### Three Common Built-in Enums in .NET

Here are three frequently used built-in enums:

1. **DayOfWeek**
    
    - Represents days (Sunday, Monday, etc.)
        
    - Used with `DateTime.Now.DayOfWeek`
        
2. **ConsoleColor**
    
    - Used to change console text color
        
    - Example:
        
        `Console.ForegroundColor = ConsoleColor.Green;`
        
3. **FileMode**
    
    - Used when working with files (Create, Open, Append, etc.)
        
    - Used in file streams



# 3)

## Use **string** when:

1. **The text will not change**
    
    - Configuration values
        
    - Messages
        
    - Constants
        
    - Small concatenations
        
2. **Few modifications**
    
    - One or two concatenations
        
    - Simple formatting with interpolation
        
3. **Readability matters more than performance**
    
    - Most normal application code
        
4. **You need immutability**
    
    - Safer in multi-threaded environments
        
    - Safe as dictionary keys
        

Example:

`string message = "Hello " + name;`

For small operations like this, `string` is perfectly fine and often optimized by the compiler.

---

##  Use **StringBuilder** when:

1. **Frequent modifications**
    
    - Inside loops
        
    - Repeated appending
        
2. **Large text construction**
    
    - Building HTML
        
    - Generating reports
        
    - Creating logs
        
    - Processing large files
        
3. **Performance-critical code**
    
    - High memory usage scenarios
        
    - Heavy concatenation operations
        

Example:


```
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 10000; i++) {
     sb.Append(i);
}  
string result = sb.ToString();
```

If you used `string +=` in that loop, you'd create thousands of temporary string objects.





# self study

`string.Format` is **not magically avoiding allocations**.  
It still returns a **new string** because `string` is immutable.

The real difference is **how many temporary strings get created before the final result**.

---

#  What Happens With `+` Concatenation?

Example:

`string result = "Sum is " + a + " + " + b + " = " + sum;`

### Conceptually (simplified view):

The compiler may translate it roughly like this:

`string temp1 = "Sum is " + a; string temp2 = temp1 + " + "; string temp3 = temp2 + b; string temp4 = temp3 + " = "; string result = temp4 + sum;`

Each step:

- Creates a new string object
    
- Copies previous content
    
- Allocates new memory
    
- Leaves old strings for GC
    

⚠ If this happens repeatedly (especially inside loops), you create many temporary objects.

---

#  What Happens With `string.Format`?

Example:

`string result = string.Format("Sum is {0} + {1} = {2}", a, b, sum);`

Internally:

1. It parses the format string.
    
2. Converts arguments to string representations.
    
3. Allocates the required buffer size.
    
4. Builds the final string in a more structured way.
    
5. Returns **one final string**.
    

So instead of multiple intermediate concatenations, it:

- Processes arguments
    
- Builds output more directly
    
- Produces fewer temporary intermediate strings
    

Still:  
 It allocates a new string  
 It copies characters  
 It returns a new immutable object

But it avoids repeated partial builds.





## What is `.rdata` section?

In a compiled Windows executable (PE file format), `.rdata` stands for:

> **Read-Only Data Section**

It stores **constant, immutable, or read-only data** used by the program.

---

#  What is stored inside `.rdata`?

Typically:

1. **String literals**
    
    `string s = "Hello";`
    
    The literal `"Hello"` is stored in a read-only section.
    
2. **Constant data**
    
    - `const` values
        
    - Static readonly metadata
        
3. **Import tables**
    
    - References to external DLL functions
        
4. **Virtual tables (vtable)**
    
    - Used for polymorphism in C++
        

---

#  Why are string literals in `.rdata`?

Because:

- Strings are immutable.
    
- They should not be modified.
    
- Marking memory as read-only:
    
    - Improves security
        
    - Prevents accidental overwrites
        
    - Allows sharing memory safely
        

---

#  In C# specifically

Important nuance:

C# compiles to **IL (Intermediate Language)**, not directly to machine code.

So:

- String literals are stored in **metadata inside the assembly**.
    
- At runtime, the CLR loads them.
    
- They may live in:
    
    - Intern pool
        
    - Managed heap
        

The `.rdata` section is more directly relevant when:

- You inspect the compiled native image (NGen / ReadyToRun)
    
- Or you're looking at C/C++ compiled binaries



### What is a User-Defined Constructor?

A **user-defined constructor** is a constructor that you explicitly write inside a class to initialize its objects.

In C#, if you don’t write any constructor, the compiler automatically provides a **default parameterless constructor**.

But when you define your own constructor, you control how the object is initialized.

---

### Example

```
class Person { 
public string Name; 
public int Age;  // User-defined constructor   
public Person(string name, int age)     
{         Name = name;         Age = age;     }
}
```

Usage:

`Person p = new Person("Mohamed", 21);`

Here, the constructor ensures:

- The object cannot exist without a name and age.
    
- The object starts in a valid state.
    

---

### Role in Initialization

The constructor’s main role is:

1. **Initialize object fields**
    
    - Assign values to variables.
        
    - Set default states.
        
2. **Enforce required data**
    
    - Prevent creating incomplete objects.
        
3. **Allocate resources**
    
    - Open files
        
    - Initialize collections
        
    - Set up connections (if needed)
        
4. **Guarantee object validity**
    
    - Ensure the object is ready for use immediately after creation.
        

---

### Important Concept

If you define any constructor manually:

`public Person(string name)`

The compiler will NOT generate the default constructor automatically.

So this will fail:

`Person p = new Person(); // Error if no parameterless constructor exists`

Unless you explicitly define:

`public Person() { }`









# array vs linkedlist
# 1️ Memory Layout

### 🔹 Array

- Stored in **contiguous memory**.
    
- Elements are placed next to each other.
    
- Size is fixed (in most languages like C#, Java).
    

### 🔹 Linked List

- Stored in **non-contiguous memory**.
    
- Each node contains:
    
    - Data
        
    - Pointer/reference to next node
        
- Nodes can be anywhere in memory.
    

---

# 2️Access Time

### 🔹 Array → O(1)

Direct indexing:

`arr[5]`

Uses address calculation:

`base_address + (index × element_size)`

Very fast random access.

### 🔹 Linked List → O(n)

To access element at position 5:

- Must traverse from head.
    
- No direct indexing.
    

---

# 3️ Insertion & Deletion

### 🔹 Array

- Inserting in middle → O(n)
    
- Need to shift elements.
    
- Expensive operation.
    

### 🔹 Linked List

- Insertion after known node → O(1)
    
- No shifting required.
    
- Just update pointers.
    

But:

- Finding position first → O(n)
    

---

# 4️ Memory Overhead

### 🔹 Array

- No extra memory per element.
    
- Very memory efficient.
    

### 🔹 Linked List

- Extra memory per node for pointer/reference.
    
- More overhead.
    

---

# 5️ Cache Performance

### 🔹 Array

- Cache-friendly.
    
- Excellent CPU locality.
    
- Faster in practice.
    

### 🔹 Linked List

- Poor cache locality.
    
- Nodes scattered in memory.
    
- Slower traversal.
    

---

# 6️ Size Flexibility

### 🔹 Array

- Fixed size (unless dynamic like List  which resizes internally).
    

### 🔹 Linked List

- Dynamic size.
    
- Easy to grow/shrink.
    

---

# 🔥 Complexity Summary

|Operation|Array|Linked List|
|---|---|---|
|Access by index|O(1)|O(n)|
|Insert at end|O(1)*|O(1)|
|Insert in middle|O(n)|O(1)**|
|Delete|O(n)|O(1)**|
|Memory usage|Low|Higher|

* if space available  
** if node already known

---

#  When to Use What?

### Use Array when:

- You need fast indexing.
    
- Data size is known.
    
- Performance matters.
    
- You need good cache locality.
    

### Use Linked List when:

- Frequent insertions/deletions.
    
- Size changes often.
    
- No need for random access.





