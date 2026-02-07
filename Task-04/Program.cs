using System;
using System.IO;

namespace task1
{
    

    class Program
    {

        
#region q2
public static void TestDefensiveCode()
{

    // error we have to define it outside main, but i kept it here 
    int X, Y, Z;

    do
    {
        Console.WriteLine("Enter first Number : ");
    }
    while (!int.TryParse(Console.ReadLine(), out X) || X <= 0);

    do
    {
        Console.WriteLine("Enter Second Number : ");
    }
    while (!int.TryParse(Console.ReadLine(), out Y) || Y <= 1);

    Z = X / Y;
    Console.WriteLine("Result = " + Z);

    int[] arr = { 1, 2, 3 };
    if (arr?.Length > 69)
        arr[69] = 90;
}

/*
Question: How does int.TryParse() improve program robustness compared to int.Parse()?

Answer:
TryParse does not throw exception if input is wrong.
it returns false instead, so program keeps running.
Parse throws exception and may crash program if not handled.
*/
#endregion


    
        static void Main(string[] args)
        {

#region q1
try
{
    Console.Write("Enter first number: ");
    int a = int.Parse(Console.ReadLine());

    Console.Write("Enter second number: ");
    int b = int.Parse(Console.ReadLine());

    int result = a / b;
    Console.WriteLine("Result = " + result);
}
catch (DivideByZeroException)
{
    Console.WriteLine("Cannot divide by zero.");
}
finally
{
    Console.WriteLine("Operation complete");
}

/*
Question: What is the purpose of the finally block?

Answer:
finally always executes no matter what.
even if exception happens or not.
used for cleanup or things that must run anyway.
*/
#endregion



#region q3

int? num = null;

// using ??
int value = num ?? 10;
Console.WriteLine("Value after ?? = " + value);

// HasValue and Value
if (num.HasValue)
{
    Console.WriteLine("Has value: " + num.Value);
}
else
{
    Console.WriteLine("num is null");
}

// demo difference
num = 5;
if (num.HasValue)
{
    Console.WriteLine("Now value = " + num.Value);
}

/*
Question: What exception occurs when trying to access Value on a null Nullable<T>?

Answer:
InvalidOperationException happens.
because there is no value stored inside the nullable.
*/
#endregion


#region q4
int[] arr = new int[5] { 1, 2, 3, 4, 5 };

try
{
    Console.WriteLine(arr[10]);   // out of range
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Index is out of bounds");
}

/*
Question: Why is it necessary to check array bounds before accessing elements?

Answer:
because accessing invalid index throws exception.
program may crash if not handled.
checking bounds keeps program safe and stable.
*/
#endregion



#region q5
int[,] arr = new int[3, 3];

// input
for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        Console.Write($"Enter value [{i},{j}] : ");
        arr[i, j] = int.Parse(Console.ReadLine());
    }
}

// sum rows
for (int i = 0; i < arr.GetLength(0); i++)
{
    int rowSum = 0;
    for (int j = 0; j < arr.GetLength(1); j++)
        rowSum += arr[i, j];

    Console.WriteLine("Row " + i + " sum = " + rowSum);
}

// sum columns
for (int j = 0; j < arr.GetLength(1); j++)
{
    int colSum = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
        colSum += arr[i, j];

    Console.WriteLine("Column " + j + " sum = " + colSum);
}

/*
Question: How is the GetLength(dimension) method used in multi-dimensional arrays?

Answer:
GetLength(0) gives number of rows.
GetLength(1) gives number of columns.
we use it in loops instead of hardcoding size.
*/
#endregion

#region q6
int[][] arr = new int[3][];

arr[0] = new int[2];
arr[1] = new int[4];
arr[2] = new int[3];

// input
for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr[i].Length; j++)
    {
        Console.Write($"Enter value [{i}][{j}] : ");
        arr[i][j] = int.Parse(Console.ReadLine());
    }
}

// print
for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr[i].Length; j++)
        Console.Write(arr[i][j] + " ");

    Console.WriteLine();
}

/*
Question: How does the memory allocation differ between jagged arrays and rectangular arrays?

Answer:
jagged array is array of arrays.
each row allocated separately in memory.
rectangular array is one continuous block.
all rows same size and stored together.
*/
#endregion



#region q7
#nullable enable
string? name = null;

Console.Write("Enter your name (or leave empty): ");
string input = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(input))
    name = input;

if (name != null)
{
    Console.WriteLine("Hello " + name);
}
else
{
    Console.WriteLine("No name entered");
}

// using ! to suppress warning
string forced = name!;
Console.WriteLine("Length = " + forced.Length);

/*
Question: What is the purpose of nullable reference types in C#?

Answer:
to help detect null reference problems at compile time.
compiler warns if something ممكن يكون null.
reduces NullReferenceException in runtime.
*/
#endregion
  



#region q8
int x = 10;

// boxing
object obj = x;
Console.WriteLine("Boxed value = " + obj);

try
{
    // correct unboxing
    int y = (int)obj;
    Console.WriteLine("Unboxed value = " + y);

    // invalid unboxing
    object obj2 = 3.14;
    int z = (int)obj2;   // will throw
}
catch (InvalidCastException)
{
    Console.WriteLine("Invalid cast during unboxing");
}

/*
Question: What is the performance impact of boxing and unboxing in C#?

Answer:
boxing allocates memory on heap.
unboxing requires casting and type checking.
this adds extra overhead and can reduce performance
if used too much.
*/
#endregion



#region q9
void SumAndMultiply(int a, int b, out int sum, out int product)
{
    sum = a + b;
    product = a * b;
}

int x = 4, y = 5;
int s, p;

SumAndMultiply(x, y, out s, out p);

Console.WriteLine("Sum = " + s);
Console.WriteLine("Product = " + p);

/*
Question: Why must out parameters be initialized inside the method?

Answer:
because out means the method must assign it.
compiler forces initialization before method ends.
otherwise value would be undefined.
*/
#endregion


#region q10
void PrintText(string text, int times = 5)
{
    for (int i = 0; i < times; i++)
        Console.WriteLine(text);
}

// normal call (uses default 5)
PrintText("Hello");

// named parameter
PrintText(text: "Hi", times: 3);

/*
Question: Why must optional parameters always appear at the end of a method's parameter list?

Answer:
because compiler matches arguments by position.
if optional comes before required, it causes ambiguity.
so optional parameters must be last.
*/
#endregion



#region q11
int[]? numbers = null;

// safe access using ?.
int? length = numbers?.Length;
Console.WriteLine("Length = " + (length?.ToString() ?? "Array is null"));

numbers = new int[] { 1, 2, 3 };

// access again
Console.WriteLine("Length after init = " + numbers?.Length);

/*
Question: How does the null propagation operator prevent NullReferenceException?

Answer:
it checks if object is null before accessing member.
if null, it returns null instead of throwing exception.
so program continues safely.
*/
#endregion


#region q12
Console.Write("Enter day of week: ");
string day = Console.ReadLine();

int dayNumber;

switch (day)
{
    case "Monday":
        dayNumber = 1;
        break;
    case "Tuesday":
        dayNumber = 2;
        break;
    case "Wednesday":
        dayNumber = 3;
        break;
    case "Thursday":
        dayNumber = 4;
        break;
    case "Friday":
        dayNumber = 5;
        break;
    case "Saturday":
        dayNumber = 6;
        break;
    case "Sunday":
        dayNumber = 7;
        break;
    default:
        dayNumber = 0;
        break;
}

Console.WriteLine("Day number = " + dayNumber);

/*
Question: When is a switch expression preferred over a traditional if statement?

Answer:
when mapping fixed values in a cleaner shorter way.
it is more readable than long if else chains.
*/
#endregion



#region q13
int SumArray(params int[] numbers)
{
    int sum = 0;

    for (int i = 0; i < numbers.Length; i++)
        sum += numbers[i];

    return sum;
}

// call with individual values
int result1 = SumArray(1, 2, 3, 4);
Console.WriteLine("Sum1 = " + result1);

// call with array
int[] arr = { 5, 6, 7 };
int result2 = SumArray(arr);
Console.WriteLine("Sum2 = " + result2);

/*
Question: What are the limitations of the params keyword in method definitions?

Answer:
only one params allowed in method.
it must be the last parameter.
it must be single dimensional array.
*/
#endregion







////////////////////////////////////////// part 2 //////////////////////////////////////////


#region
int n;

do
{
    Console.Write("Enter a positive integer: ");
}
while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

for (int i = 1; i <= n; i++)
{
    Console.Write(i + " ");
}
#endregion



#region
int n;

Console.Write("Enter a number: ");
while (!int.TryParse(Console.ReadLine(), out n))
{
    Console.Write("Enter a valid number: ");
}

for (int i = 1; i <= 12; i++)
{
    Console.WriteLine(n + " x " + i + " = " + (n * i));
}
#endregion



#region
int n;

Console.Write("Enter a number: ");
while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
{
    Console.Write("Enter a valid positive number: ");
}

for (int i = 2; i <= n; i += 2)
{
    Console.Write(i + " ");
}
#endregion



#region
int baseNum, power;

Console.Write("Enter base number: ");
while (!int.TryParse(Console.ReadLine(), out baseNum))
{
    Console.Write("Enter valid base number: ");
}

Console.Write("Enter power: ");
while (!int.TryParse(Console.ReadLine(), out power))
{
    Console.Write("Enter valid power: ");
}

int result = 1;

for (int i = 0; i < power; i++)
{
    result *= baseNum;
}

Console.WriteLine("Result = " + result);
#endregion


#region
Console.Write("Enter a string: ");
string text = Console.ReadLine();

if (text == null)
    text = "";

for (int i = text.Length - 1; i >= 0; i--)
{
    Console.Write(text[i]);
}
#endregion



#region
int n;

Console.Write("Enter an integer: ");
while (!int.TryParse(Console.ReadLine(), out n))
{
    Console.Write("Enter valid integer: ");
}

int reversed = 0;
int temp = Math.Abs(n);

while (temp > 0)
{
    reversed = reversed * 10 + temp % 10;
    temp /= 10;
}

if (n < 0)
    reversed *= -1;

Console.WriteLine("Reversed = " + reversed);
#endregion

#region
Console.Write("Enter numbers separated by space: ");
string input = Console.ReadLine();

string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int n = parts.Length;

int[] arr = new int[n];
for (int i = 0; i < n; i++)
    arr[i] = int.Parse(parts[i]);

int maxDistance = -1;


// just check each pair from left and right, if they are equal calculate distance and update max

for (int i = 0; i < n; i++)
{
    for (int j = n - 1; j > i; j--)
    {
        if (arr[i] == arr[j])
        {
            int distance = j - i - 1;
            if (distance > maxDistance)
                maxDistance = distance;
            break; // we break here since this already the max distance for this pair
        }
    }
}

Console.WriteLine(maxDistance);
#endregion

        }

    }
}
