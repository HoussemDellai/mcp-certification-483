using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncIOTextWriter
{
    class Program
    {
        public static async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream stream = new FileStream("test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000]; new Random().NextBytes(data);
                Console.WriteLine("going async");
                await stream.WriteAsync(data, 0, data.Length);
                Console.WriteLine("finished async");
            }
        }

        static void Main(string[] args)
        {
            Task t = CreateAndWriteAsyncToFile();

            //do some other stuff:
            Console.WriteLine("do some other work");
            string badIdea = "";
            for(var i = 0; i < 10000; i++)
            {
                badIdea += i;
            }
            Console.WriteLine("finished some other work");

            //task ran in the backgroud, now lets wait for it to finish
            if (t.IsCompleted)
            {
                Console.WriteLine("async task already finished");
            }
            t.Wait();

            Console.ReadLine();
        }
    }
}
