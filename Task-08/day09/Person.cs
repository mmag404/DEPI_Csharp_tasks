using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Department property
        public virtual string Department { get; set; }

        public Person(string name, int age, string department)
        {
            Name = name;
            Age = age;
            Department = department;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("----------------------");
        }
    }
}
