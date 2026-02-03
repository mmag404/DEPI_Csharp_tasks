using System;
using System.IO;

namespace task1
{
    

    class Program
    {
        static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
        static void Main(string[] args)
        {
            #region 

        // -------------------------------
        // 1) Initialize arrays in 3 ways
        // -------------------------------

        // Method 1: Using new int[size]
        int size = 5;
        int[] arr1 = new int[size];

        // Assign values
        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = i + 1;
        }

        Console.WriteLine("Array 1:");
        foreach (int value in arr1)
        {
            Console.WriteLine(value);
        }

        // Method 2: Using initializer list
        int[] arr2 = new int[] { 10, 20, 30, 40, 50 };

        Console.WriteLine("\nArray 2:");
        foreach (int value in arr2)
        {
            Console.WriteLine(value);
        }

        // Method 3: Array syntax sugar
        int[] arr3 = { 100, 200, 300, 400, 500 };

        Console.WriteLine("\nArray 3:");
        foreach (int value in arr3)
        {
            Console.WriteLine(value);
        }

        // --------------------------------------
        // 2) Demonstrate IndexOutOfRangeException
        // --------------------------------------
        try
        {
            Console.WriteLine("\nAccessing invalid index:");
            Console.WriteLine(arr1[10]); // Invalid index (out of bounds)
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        /*
        -----------------------------------------
        Question:
        What is the default value assigned to 
        array elements in C#?
        -----------------------------------------

        Answer:
        Array elements in C# are automatically
        initialized with default(T), depending
        on the type:

        int      -> 0
        double   -> 0.0
        bool     -> false
        char     -> '\0'
        reference types (e.g., string, object) -> null

        Example:
        int[] numbers = new int[5];
        numbers[0] will be 0 even if not assigned.
        */
            #endregion

             #region Shallow Copy vs Deep Copy Demonstration

        // ---------------------------------
        // Create two arrays (arr1 and arr2)
        // ---------------------------------

        int[] arr1 = { 1, 2, 3, 4, 5 };

        // ----------------------------
        // 1) Shallow Copy (Reference)
        // ----------------------------
        // Here arr2 points to the SAME memory location as arr1

        int[] arr2 = arr1;

        Console.WriteLine("Before modification (Shallow Copy):");
        Console.WriteLine("arr1[0] = " + arr1[0]);
        Console.WriteLine("arr2[0] = " + arr2[0]);

        // Modify arr2
        arr2[0] = 100;

        Console.WriteLine("\nAfter modifying arr2:");
        Console.WriteLine("arr1[0] = " + arr1[0]); // Changed!
        Console.WriteLine("arr2[0] = " + arr2[0]);

        // Because both refer to the same array in memory.


        // ----------------------------------------
        // 2) Deep Copy using Clone() method
        // ----------------------------------------

        int[] arr3 = { 10, 20, 30, 40, 50 };

        // Clone creates a new array object (separate memory)
        int[] arr4 = (int[])arr3.Clone();

        Console.WriteLine("\nBefore modification (Deep Copy using Clone):");
        Console.WriteLine("arr3[0] = " + arr3[0]);
        Console.WriteLine("arr4[0] = " + arr4[0]);

        // Modify arr4
        arr4[0] = 999;

        Console.WriteLine("\nAfter modifying arr4:");
        Console.WriteLine("arr3[0] = " + arr3[0]); // NOT changed
        Console.WriteLine("arr4[0] = " + arr4[0]);

        // arr3 remains unchanged because Clone() created a new array.


        /*
        ----------------------------------------------------------
        Question:
        What is the difference between Array.Clone() and Array.Copy()?
        ----------------------------------------------------------

        Answer:

        1) Array.Clone():
           - Creates a shallow copy of the entire array.
           - Returns an object, so casting is required.
           - Copies elements into a new array of the same size.

        2) Array.Copy():
           - Copies elements from one array to another.
           - Requires a destination array.
           - Allows copying part of the array.
           - Does NOT return a new array automatically.

        Important Note:
        Both Clone() and Copy() perform shallow copies.
        For value types (like int), this behaves like deep copy.
        For reference types (like objects), only references are copied.
        */

        #endregion


                #region 2D Array - Student Grades

        // Create a 2D array (3 students, 3 subjects)
        int[,] grades = new int[3, 3];

        // Take input from user
        for (int i = 0; i < grades.GetLength(0); i++) // rows (students)
        {
            Console.WriteLine($"Enter grades for Student {i + 1}:");

            for (int j = 0; j < grades.GetLength(1); j++) // columns (subjects)
            {
                Console.Write($"  Subject {j + 1}: ");
                grades[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\n--- Student Grades ---");

        // Print grades using nested loops
        for (int i = 0; i < grades.GetLength(0); i++)
        {
            Console.Write($"Student {i + 1}: ");

            for (int j = 0; j < grades.GetLength(1); j++)
            {
                Console.Write(grades[i, j] + " ");
            }

            Console.WriteLine();
        }

        /*
        ----------------------------------------------------------
        Question:
        What is the difference between GetLength() and Length
        for multidimensional arrays?
        ----------------------------------------------------------

        Answer:

        1) Length:
           - Returns the TOTAL number of elements
             in the entire array.
           - For 3x3 array → Length = 9.

        2) GetLength(dimension):
           - Returns the size of a specific dimension.
           - GetLength(0) → number of rows.
           - GetLength(1) → number of columns.

        Example for int[3,3]:
            grades.Length        → 9
            grades.GetLength(0)  → 3 (students)
            grades.GetLength(1)  → 3 (subjects)
        */

        #endregion



        #region Array Methods Demonstration

        int[] arr = { 5, 2, 8, 1, 9 };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        // -----------------------
        // 1) Sort()
        // -----------------------
        // Sort arr in ascending order
        Array.Sort(arr);

        Console.WriteLine("\nAfter Array.Sort():");
        PrintArray(arr);
        // The array elements are rearranged in ascending order.


        // -----------------------
        // 2) Reverse()
        // -----------------------
        // Reverse the array order
        Array.Reverse(arr);

        Console.WriteLine("\nAfter Array.Reverse():");
        PrintArray(arr);
        // The array elements order is reversed.


        // -----------------------
        // 3) IndexOf()
        // -----------------------
        int index = Array.IndexOf(arr, 8);

        Console.WriteLine("\nAfter Array.IndexOf(arr, 8):");
        Console.WriteLine("Index of 8 = " + index);
        // Returns the index of the element (does not modify array).


        // -----------------------
        // 4) Copy()
        // -----------------------
        int[] copyArray = new int[arr.Length];
        Array.Copy(arr, copyArray, arr.Length);

        Console.WriteLine("\nAfter Array.Copy():");
        Console.WriteLine("Copied Array:");
        PrintArray(copyArray);
        // Copies elements into another array.


        // -----------------------
        // 5) Clear()
        // -----------------------
        Array.Clear(arr, 0, arr.Length);

        Console.WriteLine("\nAfter Array.Clear():");
        PrintArray(arr);
        // Sets all elements to default value (0 for int).


        /*
        ----------------------------------------------------------
        Question:
        What is the difference between Array.Copy() and
        Array.ConstrainedCopy()?
        ----------------------------------------------------------

        Answer:

        1) Array.Copy():
           - Copies elements from one array to another.
           - If an error occurs during copying (like invalid cast),
             some elements may already have been copied.

        2) Array.ConstrainedCopy():
           - Provides transactional behavior.
           - If copying fails, NO elements are copied.
           - Ensures reliability and memory safety.

        In simple terms:
        Copy() may partially copy before failure.
        ConstrainedCopy() guarantees all-or-nothing copying.
        */

        #endregion

                #region Looping Through 1D Array

        int[] numbers = { 10, 20, 30, 40, 50 };

        // -----------------------
        // 1) Using for loop
        // -----------------------
        Console.WriteLine("Using for loop:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        // -----------------------
        // 2) Using foreach loop
        // -----------------------
        Console.WriteLine("\nUsing foreach loop:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        // -----------------------
        // 3) Using while loop (reverse order)
        // -----------------------
        Console.WriteLine("\nUsing while loop (reverse order):");
        int index = numbers.Length - 1;

        while (index >= 0)
        {
            Console.WriteLine(numbers[index]);
            index--;
        }

        /*
        ----------------------------------------------------------
        Question:
        Why is foreach preferred for read-only operations on arrays?
        ----------------------------------------------------------

        Answer:

        foreach is preferred for read-only operations because:

        1) It is safer:
           - It does not allow modification of the array elements
             directly through the loop variable.
           - Reduces risk of accidental changes.

        2) It is cleaner and more readable:
           - No need to manage index variables.
           - Less chance of index-out-of-range errors.

        3) It is more expressive:
           - Clearly indicates that we are just iterating
             over elements, not modifying structure.

        Use for loop when:
           - You need the index.
           - You need to modify elements.
           - You need custom iteration logic.

        Use foreach when:
           - You only need to read values.
        */

        #endregion


                #region Defensive Coding - Validate Positive Odd Number

        int number;
        bool isValid;

        do
        {
            Console.Write("Enter a positive odd number: ");
            string input = Console.ReadLine();

            // TryParse prevents program crash if input is not a number
            isValid = int.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Invalid input! Please enter a valid integer.\n");
                continue;
            }

            if (number <= 0)
            {
                Console.WriteLine("Number must be positive.\n");
                isValid = false;
                continue;
            }

            if (number % 2 == 0)
            {
                Console.WriteLine("Number must be odd.\n");
                isValid = false;
            }

        } while (!isValid);

        Console.WriteLine($"\nValid input received: {number}");

        /*
        ----------------------------------------------------------
        Question:
        Why is input validation important when working with user inputs?
        ----------------------------------------------------------

        Answer:

        Input validation is important because:

        1) Prevents program crashes:
           - Without validation, invalid input (like letters instead of numbers)
             can cause runtime exceptions.

        2) Improves security:
           - Prevents malicious or unexpected input that could harm
             the system or exploit vulnerabilities.

        3) Ensures data correctness:
           - Guarantees that the program works with valid, expected values.

        4) Improves user experience:
           - Provides clear feedback instead of sudden errors.

        Defensive coding (like using TryParse and loops)
        makes programs safer, more reliable, and more professional.
        */

        #endregion



        #region 2D Array - Matrix Format

        // Create a 2D array with fixed values
        int[,] matrix =
        {
            { 1,  2,  3 },
            { 4,  5,  6 },
            { 7,  8,  9 }
        };

        Console.WriteLine("Matrix Output:\n");

        // Print in matrix format (rows and columns)
        for (int i = 0; i < matrix.GetLength(0); i++) // rows
        {
            for (int j = 0; j < matrix.GetLength(1); j++) // columns
            {
                // PadRight aligns columns for better readability
                Console.Write(matrix[i, j].ToString().PadRight(5));
            }
            Console.WriteLine(); // move to next row
        }

        /*
        ----------------------------------------------------------
        Question:
        How can you format the output of a 2D array
        for better readability?
        ----------------------------------------------------------

        Answer:

        You can improve readability by:

        1) Using spacing or padding:
           - Methods like PadRight(), PadLeft()
           - Or string formatting (e.g., $"{value,5}")

        2) Printing row by row:
           - Use nested loops.
           - Add Console.WriteLine() after each row.

        3) Using tab spacing:
           - Console.Write(value + "\t");

        4) Using formatted strings:
           - Console.Write($"{matrix[i,j],5}");

        Proper formatting makes the 2D array look
        like a real matrix instead of a single list.
        */

        #endregion


        #region If-Else vs Switch - Month Name Program

        Console.Write("Enter month number (1-12): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int month))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 12.");
            return;
        }

        // -----------------------
        // Using if-else statement
        // -----------------------
        Console.WriteLine("\nUsing if-else:");

        if (month == 1) Console.WriteLine("January");
        else if (month == 2) Console.WriteLine("February");
        else if (month == 3) Console.WriteLine("March");
        else if (month == 4) Console.WriteLine("April");
        else if (month == 5) Console.WriteLine("May");
        else if (month == 6) Console.WriteLine("June");
        else if (month == 7) Console.WriteLine("July");
        else if (month == 8) Console.WriteLine("August");
        else if (month == 9) Console.WriteLine("September");
        else if (month == 10) Console.WriteLine("October");
        else if (month == 11) Console.WriteLine("November");
        else if (month == 12) Console.WriteLine("December");
        else Console.WriteLine("Invalid month number.");

        // -----------------------
        // Using switch statement
        // -----------------------
        Console.WriteLine("\nUsing switch:");

        switch (month)
        {
            case 1: Console.WriteLine("January"); break;
            case 2: Console.WriteLine("February"); break;
            case 3: Console.WriteLine("March"); break;
            case 4: Console.WriteLine("April"); break;
            case 5: Console.WriteLine("May"); break;
            case 6: Console.WriteLine("June"); break;
            case 7: Console.WriteLine("July"); break;
            case 8: Console.WriteLine("August"); break;
            case 9: Console.WriteLine("September"); break;
            case 10: Console.WriteLine("October"); break;
            case 11: Console.WriteLine("November"); break;
            case 12: Console.WriteLine("December"); break;
            default: Console.WriteLine("Invalid month number."); break;
        }

        /*
        ----------------------------------------------------------
        Question:
        When should you prefer a switch statement over if-else?
        ----------------------------------------------------------

        Answer:

        Prefer switch when:

        1) You are comparing one variable against many
           constant values (like numbers or strings).

        2) The conditions are simple equality checks.

        3) You want cleaner, more readable code
           instead of many else-if statements.

        4) Performance matters slightly (switch can be
           optimized internally for many cases).

        Prefer if-else when:

        1) You need complex conditions (>, <, ranges, logical operators).
        2) You compare different variables.
        3) Conditions are not simple equality checks.

        In summary:
        Use switch for multiple fixed-value comparisons.
        Use if-else for complex logical conditions.
        */

        #endregion



         #region Sorting and Searching in Array

        int[] numbers = { 7, 3, 9, 1, 5, 3, 8 };

        Console.WriteLine("Original Array:");
        PrintArray(numbers);

        // -----------------------
        // 1) Sort using Array.Sort()
        // -----------------------
        Array.Sort(numbers);

        Console.WriteLine("\nAfter Array.Sort():");
        PrintArray(numbers);

        // -----------------------
        // 2) Search using IndexOf()
        // -----------------------
        Console.Write("\nEnter value to search: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int value))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        int firstIndex = Array.IndexOf(numbers, value);
        int lastIndex = Array.LastIndexOf(numbers, value);

        Console.WriteLine($"\nFirst occurrence of {value}: {firstIndex}");
        Console.WriteLine($"Last occurrence of {value}: {lastIndex}");

        /*
        ----------------------------------------------------------
        Question:
        What is the time complexity of Array.Sort()?
        ----------------------------------------------------------

        Answer:

        Array.Sort() in C# uses an optimized sorting algorithm
        (Introspective Sort - a hybrid of QuickSort, HeapSort,
        and InsertionSort).

        Time Complexity:

        - Best Case:    O(n log n)
        - Average Case: O(n log n)
        - Worst Case:   O(n log n)

        Because it switches algorithms internally to
        avoid QuickSort worst-case O(n²).

        So overall complexity is O(n log n).
        */

        #endregion



        #region Sum of Array Using for and foreach

        // Create an array of integers
        int[] numbers = { 5, 10, 15, 20, 25 };

        // -----------------------
        // 1) Using for loop
        // -----------------------
        int sumFor = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sumFor += numbers[i];
        }

        Console.WriteLine("Sum using for loop: " + sumFor);

        // -----------------------
        // 2) Using foreach loop
        // -----------------------
        int sumForeach = 0;

        foreach (int num in numbers)
        {
            sumForeach += num;
        }

        Console.WriteLine("Sum using foreach loop: " + sumForeach);

        /*
        ----------------------------------------------------------
        Question:
        Which loop (for or foreach) is more efficient
        for calculating the sum of an array, and why?
        ----------------------------------------------------------

        Answer:

        For arrays specifically:

        - The for loop is slightly more efficient because:
          1) It directly accesses elements using index.
          2) It avoids the small enumerator overhead used by foreach.

        - However, in modern C#, for arrays, foreach is
          internally optimized and the performance difference
          is extremely small (almost negligible).

        Summary:
        - Use for if you need index access or maximum control.
        - Use foreach for cleaner, safer, and more readable code.
        - For summing an array, both are practically equally efficient.
        */

        #endregion



        // PART 2 
        #region Enum Example - Convert Integer to Day



        Console.Write("Enter a number (1-7): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number) || number < 1 || number > 7)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
            return;
        }

        // Convert integer to enum using Enum.Parse
        DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), number.ToString());

        Console.WriteLine($"Day is: {day}");

        /*
        Explanation:

        1) Enum values are assigned numbers starting from 1.
        2) Enum.Parse converts the string representation of the number
           into the corresponding enum value.
        3) Casting to (DayOfWeek) is required because Parse returns object.

        Alternative (simpler and safer way):
            DayOfWeek day = (DayOfWeek)number;

        This works because enum internally stores integer values.
        */

        #endregion

        /*
----------------------------------------------------------
Question:
What happens if the user enters a value outside
the range of 1 to 7?
----------------------------------------------------------

Answer:

1) If input validation is used (checking range 1–7):
   - The program will detect the invalid value.
   - It will display an error message.
   - The enum conversion will NOT happen.
   - No exception will be thrown.

2) If NO range validation is used:
   - The enum variable can still store the value.
   - Enums in C# are internally integers.
   - So (DayOfWeek)9 is allowed even if 9 is not defined.
   - When printed, it will display "9" instead of a day name.

3) An exception only happens if:
   - The input cannot be parsed to an integer
     (for example, using int.Parse with "abc"),
     which throws a FormatException.

Conclusion:
Enums can hold undefined numeric values unless
you validate the range or use Enum.IsDefined().
*/





    }
    enum DayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
}
