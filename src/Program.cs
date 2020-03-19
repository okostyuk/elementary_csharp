using System;
using System.Threading;
using csharp1.chat;

namespace csharp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                new ChatServer().Start();
            }
            else
            {
                switch (args[0])
                {
                    case "server":
                        new ChatServer().Start();
                        break;
                    case "client":
                        new Client().Connect();
                        break;
                }
            }
        }

    }
}
