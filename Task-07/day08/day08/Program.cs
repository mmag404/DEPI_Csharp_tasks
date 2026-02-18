using System;

namespace day08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1

            IVehicle car = new Car();
            IVehicle bike = new Bike();

            car.StartEngine();
            car.StopEngine();

            Console.WriteLine();

            bike.StartEngine();
            bike.StopEngine();

            /*
            Answer:

            It is better to code against an interface instead of a concrete class because it gives flexibility.

            For example, I used IVehicle reference instead of Car or Bike directly.
            This allows me to assign any object that implements IVehicle.

            Benefits:

            1. Flexibility:
               I can use Car, Bike, or any new vehicle like Truck without changing the code.

            2. Loose coupling:
               The program depends on the interface, not specific class implementation.

            3. Easy to extend:
               If I add new vehicle types, I don't modify existing logic.

            4. Polymorphism:
               One interface reference can refer to different object types.

            This makes the code more maintainable and scalable.
            */

            #endregion
            #region Q2

            // Abstract class approach
            Shape rect = new Rectangle(5, 4);
            Shape circle = new Circle(3);

            rect.Display();
            Console.WriteLine("Rectangle area (abstract class): " + rect.GetArea());

            circle.Display();
            Console.WriteLine("Circle area (abstract class): " + circle.GetArea());

            Console.WriteLine();

            // Interface approach
            IShape rect2 = new RectangleInterface(5, 4);
            IShape circle2 = new CircleInterface(3);

            Console.WriteLine("Rectangle area (interface): " + rect2.GetArea());
            Console.WriteLine("Circle area (interface): " + circle2.GetArea());


            /*
             Answer:

             We prefer using an abstract class over an interface when we want to provide common implementation
             that will be shared among multiple derived classes.

             For example, in Shape abstract class, I created Display() method once,
             and Rectangle and Circle reused it without rewriting the code.

             Abstract class is preferred when:

             1. Classes share common code
                Like Display() method, all shapes can use the same implementation.

             2. We want to define fields or constructors
                Abstract class can have variables and constructors, interface cannot.

             3. We want partial abstraction
                Abstract class allows both abstract methods and normal methods.

             4. There is a strong "is-a" relationship
                Rectangle is a Shape
                Circle is a Shape

             Interface is preferred when we only want to define a contract without implementation,
             and when we need multiple inheritance.

             So abstract class is better when classes share common behavior and code reuse is needed.

             */


            #endregion

            #region Q3

            Product[] products = new Product[]
            {
                new Product(1, "Laptop", 15000),
                new Product(2, "Mouse", 200),
                new Product(3, "Keyboard", 800),
                new Product(4, "Monitor", 5000)
            };

            Console.WriteLine("Before Sorting:\n");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Array.Sort(products);

            Console.WriteLine("\nAfter Sorting by Price:\n");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            /*
            Answer:

            Implementing IComparable improves flexibility in sorting because it allows
            the object itself to define its natural sorting logic.

            In this example, Product implements IComparable<Product>
            and I defined CompareTo() to compare products by Price.

            Because of that, I can simply call Array.Sort(products)
            without writing extra comparison logic.

            Benefits:

            1. Encapsulation:
               The sorting logic is inside the Product class.

            2. Reusability:
               Any time I sort Product objects, they automatically
               sort by Price.

            3. Cleaner code:
               I don't need to pass custom comparers every time.

            4. Flexibility:
               If I change CompareTo implementation (for example sort by Name),
               the sorting behavior changes everywhere automatically.

            So implementing IComparable makes sorting easier,
            cleaner, and more maintainable.

            */

            #endregion
            #region Q4

            int[] grades = { 90, 85, 80 };

            Student original = new Student(1, "Mohamed", grades);

            // Shallow copy (reference copy)
            Student shallowCopy = original;

            // Deep copy using copy constructor
            Student deepCopy = new Student(original);

            Console.WriteLine("Before modification:\n");
            original.Display();
            shallowCopy.Display();
            deepCopy.Display();

            Console.WriteLine("\nAfter modifying original grades:\n");

            original.Grades[0] = 50;

            original.Display();
            shallowCopy.Display();   // will change (same reference)
            deepCopy.Display();      // will NOT change (separate copy)


            /*
            Answer:

            The primary purpose of a copy constructor in C# is to create a new object
            that is a separate copy of an existing object.

            In shallow copy:
            When I wrote Student shallowCopy = original;
            both variables point to the same object in memory.
            So modifying one affects the other.

            In deep copy:
            I created a new object and manually copied the values.
            Especially for reference types like arrays,
            I created a new array and copied elements one by one.

            So when I modified original.Grades,
            deepCopy did not change because it has its own separate array.

            Main purpose of copy constructor:

            1. Create independent duplicate objects.
            2. Prevent unintended side effects.
            3. Ensure safe copying of reference-type fields.
            4. Improve data safety and encapsulation.

            Deep copy is important when the object contains reference types.

            */

            #endregion


            #region Q5

            Robot robot = new Robot();

            // Calls class method
            robot.Walk();

            // Calls interface method
            IWalkable walkableRobot = robot;
            walkableRobot.Walk();


            /*
            Answer:

            Explicit interface implementation helps resolve naming conflicts
            when a class and an interface have methods with the same name.

            In this example, Robot has its own Walk() method and also implements
            IWalkable.Walk() explicitly.

            So now Robot has two separate Walk methods:

            1. robot.Walk()
               Calls the class method.

            2. ((IWalkable)robot).Walk()
               Calls the interface method.

            This is useful when:

            - Multiple interfaces have same method names.
            - Or when class needs different behavior for interface method.

            Explicit implementation hides the interface method from normal object access.
            It can only be accessed using interface reference.

            This prevents conflicts and gives more control over method behavior.

            */

            #endregion
            #region Q6

            Account acc = new Account();

            acc.AccountId = 101;
            acc.AccountHolder = "Mohamed";
            acc.Balance = 5000;

            acc.Display();

            // Trying invalid value
            acc.Balance = -100;


            /*
            Answer:

            Encapsulation in both structs and classes is achieved using private fields
            and public properties to control access.

            The key difference between struct and class is that:

            Struct is a value type, while class is a reference type.

            This means:

            1. Struct creates a copy when assigned to another variable.
               Each struct has its own separate data.

            2. Class shares the same reference.
               Multiple variables can point to the same object.

            Example difference:

            If I copy a struct, changes in the copy do not affect the original.

            But if I copy a class reference, changes affect the original object.

            So encapsulation works the same way,
            but structs behave differently in memory because they are value types.

            */

            #endregion


            #region Q7

            /*
            Answer:

            Abstraction is the concept of hiding complex implementation details
            and showing only the essential features of an object.

            It focuses on WHAT the object does, not HOW it does it.

            For example:
            When I use Console.WriteLine(), I know it prints text,
            but I don't know the internal implementation of how it works.
            This is abstraction.

            Abstraction is achieved in C# using:
            - Interfaces
            - Abstract classes

            These define required behavior without showing implementation details.

            Relation between Abstraction and Encapsulation:

            Encapsulation and abstraction are related but different.

            Encapsulation:
            Means hiding data and controlling access using private fields and public properties.
            It focuses on protecting data.

            Example:
            private int balance;
            public int Balance { get; set; }

            Abstraction:
            Means hiding implementation complexity and exposing only essential behavior.
            It focuses on simplifying usage.

            Relationship summary:

            Encapsulation hides data (data protection)
            Abstraction hides implementation (complexity hiding)

            Encapsulation is the mechanism,
            Abstraction is the goal.

            Encapsulation helps achieve abstraction.

            Example in real life:

            Car:
            You use steering wheel and pedals (abstraction)
            You don't see engine internal parts (encapsulation)

            So abstraction provides simple interface,
            and encapsulation hides internal details.

            */

            #endregion





        }
    }
}
