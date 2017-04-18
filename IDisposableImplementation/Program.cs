using System;

namespace IDisposableImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            //we need better examples here. Or: I need better understanding of GC!

            var res1 = new MyResource();
            res1 = null;
            // we forget to Dispose here!

            GC.Collect();

            // example taken from https://msdn.microsoft.com/en-us/library/ms244737.aspx
            using (var res2 = new MyResource())
            {
                //nothing happens here
                GC.Collect();
            }
            //it should be Disposed now
            GC.Collect();
        }
    }
}
