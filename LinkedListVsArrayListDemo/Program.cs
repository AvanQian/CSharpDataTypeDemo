using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListVsArrayListDemo
{
    class Program
    {
       static void Main(String[] args) 
       {
           int size = 1*500*1000;

           TimeCost4List(size);

          Console.WriteLine();

           TimeCost4LinkedList(size);

           Console.ReadKey();

       }

       private static void TimeCost4List(int size)
       {
           // add elements
           List<String> list = new List<String>();
           int start = Environment.TickCount;
           for (int i = 0; i < size; i++)
           {
               list.Add("Just some test data" + i);
           }

           int end = Environment.TickCount;
           int totalTicks = checked(end - start); ;
           Console.WriteLine("List add " + size + " elements in the end spend (ms): " + totalTicks);


           // query
           start = Environment.TickCount;
           String median = list[size / 2];

           end = Environment.TickCount;
           totalTicks = checked(end - start);
           Console.WriteLine("query median spend:  " + totalTicks);


           // delete
           start = Environment.TickCount;
           list.Remove(median);

           end = Environment.TickCount;
           totalTicks = checked(end - start);
           Console.WriteLine("delete median spend:  " + totalTicks);

           start = Environment.TickCount;
           list.Clear();
           for (int i = 0; i < size; i++)
           {
               list.Insert(0, "Just some test data" + i);
           }
           end = Environment.TickCount;
           totalTicks = checked(end - start);
           Console.WriteLine("Insert " + size + " elements in the head spend: " + totalTicks);

       }

       static void TimeCost4LinkedList(int size)
       {
           // add elements
           
           LinkedList<String> list = new LinkedList<String>();
           int start = Environment.TickCount;
           for (int i = 0; i < size; i++)
           {
               list.AddLast("Just some test data" + i);
           }
           int end = Environment.TickCount;
           int totalTicks = checked(end - start);
           Console.WriteLine("LinkedList add " + size + " elements in the end spend (ms): " + totalTicks);

           // query
           start = Environment.TickCount;

           String median = list.ElementAt(size / 2);

           end = Environment.TickCount;
           totalTicks = checked(end - start);
           Console.WriteLine("query median spend:  " + totalTicks);


           // delete
           start = Environment.TickCount;
           list.Remove(median);

           end = Environment.TickCount;
           totalTicks = checked(end - start);
           Console.WriteLine("delete median spend:  " + totalTicks);

           start = Environment.TickCount;
           list.Clear();
           for (int i = 0; i < size; i++)
           {
               list.AddFirst("Just some test data" + i);
           }
           end = Environment.TickCount;
           totalTicks = checked(end - start);
           Console.WriteLine("add " + size + " elements in the head spend: " + totalTicks);
       }

       
    }
}
