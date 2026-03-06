using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day03.Models
{

    // Q1: Why did the property "Id" become a Primary Key without any explicit configuration?
    // Entity Framework follows a convention called "Key Discovery".
    // Any property named "Id" or "<ClassName>Id" is automatically treated as the Primary Key.
    // Since this class is named Book and it contains a property named Id,
    // Entity Framework automatically recognizes it as the table's primary key.

    // Q2: Why is "Country" nullable in the database while "Price" is not?
    // Because of the data types used in the classes.
    // In C#, "string?" means the value is nullable, so EF maps it to a nullable column in the database.
    // "decimal" is a non-nullable value type, so EF creates the database column as NOT NULL.
    // If it were written as "decimal?" it would become nullable in the database.
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
