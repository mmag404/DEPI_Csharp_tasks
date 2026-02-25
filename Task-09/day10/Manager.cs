using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day10
{
    class Manager : Employee, IComparable<Manager>
    {
        // constructor calls base Employee constructor
        public Manager(int  id ,string name, double salary) : base(id,name, salary)
        {
        }


        // compare managers by salary
        public int CompareTo(Manager other)
        {
            return this.Salary.CompareTo(other.Salary);
        }
    }
}
