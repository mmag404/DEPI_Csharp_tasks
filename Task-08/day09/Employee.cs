using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Department Department { get; set; }


        // override Equals to compare employee content

        /*        public override bool Equals(object obj)
                {
                    // check if obj is Employee
                    Employee other = obj as Employee;

                    if (other == null)
                        return false;

                    return this.Id == other.Id &&
                           this.Name == other.Name &&
                           this.Salary == other.Salary;
                }*/

        // version for the later question bad design ofcourse !!
        public override bool Equals(object obj)
        {
            Employee other = obj as Employee;

            if (other == null)
                return false;

            return this.Department?.Equals(other.Department) ?? other.Department == null;
        }

    }
}
