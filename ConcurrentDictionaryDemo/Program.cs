using System;
using System.Text;

using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace ConcurrentDictionaryDemo
{
    class Program
    {
        #region concurrentDictionary class demo
        internal static ConcurrentDictionary<int, int> _concurrentDictionary;

        class ThreadWork1  // producer
        {
            public ThreadWork1()
            { }

            public void run()
            {
                System.Console.WriteLine("Thread1 run { ");
                for (int i = 0; i < 100; i++)
                {
                    System.Console.WriteLine("Thread1 producer: " + i);
                    _concurrentDictionary.TryAdd(i, i);
                }

                System.Console.WriteLine("Thread1 run } ");
            }
        }

        class ThreadWork2  // consumer
        {
            public ThreadWork2()
            { }

            public void run()
            {
                int i = 0, nCnt = 0;
                int nValue = 0;
                bool IsOk = false;
                System.Console.WriteLine("Thread2 run { ");
                while (nCnt < 100)
                {
                    IsOk = _concurrentDictionary.TryGetValue(i, out nValue);
                    if (IsOk)
                    {
                        System.Console.WriteLine("Thread2 consumer: key =" + i + " value = " + nValue);
                        nValue = nValue * nValue;
                        int currentValue = _concurrentDictionary.AddOrUpdate(i, nValue, (key, value) => { return value = nValue; });
                        nCnt++;
                        i++;

                        System.Console.WriteLine("Thread2 consumer: AddOrUpdate for key =" + i + " value = " + currentValue);
                    }
                }
                System.Console.WriteLine("Thread2 run } ");
            }
        }
        #endregion

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
            Task task1 = new Task(() => StartT1());
            Task task2 = new Task(() => StartT2());
            
            _concurrentDictionary = new ConcurrentDictionary<int, int>();

            Console.WriteLine("Main task1 task2 started {");
            task1.Start();
            task2.Start();
            Console.WriteLine("Main task1 task2 started }");

            Console.WriteLine("Main wait task1 task2 end {");
            Task.WaitAll(task1, task2);
            Console.WriteLine("Main wait task1 task2 end }");

            foreach (var pair in _concurrentDictionary)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, int>> 
                enumer = _concurrentDictionary.GetEnumerator();

            bool bIsNext = true;

            int nValue = 0;
            while (bIsNext)
            {
                bIsNext = enumer.MoveNext();
                Console.WriteLine("Key: " + enumer.Current.Key +
                                  "  Value: " + enumer.Current.Value);

                _concurrentDictionary.TryRemove(enumer.Current.Key, out nValue);
            }

            Console.WriteLine("\n\nDictionary Count: " + _concurrentDictionary.Count);

            Console.ReadKey();
        }
    }
}
