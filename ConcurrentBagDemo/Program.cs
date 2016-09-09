using System;
using System.Text;

using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConcurrentBagDemo
{
    class Program
    {
        internal static ConcurrentBag<int> _concurrentBag;

        class ThreadWork1  // producer
        {
            public ThreadWork1()
            { }

            public void run()
            {
                System.Console.WriteLine("ThreadWork1 run { ");
                for (int i = 0; i < 100; i++)
                {
                    System.Console.WriteLine("ThreadWork1 producer: " + i);
                    _concurrentBag.Add(i);
                }
                System.Console.WriteLine("ThreadWork1 run } ");
            }
        }

        class ThreadWork2  // consumer
        {
            public ThreadWork2()
            { }

            public void run()
            {
                int i = 0;
                int nCnt = 0;
                bool IsDequeuue = false;
                System.Console.WriteLine("ThreadWork2 run { ");
                for (;;)
                {
                    IsDequeuue = _concurrentBag.TryTake(out i);
                    if (IsDequeuue)
                    {
                        System.Console.WriteLine("ThreadWork2 consumer: " + i);
                        nCnt++;
                    }

                    if (nCnt == 99)
                        break;
                }
                System.Console.WriteLine("ThreadWork2 run } ");
            }
        }

        static void StartT1()
        {
            ThreadWork1 work1 = new ThreadWork1();
            work1.run();
        }

        static void StartT2()
        {
            ThreadWork2 work2 = new ThreadWork2();
            work2.run();
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(() => StartT1());
            Task t2 = new Task(() => StartT2());

            _concurrentBag = new ConcurrentBag<int>();

            Console.WriteLine("Main t1 t2 started {");
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);
            Console.WriteLine("Main wait t1 t2 end }");

            Console.ReadKey();
        }
    }
}
