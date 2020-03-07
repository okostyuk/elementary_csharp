using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace csharp1.network
{
    public class WebServer
    {
        private static readonly byte[] ResponseBody = Encoding.UTF8.GetBytes("<html><head></head><body>Hello world</body></html>");
        private static readonly byte[] ResponseHeader = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\n" +
                                                                         "Content-Type: text/html\n" + 
                                                                         "Content-Length: " + ResponseBody.Length + "\n" + 
                                                                         "Connection: close\r\n\r\n");

        private volatile bool started;
        private readonly TcpListener server;
        private readonly ConcurrentQueue<TcpClient> clientsQueue = new ConcurrentQueue<TcpClient>();
        private readonly Dictionary<TcpClient, byte[]> client2RequestMap = new Dictionary<TcpClient, byte[]>();

        public WebServer(int port)
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        }

        public void Start()
        {
            started = true;
            server.Start();
            Console.WriteLine("Start listening, press enter to stop");
            new Thread(ReadRequest).Start();
            new Thread(SendResponse).Start();
            Console.ReadLine();
            started = false;
        }

        private void ReadRequest()
        {
            while (started)
            {
                var client = server.AcceptTcpClient();
                Console.WriteLine("new client connected: " + client.Client.RemoteEndPoint);
                ReadDataAsync(client);
            }
        }

        private async void ReadDataAsync(TcpClient client)
        {
            Console.WriteLine("Start read some data");

            var request = new byte[0];
            var readBuffer = new byte[1024];
            var totalRead = 0;
            while (true)
            {
                var read = await client.GetStream().ReadAsync(readBuffer);
                var oldLength = request.Length;
                Array.Resize(ref request, request.Length + read);
                Array.Copy(readBuffer, 0, 
                    request, oldLength, read);
                totalRead += read;
                if (read < readBuffer.Length)
                {
                    break;
                }
            }

            Console.WriteLine("read " + totalRead + " bytes");
            Console.WriteLine(Encoding.UTF8.GetString(request));

            if (client2RequestMap.TryGetValue(client, out var requestData))
            {
                var oldDataSize = requestData.Length;
                Array.Resize(ref requestData, oldDataSize + totalRead);
                Array.Copy(
                    request, 0, 
                    requestData, oldDataSize, totalRead);
            }
            else
            {
                Array.Resize(ref request, totalRead);
                requestData = request;
            }

            if (RequestEndReceived(requestData))
            {
                client2RequestMap.Remove(client);
                clientsQueue.Enqueue(client);
            }
            else 
            { //not full request received, store received data until next part will be received
                client2RequestMap.TryAdd(client, requestData);
            }
        }

        private static bool RequestEndReceived(byte[] requestData)
        {
            return Encoding.UTF8.GetString(requestData).EndsWith("\r\n\r\n");
        }

        private void SendResponse()
        {
            while (started)
            {
                if (clientsQueue.IsEmpty)
                {
                    Console.WriteLine("No data, sleeping....");
                    Thread.Sleep(1000);
                    continue;                    
                }

                if (!clientsQueue.TryDequeue(out var client)) continue;
                
                client.GetStream().Write(ResponseHeader);
                client.GetStream().Write(ResponseBody);
                client.GetStream().Close();
                client.Close();
                Console.WriteLine("Response sent to client " + client.Client.RemoteEndPoint);
            }
        }
    }
}