using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_DataType_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = Environment.TickCount;

            int sum = 0;
            for (int i = 0; i < 1000000000; i++)
                sum++;

            int end = Environment.TickCount;
            int totalTicks = end - start;
            Console.WriteLine(totalTicks);

            Console.ReadKey();
        }
    }
}
