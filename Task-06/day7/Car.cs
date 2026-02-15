using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    internal class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }

        // Default constructor
        public Car()
        {
            Id = 0;
            Brand = "Unknown";
            Price = 0;
        }

        // Constructor with Id
        public Car(int id)
        {
            Id = id;
        }

        // Constructor with Id and Brand
        public Car(int id, string brand)
        {
            Id = id;
            Brand = brand;
        }

        // Constructor with Id, Brand, and Price
        public Car(int id, string brand, double price)
        {
            Id = id;
            Brand = brand;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Brand: {Brand}, Price: {Price}");
        }
    }
}
