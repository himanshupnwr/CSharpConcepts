namespace LockingThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void DoWork()
        {

        }

        static void LockingForSafety()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account();
            for(int i = 0; i < threads.Length; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for(int i = 0;i < threads.Length;i++)
            {
                threads[i].Start();
            }
        }
    }
}
