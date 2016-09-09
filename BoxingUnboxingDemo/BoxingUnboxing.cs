using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxingDemo
{
    class BoxingUnboxing
    {
        static void Main(string[] args)
        {
            int size = 10000000;

            ArrayListTimeCost(size);

            ListTimeCost(size);

            Console.ReadKey();
        }

        private static void ArrayListTimeCost(int size)
        {
            int start = Environment.TickCount;

            var array = new ArrayList();

            for (int i = 0; i < size; i++)
                array.Add(i);   //装箱

            int sum = 0;
            foreach (int value in array) //拆箱
            {
                sum += value;
            }

            int end = Environment.TickCount;
            int totalTicks = checked(end - start); ;
            Console.WriteLine("ArrayList add " + size + " elements in the end spend (ms): " + totalTicks);
        }

        private static void ListTimeCost(int size)
        {
            int start = Environment.TickCount;

            var array = new List<int>();

            for (int i = 0; i < size; i++)
                array.Add(i);

            int sum = 0;
            foreach (int value in array)
            {
                sum += value;
            }

            int end = Environment.TickCount;
            int totalTicks = checked(end - start); ;
            Console.WriteLine("List add " + size + " elements in the end spend (ms): " + totalTicks);
        }
    }
}
