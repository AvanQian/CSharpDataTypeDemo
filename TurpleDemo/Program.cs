using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleDemo
{
    class Program
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main(string[] args)
        {
            //the user customer data type.
             Point p = new Point() { X = 10, Y = 20 };
            //use the predefine generic tuple type.
             Tuple<int, int> p2 = new Tuple<int, int>(10, 20);
            
            //
            Console.WriteLine("{0} {1}", p.X, p.Y);
            Console.WriteLine("{0} {1}",p2.Item1, p2.Item2);

            var primes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19);
            Console.WriteLine("Prime numbers less than 20: " +
                              "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
                              primes.Item1, primes.Item2, primes.Item3,
                              primes.Item4, primes.Item5, primes.Item6,
                              primes.Item7, primes.Rest.Item1);
            // The example displays the following output: 
            //    Prime numbers less than 20: 2, 3, 5, 7, 11, 13, 17, and 19

            Tuple<int, int, string, string, int, int, int, Tuple<int>> p3 = new Tuple<int, int, string, string, int, int, int, Tuple<int>>(10, 20, "name", "gender", 30, 40, 50, new Tuple<int>(60));
            Console.WriteLine(p3);

            var tuple = new Tuple<int, int, string, string, int, int, int, Tuple<int>>(10, 20, "name", "gender", 30, 40, 50, new Tuple<int>(60));
            Console.WriteLine(tuple);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
                  tuple.Item1, tuple.Item2, tuple.Item3,
                  tuple.Item4, tuple.Item5, tuple.Item6,
                  tuple.Item7, tuple.Rest.Item1);

            Console.ReadKey();
        }
    }
}
