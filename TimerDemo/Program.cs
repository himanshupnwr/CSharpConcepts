
namespace TimerDemo
{
    internal class Program
    {
        /* Simple Timer Example
        static void Main(string[] args)
        {
            while(true)
            {
                Thread.Sleep(1000);
                DisplayTime();
            }

            var timer = new Timer(_ => DisplayTime());
            timer.Change(0, 1000);

            Console.ReadKey();
        }

        private static void DisplayTime()
        {
            Console.WriteLine("The time is now {0}. (on thread #{1})", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId);
        }*/

        //Handling rentrance meand start the next timer when the first one completes
        static void Main(string[] args)
        {
            
            Timer timer = null;

            try
            {
                timer = new Timer(_ =>
                {
                    DisplayTime();
                    timer.Change(1000, Timeout.Infinite);
                });
                timer.Change(0, Timeout.Infinite);

                Console.ReadKey(true);
            }
            finally
            {
                if (timer != null)
                {
                    timer.Dispose();
                }
            }
        }

        private static void DisplayTime()
        {
            var msg = string.Format("The time is now {0}. (on thread #{1})", DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId);

            foreach(var word in msg.Split(' ')) {
                Thread.Sleep(25);
                Console.WriteLine(word);
            }

            Console.WriteLine();
        }
    }
}
