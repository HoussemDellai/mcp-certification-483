using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_for
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue("Hello ");
            myQueue.Enqueue("World ");

            //foreach doesn't consume queue
            foreach (string s in myQueue)
            {
                Console.Write(s + " ");
            }

            //let's consume it
            while(myQueue.Any())
            {
                var s = myQueue.Dequeue();
                Console.Write(s + " ");
            }
        }
    }
}
