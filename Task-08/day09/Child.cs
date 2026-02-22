using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public class Child : Parent
    {
        
        public sealed override double Salary { get; set; }

        public Child(double salary) : base(salary)
        {
            Salary = salary;
        }

       
        public void DisplaySalary()
        {
            Console.WriteLine("Salary is: " + Salary);
        }
    }
}
