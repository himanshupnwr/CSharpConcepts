

namespace LockingThread
{
    internal class Account
    {
        private Object _lock = new Object();
        int balance = 0;
        Random r = new Random();

        public Account()
        {

        }

        public Account(int initial) {
            balance = initial;
        }
        internal void DoTransactions()
        {
            for(int i = 0; i<100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }

        private int Withdraw(int amount)
        {
            if(balance < 0)
            {
                throw new Exception("Negative balance");
            }

            lock(_lock)
            {
                if(balance>= amount)
                {
                    Console.WriteLine("Activity on thread #{0}", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Balance before withdrawl" + balance);
                    Console.WriteLine("Amount to withdraw", + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after withdrawl", + balance);
                    return amount;
                }
                else
                {
                    return 0; //transaction rejected
                }
            }
        }
    }
}