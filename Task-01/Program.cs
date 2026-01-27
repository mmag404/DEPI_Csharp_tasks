using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region q1
            // Declare an integer variable x and assign it the value 10
            int x = 10;

            // Declare an integer variable y and assign it the value 20
            int y = 20;

            /*
            This section calculates the sum of two integers.
            The values of x and y are added together,
            and the result is stored in the variable sum.
            */
            int sum = x + y;

            // Display the result of the addition on the console
            Console.WriteLine(sum);
            #endregion

            #region q2
            // Shortcut to comment selected code in Visual Studio:
            // Ctrl + K, then Ctrl + C

            // Shortcut to uncomment selected code in Visual Studio:
            // Ctrl + K, then Ctrl + U
            #endregion

            #region q3
            // x was wrong because it's int but "10" is string, so remove the quotes
            int x = 10;

            // y was not declared before using it
            int y = 5;

            // console should be Console (c# is case sensitive)
            Console.WriteLine(x + y);
            #endregion

            #region q4
            // runtime error:
            // happens while the program is running
            // the code compiles but crashes during execution

            // example:
            // int x = 10;
            // int y = 0;
            // Console.WriteLine(x / y);  // crashes because division by zero


            // logical error:
            // program runs normally, no crash
            // but the output is wrong because the logic is wrong

            // example:
            // int x = 10;
            // int y = 5;
            // Console.WriteLine(x - y);  // should be +, but code is wrong
            #endregion

            #region q5
            // store full name (use string, camelCase)
            string fullName = "Mohammed Magdy";

            // store age (int for whole numbers)
            int age = 21;

            // store monthly salary (decimal for money)
            decimal monthlySalary = 5000.50m;

            // store student status (bool for true/false)
            bool isStudent = true;
            #endregion

            #region q6
            // naming conventions like PascalCase are important because:
            // they make the code easier to read and understand
            // they help other developers (and you) understand what each variable or class is for
            // they keep the code consistent across projects
            // they make it easier to debug and maintain code later
            // they follow c# standards, so your code looks professional
            #endregion

            #region q7
            // create an array
            int[] a = { 1, 2, 3 };

            // create another reference to the same array
            int[] b = a;

            // change value using the second reference
            b[0] = 99;

            // print using first reference
            Console.WriteLine(a[0]);

            // print using second reference
            Console.WriteLine(b[0]);

            // both print 99
            // because a and b point to the same array in memory
            #endregion
            #region q8  
            // value types:
            // stored in the stack (in most cases)
            // contain the actual value
            // when assigned to another variable, a copy is made
            // changing one does not affect the other
            // examples: int, double, bool, struct

            // reference types:
            // the reference is stored in the stack
            // the actual object is stored in the heap
            // when assigned to another variable, both references point to the same heap object
            // changing through one reference affects the other
            // examples: array, class, string
            #endregion


            #region q9
            int x = 15;
            int y = 4;

            // sum
            Console.WriteLine(x + y);

            // difference
            Console.WriteLine(x - y);

            // product
            Console.WriteLine(x * y);

            // division
            Console.WriteLine(x / y);   // integer division

            // remainder
            Console.WriteLine(x % y);

            #endregion
            
            #region q10
            // output will be: 2

            // explanation:
            // % is the modulus operator (remainder)
            // a % b means remainder of 2 divided by 7
            // since 2 is smaller than 7, division gives 0 and remainder stays 2

            #endregion

            #region q11

            int number = 12;

            // check if number is greater than 10 and even
            if (number > 10 && number % 2 == 0)
            {
                Console.WriteLine("number is greater than 10 and even");
            }
            else
            {
                Console.WriteLine("condition not satisfied");
            }

            #endregion


            #region q12
            // && (logical AND):
            // works with boolean conditions (true / false)
            // uses short-circuit evaluation
            // if the first condition is false, the second one is NOT checked
            // mainly used in if statements


            // & (bitwise AND):
            // works on bits of numbers (binary representation)
            // compares each bit and returns a number
            // when used with booleans, it evaluates BOTH sides (no short-circuit)
            #endregion
            
            #region q13
            // read double input from user
            double num = double.Parse(Console.ReadLine());

            // explicit casting (double -> int) -> required
            int explicitCast = (int)num;

            // implicit casting (int -> double) -> allowed and safe
            double implicitCast = explicitCast;

            // print results
            Console.WriteLine(explicitCast);
            Console.WriteLine(implicitCast);

            // notes:
            // implicit casting from double to int is NOT allowed
            // explicit casting may cause data loss (decimal part removed)

            #endregion

            #region q14
            // explicit casting is required when converting double to int because:
            // double can store decimal values but int cannot
            // converting double to int may lose the decimal part
            // the compiler wants you to confirm that you accept this data loss
            // so it forces you to use explicit casting to avoid mistakes
            #endregion

            #region q15
            // ask user for age as string
            string ageInput = Console.ReadLine();

            // convert string to int using Parse
            int age = int.Parse(ageInput);

            // check if age is valid
            if (age > 0)
            {
                Console.WriteLine("valid age");
            }
            else
            {
                Console.WriteLine("invalid age");
            }

            #endregion
            
            #region q16
            // if the input is invalid, these exceptions may occur:

            // FormatException:
            // happens if the user enters non-numeric input like "abc"

            // OverflowException:
            // happens if the number is too large or too small for int



            // handling the exception using try-catch:

            try
            {
                string input = Console.ReadLine();
                int age = int.Parse(input);

                if (age > 0)
                    Console.WriteLine("valid age");
                else
                    Console.WriteLine("invalid age");
            }
            catch (FormatException)
            {
                Console.WriteLine("input is not a number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("number is too large");
            }
            #endregion

            #region q17
            int x = 5;

            // postfix increment
            Console.WriteLine(x++); // prints 5, then x becomes 6

            // prefix increment
            Console.WriteLine(++x); // x becomes 7, then prints 7

            #endregion    

            #region q18
            int x = 5;

            // ++x : prefix increment
            // x becomes 6, then used in expression

            // x++ : postfix increment
            // current value (6) is used, then x becomes 7

            int y = ++x + x++; 
            // y = 6 + 6 = 12

            // final value of x is 7

            #endregion  
        

        }
    }
}
