using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    internal struct Employee
    {
        private int empId;
        private string name;
        private double salary;

        public Employee(int id, string name, double salary)
        {
            this.empId = id;
            this.name = name;
            this.salary = salary;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            name = newName;
        }

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
            }
        }
    }
}
