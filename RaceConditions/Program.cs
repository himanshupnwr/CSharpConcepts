using System.ComponentModel;

namespace RaceConditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();

            Thread t1 = new Thread(worker.DoActivityOne);
            t1.Start();
            t1.Join();

            Thread t2 = new Thread(worker.DoActivityTwo);
            t2.Start();
            t2.Join();

            Console.ReadLine();
        }
    }

    internal class Worker
    {
        int data = 0;
        internal void DoActivityOne()
        {
            lock (this)
            {
                for (int i = 0; i < 100; i++)
                {
                    data++;
                    Console.WriteLine($"Value of data is: {data} in thread id: {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                } 
            }
        }

        internal void DoActivityTwo()
        {
            lock (this)
            {
                for (int i = 0; i < 100; i++)
                {
                    data++;
                    Console.WriteLine($"Value of data is: {data} in thread id: {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                } 
            }
        }
    }
}
