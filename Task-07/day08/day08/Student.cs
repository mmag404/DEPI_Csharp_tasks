using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class Student
    {
        public int Id;
        public string Name;
        public int[] Grades; // reference type to demonstrate deep vs shallow copy

        // Normal constructor
        public Student(int id, string name, int[] grades)
        {
            Id = id;
            Name = name;
            Grades = grades;
        }

        // Copy constructor (Deep Copy)
        public Student(Student other)
        {
            Id = other.Id;
            Name = other.Name;

            // Deep copy of array
            Grades = new int[other.Grades.Length];
            for (int i = 0; i < other.Grades.Length; i++)
            {
                Grades[i] = other.Grades[i];
            }
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Grades: {string.Join(",", Grades)}");
        }
    }
}
