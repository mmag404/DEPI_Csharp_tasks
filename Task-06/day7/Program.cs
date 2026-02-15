using System;

namespace day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q1
            Car c1 = new Car();
            Car c2 = new Car(1);
            Car c3 = new Car(2, "Toyota");
            Car c4 = new Car(3, "BMW", 50000);

            c1.Display();
            c2.Display();
            c3.Display();
            c4.Display();

            /*
            Question Answer:
            When you define any constructor in C#, the compiler stops creating the default constructor automatically.
            So if you still want a default constructor, you must write it yourself.
            */

            #endregion

            #region q2
            Calculator calc = new Calculator();

            int result1 = calc.Sum(5, 10);
            int result2 = calc.Sum(1, 2, 3);
            double result3 = calc.Sum(2.5, 3.7);

            Console.WriteLine("Sum of 2 integers: " + result1);
            Console.WriteLine("Sum of 3 integers: " + result2);
            Console.WriteLine("Sum of 2 doubles: " + result3);
            /*
            Question Answer:
            Method overloading improves readability because we use the same method name (Sum) for similar operations.
            It improves reusability because we do not need to create different method names like Sum2, Sum3, SumDouble.
            This makes the code cleaner and easier to understand and use.
            */
            #endregion

            #region q3
            Child c = new Child(10, 20, 30);
            c.Display();
            /*
            Question Answer:
            Constructor chaining is used to call the base class constructor from the child class.
            This ensures that the base class properties are properly initialized before the child class adds its own initialization.
            */
            #endregion


            #region q4
            Parent p1 = new ChildNew(2, 3, 4);
            Console.WriteLine("Using new keyword (Parent reference): " + p1.Product());

            ChildNew ch1 = new ChildNew(2, 3, 4);
            Console.WriteLine("Using new keyword (Child reference): " + ch1.Product());

            Parent p2 = new ChildOverride(2, 3, 4);
            Console.WriteLine("Using override keyword (Parent reference): " + p2.Product());

            ChildOverride ch2 = new ChildOverride(2, 3, 4);
            Console.WriteLine("Using override keyword (Child reference): " + ch2.Product());

            /*
            Question Answer:
            The new keyword hides the parent method. If you use a Parent reference, the Parent method runs.

            The override keyword replaces the parent method. Even if you use a Parent reference,
            the Child method runs.

            So override supports runtime polymorphism, but new does not.
            */

            #endregion


            #region q5
            Parent p = new Parent(10, 20);
            Parent cc = new Child(30, 40, 50);

            Console.WriteLine(p.ToString());
            Console.WriteLine(cc.ToString());

            /*
            Question Answer:
            ToString() is overridden to display object data in a readable format.
            Instead of printing the class name, it prints the actual values of the object.
            */
            #endregion

            #region q6
            IShape shape = new Rectangle(5, 4);

            shape.Draw();
            Console.WriteLine("Area = " + shape.Area);

            /*
            Question Answer:
            You cannot create an instance of an interface because it has no implementation.
            It only defines methods and properties. A class must implement the interface first,
            then you create an object from that class.
            */
            #endregion


            #region q7
            IShape shapee = new Circle(3);

            shapee.Draw();
            Console.WriteLine("Area = " + shapee.Area);

            shapee.PrintDetails();
            /*
            Question Answer:
            Default implementations allow adding new methods to interfaces without breaking existing classes.
            Classes can use the default method or override it if needed.
            */
            #endregion


            #region q8
            IMovable movable = new Car();

            movable.Move();

            /*
            Question Answer:
            Using an interface reference allows us to write flexible code.
            We can use the same interface reference with different classes that implement the interface.
            This supports polymorphism and makes the code easier to extend and maintain.
            */


            #endregion

            #region q9
            File file = new File();

            file.Read();
            file.Write();


            /*
            Question Answer:
            C# does not support multiple inheritance with classes, but it allows a class to implement multiple interfaces.
            This lets a class have behaviors from multiple sources without inheritance problems.
            */

            #endregion


            #region q10
            Rectangl rect = new Rectangl(5, 4);

            rect.Draw();
            Console.WriteLine("Area = " + rect.CalculateArea());
            /*
            Question Answer:
            A virtual method has a default implementation in the base class and can be overridden in the child class.

            An abstract method has no implementation in the base class and must be implemented in the child class.
            */

            #endregion
        }
    }
    
}
