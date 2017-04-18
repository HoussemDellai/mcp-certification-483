using System;

namespace IFormatProviderAndICustomFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            // example taken from http://www.csharp-examples.net/custom-iformatprovider/
            Console.WriteLine(string.Format(new DoubleFormatter(),
                "Numbers {0} and {1:0.0}. Now a string {2}, a number {3}, date {4} and object: {5}",
                1.234567, -0.57123456, "Hi!", 5, DateTime.Now, new object()));
        }
    }
}
