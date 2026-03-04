using System;
using System.Linq;
using day10_G01;
using System.IO;

namespace day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Restriction Operators

            // 1
            var outOfStock = ListGenerators.ProductList
                            .Where(p => p.UnitsInStock == 0);

            foreach (var p in outOfStock)
                Console.WriteLine(p);


            // 2
            var inStockExpensive = ListGenerators.ProductList
                                  .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);

            foreach (var p in inStockExpensive)
                Console.WriteLine(p);


            // 3
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digits = Arr.Where((name, value) => name.Length < value);

            foreach (var d in digits)
                Console.WriteLine(d);

            #endregion


            #region Element Operators

            // 1
            var firstOutOfStock = ListGenerators.ProductList
                                 .First(p => p.UnitsInStock == 0);

            Console.WriteLine(firstOutOfStock);


            // 2
            var firstExpensive = ListGenerators.ProductList
                                .FirstOrDefault(p => p.UnitPrice > 1000);

            Console.WriteLine(firstExpensive);


            // 3
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var secondGreaterThanFive = Arr2
                                        .Where(n => n > 5)
                                        .Skip(1)
                                        .First();

            Console.WriteLine(secondGreaterThanFive);

            #endregion


            #region Aggregate Operators

            // 1
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var oddCount = Arr3.Count(n => n % 2 == 1);
            Console.WriteLine(oddCount);


            // 2
            var customersOrders = ListGenerators.CustomerList
                                  .Select(c => new
                                  {
                                      c.Name,
                                      OrderCount = c.Orders.Count(o => o != null)
                                  });

            foreach (var c in customersOrders)
                Console.WriteLine($"{c.Name} - {c.OrderCount}");


            // 3
            var categoryProducts = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(g => new
                                   {
                                       Category = g.Key,
                                       Count = g.Count()
                                   });

            foreach (var c in categoryProducts)
                Console.WriteLine($"{c.Category} - {c.Count}");


            // 4
            var total = Arr3.Sum();
            Console.WriteLine(total);


            // 5
            string[] words = File.ReadAllLines("dictionary_english.txt");
            var totalChars = words.Sum(w => w.Length);
            Console.WriteLine(totalChars);


            // 6
            var unitsPerCategory = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(g => new
                                   {
                                       Category = g.Key,
                                       TotalUnits = g.Sum(p => p.UnitsInStock)
                                   });

            foreach (var c in unitsPerCategory)
                Console.WriteLine($"{c.Category} - {c.TotalUnits}");


            // 7
            var shortestWord = words.Min(w => w.Length);
            Console.WriteLine(shortestWord);


            // 8
            var cheapestPerCategory = ListGenerators.ProductList
                                     .GroupBy(p => p.Category)
                                     .Select(g => new
                                     {
                                         Category = g.Key,
                                         MinPrice = g.Min(p => p.UnitPrice)
                                     });

            foreach (var c in cheapestPerCategory)
                Console.WriteLine($"{c.Category} - {c.MinPrice}");


            // 9
            var cheapestProducts =
                from p in ListGenerators.ProductList
                group p by p.Category into g
                let minPrice = g.Min(p => p.UnitPrice)
                from p in g
                where p.UnitPrice == minPrice
                select p;

            foreach (var p in cheapestProducts)
                Console.WriteLine(p);


            // 10
            var longestWord = words.Max(w => w.Length);
            Console.WriteLine(longestWord);


            // 11
            var mostExpensivePrice = ListGenerators.ProductList
                                     .GroupBy(p => p.Category)
                                     .Select(g => new
                                     {
                                         Category = g.Key,
                                         MaxPrice = g.Max(p => p.UnitPrice)
                                     });

            foreach (var c in mostExpensivePrice)
                Console.WriteLine($"{c.Category} - {c.MaxPrice}");


            // 12
            var mostExpensiveProducts =
                from p in ListGenerators.ProductList
                group p by p.Category into g
                let maxPrice = g.Max(p => p.UnitPrice)
                from p in g
                where p.UnitPrice == maxPrice
                select p;

            foreach (var p in mostExpensiveProducts)
                Console.WriteLine(p);


            // 13
            var avgWordLength = words.Average(w => w.Length);
            Console.WriteLine(avgWordLength);


            // 14
            var avgPricePerCategory = ListGenerators.ProductList
                                      .GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          AvgPrice = g.Average(p => p.UnitPrice)
                                      });

            foreach (var c in avgPricePerCategory)
                Console.WriteLine($"{c.Category} - {c.AvgPrice}");

            #endregion
        }
    }
}
