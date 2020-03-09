using csharp1.network;

namespace csharp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            SimplePageLoader.Download(
                //"http://selin.in.ua/solvve/text.txt",
                "http://info.cern.ch/hypertext/WWW/TheProject.html",
                //"http://ua.fm/",
                "/home/oleg/test2.html");
        }
    }
}
