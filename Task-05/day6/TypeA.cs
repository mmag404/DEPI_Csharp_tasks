using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    #region TypeAAssignment


    public class TypeA
    {
        private int F = 10;
        internal int G = 20;
        public int H = 30;

        public void PrintPrivate()
        {
            Console.WriteLine(F);   // (inside same class)
        }
    }

    public class TestInsideSameAssembly
    {
        public void Test()
        {
            TypeA obj = new TypeA();

            // Console.WriteLine(obj.F);  //  not allowed (private)
            Console.WriteLine(obj.G);     //  allowed (internal - same project)
            Console.WriteLine(obj.H);     //  allowed (public)
        }
    }

    /*
    Answer:

    Access modifiers control where a class member can be accessed from.

    private  → accessible only inside the same class.
    internal → accessible inside the same project (assembly).
    public   → accessible from anywhere (inside or outside the project).

    They help in data hiding, protecting sensitive data,
    and controlling how different parts of the program interact.
    */

    #endregion

}
