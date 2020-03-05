using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace csharp1.network
{
    public class SimpleServer
    {
        public SimpleServer()
        {
            TcpListener server = new TcpListener(
                IPAddress.Parse("127.0.0.1"), 
                19539);
            server.Start();
            var buffer = new byte[1024];
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("new client connected: " + client.Client.RemoteEndPoint);
                var stream = client.GetStream();
                var read = stream.Read(buffer);
                Console.WriteLine("Read " + read + " bytes");
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, read));
                stream.Write(Encoding.ASCII.GetBytes("Hello from server"));
                stream.Close();
            }
        }
    }
}