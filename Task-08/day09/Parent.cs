using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public class Parent
    {
        public virtual double Salary { get; set; }

        public Parent(double salary)
        {
            Salary = salary;
        }
    }
}
