using System;
using System.Net.Sockets;

namespace csharp1.network
{
    public class SimpleClient
    {
        public SimpleClient()
        {
            try
            {
                var client = new TcpClient("0.tcp.ngrok.io", 19539);
                client.GetStream().Write(
                    System.Text.Encoding.ASCII.GetBytes("Hello from Oleg")
                );
                client.GetStream().Flush();
                var responseData = new byte[1024];
                int read = client.GetStream().Read(responseData);
                Console.WriteLine("Read: " + read);
                client.GetStream().Close();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}