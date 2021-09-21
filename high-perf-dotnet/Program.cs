using System;

namespace high_perf_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new Test();
            test.test();
        }
    }

    ref struct Test
    {
        public void test()
        {
            foreach (var i in span)
            {
                Console.WriteLine(i);
            }
        }
    }

}