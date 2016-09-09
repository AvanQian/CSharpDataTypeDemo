using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_vs_StringBuilder
{
    class Program
    {
        /// <summary>
        /// .NET strings are immutable. There are many operations that sound as though they will
        //modify a string, such as concatenation, or the ToUpper and ToLower methods offered
        //by instances of the string type, but all of these generate a new string, leaving the original
        //one unmodified. This means that if you pass strings as arguments to code you didn’t
        //write, you can be certain that it cannot change your strings.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int count = 100000;
            
            String_demo(count);

            //Begin stringBulder         
            StringBulider_demo(count);

            Console.ReadKey();
        }

        private static void String_demo(int count)
        {
            int start = Environment.TickCount;

            string myString = string.Empty;

            for (int i = 0; i < count; i++)
                myString += "test";

            int end = Environment.TickCount;
            int totalTicks = checked(end - start);
            Console.WriteLine("Time elapsed for string (ms): " + totalTicks);
        }


        private static void StringBulider_demo(int count)
        {
            int start = Environment.TickCount;

            StringBuilder myStringBulider = new StringBuilder();

            for (int i = 0; i < count; i++)
                myStringBulider.Append("test");

            int end = Environment.TickCount;
            int totalTicks = checked(end - start);
            Console.WriteLine("Time elapsed for stringBuilder (ms) : " + totalTicks);
        }
    }
}
