using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    internal class Book
    {
        public string Title;
        public string Author;

        // Default constructor
        public Book()
        {
            Title = "Unknown";
            Author = "Unknown";
        }

        // Constructor with Title only
        public Book(string title)
        {
            Title = title;
            Author = "Unknown";
        }

        // Constructor with Title and Author
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public void Display()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}");
        }
    }
}
