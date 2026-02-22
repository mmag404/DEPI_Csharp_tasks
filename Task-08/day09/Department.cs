using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    #region Department class

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public override bool Equals(object obj)
        {
            Department other = obj as Department;

            if (other == null)
                return false;

            return this.Id == other.Id &&
                   this.Name == other.Name;
        }


        public override string ToString()
        {
            return $"Department Id = {Id}, Name = {Name}";
        }
    }

    #endregion
}
