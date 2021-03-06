using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace csharp1.chat
{
    public class ChatServer
    {
        private readonly HashSet<string> usernames = new HashSet<string>();
        private readonly HashSet<ChatClient> clients = new HashSet<ChatClient>();
        private readonly HashSet<ChatClient> disconnected = new HashSet<ChatClient>();
        private readonly HashSet<Message> messages = new HashSet<Message>();
        
        public void Start()
        {
            var server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9090);
            server.Start();
            Console.WriteLine("Server started at localhost:9090");
            while (true)
            {
                if (server.Pending())
                {
                    var chatClient = new ChatClient(server.AcceptTcpClient());
                    Console.WriteLine("New connection: " + chatClient);
                    clients.Add(chatClient);
                }

                foreach (var client in clients)
                {
                    try
                    {
                        ProcessClient(client);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                        client.Status = "DISCONNECTED";
                        client.DisconnectSilently();
                        disconnected.Add(client);
                        if (client.Name == null) continue;
                        usernames.Remove(client.Name);
                        messages.Add(new Message("disconnected") {Username = client.Name});

                    }
                }

                foreach (var client in disconnected)
                {
                    clients.Remove(client);
                }
                disconnected.Clear();
                
                Thread.Sleep(100);
            }
        }

        private void ProcessClient(ChatClient client)
        {
            if (!client.Connected()) throw new IOException("Client disconnected");
            switch (client.Status)
            {
                case "NEW":
                {
                    var message = client.ReceiveMessageIfAvailable();
                    if (message == null || string.IsNullOrWhiteSpace(message.Username)) return;
                    client.Name = message.Username;
                    if (usernames.Contains(message.Username))
                    {
                        client.SendMessage(new Message("Error: Username " + message.Username + " already in use."){Username = "Admin"});
                        throw new IOException("Wrong username");
                    }

                    usernames.Add(message.Username);
                    client.SendMessage(new Message("Greeting "+ client.Name+"!"){Username = "Admin"});
                    client.Status = "USERNAME_SELECTED";
                    message.Text = "Enter to chat";
                    messages.Add(message);
                    break;
                }
                case "USERNAME_SELECTED":
                    SendMessages(client);
                    ReceiveMessages(client);
                    break;
            }
        }

        private void ReceiveMessages(ChatClient client)
        {
            var message = client.ReceiveMessageIfAvailable();
            if (message == null) return;
            if (string.IsNullOrWhiteSpace(message.Text)) return;


            if (".quit".Equals(message.Text.ToLower()))
            {
                throw new IOException("Disconnected");
            }

            messages.Add(message);
        }

        private void SendMessages(ChatClient client)
        {
            foreach (var message in messages.Where(msg =>!msg.Username.Equals(client.Name)))
            {
                client.SendMessage(message);
                client.Date = message.Date;
            }
            messages.Clear();
        }
    }
}