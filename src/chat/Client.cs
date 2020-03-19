using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace csharp1.chat
{
    public class Client
    {
        private ChatClient chatClient;
        private readonly StringBuilder userInput = new StringBuilder();
        private readonly Queue<Message> messages = new Queue<Message>();
        
        public void Connect()
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter server address: [127.0.0.1]");
            var hostname = Console.ReadLine();
            if (string.IsNullOrEmpty(hostname)) hostname = "localhost";
            Console.WriteLine("Enter server port: [9090]");
            var port = Console.ReadLine();
            if (string.IsNullOrEmpty(port)) port = "9090";
            Connect(username, hostname, int.Parse(port));
        }

        public void Connect(string userName, string host, int port)
        {
            var tcpClient = new TcpClient();
            Console.WriteLine("Connecting...");
            tcpClient.Connect(host, port);
            Console.WriteLine("Connected!");

            chatClient = new ChatClient(tcpClient) {Name = userName};
            chatClient.SendMessage(new Message("") {Username = userName});
            
            while (true)
            {
                try
                {
                    ReceiveMessages();
                    ReadMessage();
                    SendMessages();
                    Thread.Sleep(16); //~60 fps
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                    return;
                }
            }
        }

        private void ReadMessage()
        {
            while (Console.KeyAvailable)
            {
                var cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    messages.Enqueue(new Message(userInput.ToString()){Username = chatClient.Name});
                    userInput.Clear();
                }
                else
                {
                    Console.Write(cki.KeyChar);
                    userInput.Append(cki.KeyChar);
                }
            }
        }

        private void SendMessages()
        {
            if (messages.TryDequeue(out var message))
            {
                chatClient.SendMessage(message);
            }
        }

        private void ReceiveMessages()
        {
            var message = chatClient.ReceiveMessageIfAvailable();
            if (message == null || string.IsNullOrWhiteSpace(message.Username)) return;
            Console.WriteLine("(ChatMessage) " + message.Username + ": " + message.Text);
        }
    }
}