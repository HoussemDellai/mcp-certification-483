using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 1;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            // t = this ContinueWith, for t.Result waiting for this t!
            t = t.ContinueWith((i) =>
            {
                return i.Result * 2;
            },TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine(t.Result);
            Console.ReadKey();
        }
    }
}
