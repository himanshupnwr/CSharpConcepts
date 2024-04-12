namespace CancellationToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var task = Task.Factory.StartNew(() =>
            {
                token.ThrowIfCancellationRequested();

                bool DoTimeConsumingActivity = true;
                while (DoTimeConsumingActivity)
                {
                    if(token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested ();
                    }

                    Thread.Sleep (1000);
                    Console.WriteLine("-");
                }
            }, tokenSource.Token);

            Console.ReadLine();
            tokenSource.Cancel();

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine("${ex.Message}: {item.Message}");
                }
            }
        }
    }
}
