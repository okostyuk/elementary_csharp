using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharp1.network
{
    public class SimpleServer
    {
        private Boolean started = true;
        private SocketListener socketListener;
        private Thread socketListenerThread;
        
        public SimpleServer()
        {
            socketListener = new SocketListener(started);
        }

        public async void Start()
        {
            socketListenerThread = new Thread(socketListener.Accept);
            socketListenerThread.Start();
            while (started)
            {
                var readyClientTask = await Task.WhenAny(socketListener.asyncTasks);
                var memory = readyClientTask.Result;
                Console.WriteLine("memory.Length = " + memory.Length);
            }
        }

        public void Stop()
        {
            started = false;
        }

        class SocketListener
        {
            Dictionary<TcpClient, Memory<byte>> clients = new Dictionary<TcpClient, Memory<byte>>();
            public List<Task<Memory<byte>>> asyncTasks = new List<Task<Memory<byte>>>();

            private Boolean started;
            private TcpListener server;

            public SocketListener(Boolean started)
            {
                this.started = started;
                server = new TcpListener(
                    IPAddress.Parse("127.0.0.1"), 
                    19539);
            }

            public void Accept()
            {
                server.Start();
                Console.WriteLine("Start listening");
                while (started)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("new client connected: " + client.Client.RemoteEndPoint);
                    var stream = client.GetStream();
                    Memory<byte> memory = new Memory<byte>();
                    clients.Add(client, memory);
                    asyncTasks.Add(ReadStreamAsync(stream));
                }
                server.Stop();            }
            
            async Task<Memory<byte>> ReadStreamAsync(NetworkStream stream)
            {
                Memory<byte> memory = new Memory<byte>();
                var readResult = await stream.ReadAsync(memory);
                return memory;
            }
        }
    }
}