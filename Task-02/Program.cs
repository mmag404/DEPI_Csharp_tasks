using System;

namespace task1
{
    class Person
{
    public string Name;
}
    class Program
    {
        static void Main(string[] args)
        {

            #region 
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            try
            {
                int number1 = int.Parse(input);
                Console.WriteLine("Using int.Parse: " + number1);

                int number2 = Convert.ToInt32(input);
                Console.WriteLine("Using Convert.ToInt32: " + number2);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The input is not a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The number is too large or too small for Int32.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }



            // Difference between int.Parse and Convert.ToInt32 when handling null inputs
            // int.Parse is strict and throws an exception for null.
            // Convert.ToInt32 is more tolerant and returns 0 for null input.

            #endregion

            #region TryParse Example and Theoretical Explanation

// Application:

Console.Write("Enter a number: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    Console.WriteLine("Valid number: " + number);
}
else
{
    Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
}


// Theoretical Question:
// Why is TryParse recommended over Parse in user-facing applications?

// 1) TryParse does NOT throw exceptions for invalid input.
//    It returns true if conversion succeeds and false otherwise.

// 2) It avoids using exceptions for normal control flow,
//    which improves performance.

// 3) It provides safer input validation when dealing with user input.

// 4) It prevents application crashes caused by unhandled exceptions.

// In short:
// TryParse is safer, cleaner, and more efficient for user input handling.

#endregion



#region Object Assignment and GetHashCode Explanation

// Application:

object obj;

// Assign int
obj = 10;
Console.WriteLine("Value: " + obj + " | Type: " + obj.GetType() + " | HashCode: " + obj.GetHashCode());

// Assign string
obj = "Hello";
Console.WriteLine("Value: " + obj + " | Type: " + obj.GetType() + " | HashCode: " + obj.GetHashCode());

// Assign double
obj = 3.14;
Console.WriteLine("Value: " + obj + " | Type: " + obj.GetType() + " | HashCode: " + obj.GetHashCode());


// Theoretical Question:
// Explain the real purpose of the GetHashCode() method.

// 1) GetHashCode() returns an integer that represents a hash value of the object.

// 2) The main purpose is to provide a fast way to compare and store objects
//    in hash-based collections like Dictionary, HashSet, and Hashtable.

// 3) Objects that are equal (according to Equals method) must return
//    the same hash code.

// 4) It is NOT meant to be a unique identifier for an object.
//    Different objects can have the same hash code (hash collision).



#endregion


#region Reference Behavior and Reference Equality Explanation

// Application:

// Create a reference type (class)


// Create object and assign value
Person p1 = new Person();
p1.Name = "Mohamed";

// Create second reference to the same object
Person p2 = p1;

// Modify value using first reference
p1.Name = "Magdy";

// Print value using second reference
Console.WriteLine("Value from p2: " + p2.Name);



// Theoretical Question:
// What is the significance of reference equality in .NET?

// 1) Reference equality means two variables point to the same memory location.

// 2) In .NET, reference types store the address of the object in the heap,
//    not the actual object itself.

// 3) If two references are equal (ReferenceEquals returns true),
//    modifying the object through one reference affects the other.

// 4) This is important when working with classes, collections,
//    dependency injection, and object sharing.

 

#endregion

#region String Immutability and GetHashCode Demonstration

// Application:

string text = "Hello";

// Print hash code before modification
Console.WriteLine("Before modification:");
Console.WriteLine("Value: " + text);
Console.WriteLine("HashCode: " + text.GetHashCode());

// Modify string by concatenation
text += " Hi Willy";

// Print hash code after modification
Console.WriteLine("\nAfter modification:");
Console.WriteLine("Value: " + text);
Console.WriteLine("HashCode: " + text.GetHashCode());


// Theoretical Question:
// Why is string immutable in C#?

// 1) Security:
//    Strings are widely used for sensitive data (e.g., passwords, file paths).
//    Immutability prevents accidental modification.

// 2) Thread Safety:
//    Since strings cannot change, multiple threads can safely use
//    the same string instance without synchronization.

// 3) Performance Optimization (String Interning):
//    The CLR can store identical string literals in a shared pool.
//    Because strings are immutable, they can safely be reused.

// 4) Hashing Stability:
//    Strings are often used as keys in Dictionary or HashSet.
//    If strings were mutable, changing them would break hash-based collections.

 

#endregion

#region StringBuilder Demonstration and Explanation

// Application:

using System.Text;

StringBuilder sb = new StringBuilder("Hi");

// Print hash code before modification
Console.WriteLine("Before modification:");
Console.WriteLine("Value: " + sb.ToString());
Console.WriteLine("HashCode: " + sb.GetHashCode());

// Append text
sb.Append(" Willy");

// Print hash code after modification
Console.WriteLine("\nAfter modification:");
Console.WriteLine("Value: " + sb.ToString());
Console.WriteLine("HashCode: " + sb.GetHashCode());


// Theoretical Question:
// How does StringBuilder address the inefficiencies of string concatenation?

// 1) Strings are immutable.
//    Every time you concatenate a string, a new object is created in memory.

// 2) StringBuilder is mutable.
//    It modifies the same internal character buffer instead of creating new objects.

// 3) This reduces memory allocations and garbage collection pressure.

// 4) It improves performance significantly when performing many string modifications
//    such as loops, large text processing, or dynamic content generation.

#endregion

#region Why StringBuilder is Faster for Large-Scale String Modifications

// 1) Strings are immutable.
//    Every concatenation creates a NEW string object in memory.

// 2) Creating many temporary string objects increases:
//    - Memory allocations
//    - Garbage collection pressure
//    - CPU usage

// 3) StringBuilder is mutable.
//    It modifies the same internal character buffer instead of
//    creating new objects each time.

// 4) It dynamically resizes its internal buffer efficiently,
//    reducing unnecessary memory copying.

// 5) This makes StringBuilder much more efficient
//    when performing many concatenations (e.g., inside loops).


#endregion

#region String Formatting Methods Demonstration and Explanation

// Application:

Console.Write("Enter first number: ");
int input1 = int.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
int input2 = int.Parse(Console.ReadLine());

int sum = input1 + input2;

// 1) Concatenation (+ operator)
Console.WriteLine("Concatenation: Sum is " + input1 + " + " + input2 + " = " + sum);

// 2) Composite Formatting (string.Format)
Console.WriteLine("Composite Formatting: " + 
    string.Format("Sum is {0} + {1} = {2}", input1, input2, sum));

// 3) String Interpolation ($)
Console.WriteLine($"Interpolation: Sum is {input1} + {input2} = {sum}");


// Theoretical Question:
// Which string formatting method is most used and why?

// String interpolation ($"...") is the most commonly used method today.

// Reasons:
// 1) It is more readable and clean.
// 2) It reduces formatting mistakes compared to indexed placeholders.
// 3) It is easier to maintain and modify.
// 4) It is optimized by the compiler and generally performs
//    as well as or better than traditional concatenation in most cases.

// Important Performance Note:
// Repeated string concatenation (especially inside loops)
// creates many temporary string objects due to string immutability.
// For heavy string modifications, StringBuilder is more efficient.

// In short:
// String interpolation is preferred because it is clearer,
// maintainable, and efficiently optimized in modern C#.

#endregion
#region StringBuilder Operations and Explanation

using System.Text;

// Application:

StringBuilder sb = new StringBuilder("Hi Willy");

// Append text
sb.Append(" Welcome");
Console.WriteLine("After Append: " + sb.ToString());

// Replace a substring
sb.Replace("Willy", "Magdy");
Console.WriteLine("After Replace: " + sb.ToString());

// Insert a string at a specific position
sb.Insert(0, "Hello! ");
Console.WriteLine("After Insert: " + sb.ToString());

// Remove a portion of text (remove 6 characters starting from index 0)
sb.Remove(0, 6);
Console.WriteLine("After Remove: " + sb.ToString());


// Theoretical Question:
// Explain how StringBuilder is designed to handle frequent modifications
// compared to strings.

// 1) Strings are immutable.
//    Every modification creates a NEW string object in memory.

// 2) StringBuilder is mutable.
//    It modifies the same internal character buffer instead of
//    creating new objects.

// 3) It maintains a resizable internal buffer (character array)
//    that grows when needed, reducing memory reallocations.

// 4) This minimizes:
//    - Temporary object creation
//    - Garbage collection pressure
//    - Memory copying operations

// 5) As a result, StringBuilder is much more efficient
//    for frequent or large-scale string modifications.


#endregion









        }
    }
}
