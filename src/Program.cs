using csharp1.network;

namespace csharp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            new WebServer(9090).Start();
        }
    }
}
