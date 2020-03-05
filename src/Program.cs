using System;
using csharp1.classes;
using csharp1.network;

namespace csharp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            //structures.Program.task2();
            //structures.Program.task3();
            
            //delegates.DelegatesTask.Task2();
            //delegates.DelegatesTask.Task3();
            //SimpleClient client = new SimpleClient();
            new SimpleServer();
        }
    }
}
