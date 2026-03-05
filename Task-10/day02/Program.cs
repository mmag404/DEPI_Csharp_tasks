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

            #region Ordering Operators

            // 1
            var productsByName = ListGenerators.ProductList
                                 .OrderBy(p => p.ProductName);

            foreach (var p in productsByName)
                Console.WriteLine(p);


            // 2
            string[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var caseInsensitive = Arr4.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var w in caseInsensitive)
                Console.WriteLine(w);


            // 3
            var stockDesc = ListGenerators.ProductList
                            .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in stockDesc)
                Console.WriteLine(p);


            // 4
            string[] digits2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = digits2
                               .OrderBy(d => d.Length)
                               .ThenBy(d => d);

            foreach (var d in sortedDigits)
                Console.WriteLine(d);


            // 5
            string[] words2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words2
                              .OrderBy(w => w.Length)
                              .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var w in sortedWords)
                Console.WriteLine(w);


            // 6
            var sortedProducts = ListGenerators.ProductList
                                 .OrderBy(p => p.Category)
                                 .ThenByDescending(p => p.UnitPrice);

            foreach (var p in sortedProducts)
                Console.WriteLine(p);


            // 7
            string[] Arr5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedDesc = Arr5
                             .OrderBy(w => w.Length)
                             .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var w in sortedDesc)
                Console.WriteLine(w);


            // 8
            string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = Arr6
                         .Where(d => d.Length > 1 && d[1] == 'i')
                         .Reverse();

            foreach (var r in result)
                Console.WriteLine(r);

            #endregion




            #region Transformation Operators

            // 1
            var productNames = ListGenerators.ProductList
                               .Select(p => p.ProductName);

            foreach (var name in productNames)
                Console.WriteLine(name);


            // 2
            string[] words6 = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var wordCases = words6
                            .Select(w => new
                            {
                                Upper = w.ToUpper(),
                                Lower = w.ToLower()
                            });

            foreach (var w in wordCases)
                Console.WriteLine($"{w.Upper} - {w.Lower}");


            // 3
            var productInfo = ListGenerators.ProductList
                              .Select(p => new
                              {
                                  p.ProductName,
                                  p.Category,
                                  Price = p.UnitPrice
                              });

            foreach (var p in productInfo)
                Console.WriteLine($"{p.ProductName} - {p.Category} - {p.Price}");


            // 4
            int[] Arr7 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var inPlace = Arr7
                          .Select((num, index) => new
                          {
                              Number = num,
                              InPlace = num == index
                          });

            foreach (var item in inPlace)
                Console.WriteLine($"{item.Number}: {item.InPlace}");


            // 5
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = numbersA
                        .SelectMany(a => numbersB
                        .Where(b => a < b),
                        (a, b) => new { a, b });

            foreach (var p in pairs)
                Console.WriteLine($"{p.a} is less than {p.b}");


            // 6
            var smallOrders = ListGenerators.CustomerList
                             .SelectMany(c => c.Orders)
                             .Where(o => o != null && o.Total < 500);

            foreach (var o in smallOrders)
                Console.WriteLine(o);


            // 7
            var recentOrders = ListGenerators.CustomerList
                              .SelectMany(c => c.Orders)
                              .Where(o => o != null && o.OrderDate.Year >= 1998);

            foreach (var o in recentOrders)
                Console.WriteLine(o);

            #endregion


            #region Partitioning Operators

            // 1
            var first3Orders = ListGenerators.CustomerList
                              .Where(c => c.City == "Washington")
                              .SelectMany(c => c.Orders)
                              .Where(o => o != null)
                              .Take(3);

            foreach (var o in first3Orders)
                Console.WriteLine(o);


            // 2
            var ordersAfter2 = ListGenerators.CustomerList
                              .Where(c => c.City == "Washington")
                              .SelectMany(c => c.Orders)
                              .Where(o => o != null)
                              .Skip(2);

            foreach (var o in ordersAfter2)
                Console.WriteLine(o);


            // 3
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result1 = numbers
                          .TakeWhile((num, index) => num >= index);

            foreach (var n in result1)
                Console.WriteLine(n);


            // 4
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result2 = numbers2
                          .SkipWhile(n => n % 3 != 0);

            foreach (var n in result2)
                Console.WriteLine(n);


            // 5
            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result3 = numbers3
                          .SkipWhile((num, index) => num >= index);

            foreach (var n in result3)
                Console.WriteLine(n);

            #endregion


            #region Quantifiers

            // 1
            string[] words9 = File.ReadAllLines("dictionary_english.txt");

            var containsEi = words9.Any(w => w.Contains("ei"));
            Console.WriteLine(containsEi);


            // 2
            var categoriesWithOutOfStock = ListGenerators.ProductList
                                          .GroupBy(p => p.Category)
                                          .Where(g => g.Any(p => p.UnitsInStock == 0));

            foreach (var g in categoriesWithOutOfStock)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                    Console.WriteLine(p);
            }


            // 3
            var categoriesAllInStock = ListGenerators.ProductList
                                       .GroupBy(p => p.Category)
                                       .Where(g => g.All(p => p.UnitsInStock > 0));

            foreach (var g in categoriesAllInStock)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                    Console.WriteLine(p);
            }

            #endregion
        }
    }
}
