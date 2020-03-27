using csharp1.async;

namespace csharp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            new AsyncTest().Test(25, 1);
            new AsyncTest().Test(25, 6);
        }

    }
}
