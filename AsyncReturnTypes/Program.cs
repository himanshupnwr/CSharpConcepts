using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralizedAsyncDemo
{
    class GeneralizedAsync
    {
        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        // The ValueTask struct has a constructor with a Task parameter so that you can construct a ValueTask from the
        // return value of any existing async method
        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }

        private bool cache = false;
        private int cacheResult;

        private async Task<int> LoadCache()
        {
            //simulate async network:
            await Task.Delay(100);
            cache = true;
            cacheResult = 100;
            return cacheResult;
        }

        static void Main(string[] args)
        {
            int result;
            Stopwatch sw = new Stopwatch();
            GeneralizedAsync async = new GeneralizedAsync();

            Console.WriteLine("The result is: " + async.Func().Result);


            sw.Start();
            for (int i = 0; i<10; i++);
            result = async.LoadCache().Result;
            Console.WriteLine("Calling Async Task directly Time Elapsed = {0}", sw.Elapsed);
            sw.Stop();

            sw.Restart();
            sw.Start();
            for(int i  = 0; i < 10; i++)
            // use caching through ValueTask to reduce the async task times
            result = async.CachedFunc().Result;
            Console.WriteLine("Calling ValueTask Time Elapsed = {0}", sw.Elapsed);
            sw.Stop();
        }
    }
}