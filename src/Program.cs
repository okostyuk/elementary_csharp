using System;
using csharp1.async;

namespace csharp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var threads = 6;

            var data0 = AsyncTest.PrepareData(threads*1000000);
            AsyncTest.CalcSumInParallel(data0, threads);
            AsyncTest.CalcSumInParallel(data0, 1);
            AsyncTest.CalcSum(data0);

            Console.WriteLine("{0}_threads\t1_thread\tsingle_thread", threads);
            for (int i = 0; i < 10; i++)
            {
                var data = AsyncTest.PrepareData(threads*1000000);
                var execTime1 = AsyncTest.CalcSumInParallel(data, threads);
                var execTime2 = AsyncTest.CalcSumInParallel(data, 1);
                var execTime3 = AsyncTest.CalcSum(data);
                Console.WriteLine("{0}\t\t{1}\t\t{2}", execTime1, execTime2, execTime3);
            }
        }
    }
}
