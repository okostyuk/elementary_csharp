using System;
using System.Threading;
using System.Threading.Tasks;

namespace csharp1.async
{
    public static class AsyncTest
    {
        public static double CalcSum(int[] data)
        {
            var start = DateTime.Now;
            long result = 0;
            foreach (var i in data)
            {
                result += i;
            }
            var executionTime = (DateTime.Now - start).TotalMilliseconds;
            //Console.WriteLine("CalcSum Result: {0} TotalTime: {1} ms", result, executionTime);
            return executionTime;
        }

        public static double CalcSumInParallel(int[] data, int threads)
        {
            var partSize = data.Length / threads;
            var tasks = new Task<long>[threads];
            var start = DateTime.Now;
            for (var i = 0; i < threads; i++)
            {
                tasks[i] = CalcAsync(data, i*partSize, partSize);
            }

            Task.WaitAll(tasks);
            long result = 0;
            foreach (var task in tasks)
            {
                result += task.Result;
            }

            var executionTime = (DateTime.Now - start).TotalMilliseconds;
            //Console.WriteLine("CalcSumInParallel({2}) Result: {0} TotalTime: {1} ms", result, executionTime, threads);
            return executionTime;
        }

        public static int[] PrepareData(int arraySize)
        {
            var random = new Random();
            var array = new int[arraySize];
            for (var i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(1, 10);
            }

            return array;
        }

        private static async Task<long> CalcAsync(int[] values, int @from, int length)
        {
            var taskId = from / length;
            var start = DateTime.Now;
            var sum = 0L;
            var task = new Task(() =>
            {
                //Console.WriteLine("\tstart taskId=" + taskId + "\t threadId=" + Thread.CurrentThread.GetHashCode());
                for (int i = from; i < from+length; i++)
                {
                    sum += values[i];
                }
            });
            task.Start();
            await task;
            var end = DateTime.Now;
            //Console.WriteLine("\tend taskId=" + taskId + "\t threadId=" + Thread.CurrentThread.GetHashCode() + " time: " + (end-start).TotalMilliseconds + " ms");
            return sum;
        }
    }
}