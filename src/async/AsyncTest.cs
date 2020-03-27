using System;
using System.Threading;
using System.Threading.Tasks;

namespace csharp1.async
{
    public class AsyncTest
    {
        public void Test(int complexity, int threads)
        {
            var arraySize = (int) Math.Pow(2, complexity);
            var array = Prepare(arraySize);

            var partSize = arraySize / threads;
            var tasks = new Task[threads];
            var start = DateTime.Now;
            for (var i = 0; i < threads; i++)
            {
                var task = Calc(array, i*partSize, partSize);
                tasks[i] = task;
            }

            Task.WaitAll(tasks);
            var end = DateTime.Now;
            Console.WriteLine("Total: " + (end - start).TotalMilliseconds + " ms");
        }

        private static int[] Prepare(int arraySize)
        {
            var random = new Random();
            var array = new int[arraySize];
            for (var i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(0, 10);
            }

            return array;
        }

        private static async Task Calc(int[] values, int from, int length)
        {
            var taskId = from / length;
            var start = DateTime.Now;
            var sum = 0;
            var task = new Task(() =>
            {
                Console.WriteLine("start taskId=" + taskId + "\t threadId=" + Thread.CurrentThread.GetHashCode());
                for (int i = from; i < from+length; i++)
                {
                    sum += values[i];
                }
            });
            task.Start();
            await task;
            var end = DateTime.Now;
            Console.WriteLine("end taskId=" + taskId + "\t threadId=" + Thread.CurrentThread.GetHashCode() + " time: " + (end-start).TotalMilliseconds + " ms");
        }
    }
}