using System;
using System.IO;
using System.Net.Sockets;

namespace csharp1.chat
{
    public class ChatClient
    {
        public DateTime Date = DateTime.Now;
        public string Name;
        public string Status = "NEW";//NEW, SELECT_USERNAME_SENT, USERNAME_SELECTED, DISCONNECTED

        private readonly TcpClient tcpClient;
        private readonly NetworkStream stream;
        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        public ChatClient(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            stream = tcpClient.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) {AutoFlush = true};
        }

        public Message ReceiveMessageIfAvailable()
        {
            if (!stream.CanRead || !stream.DataAvailable) return null;
            var message = Parser.Deserialize(reader.ReadLine());
            return string.IsNullOrWhiteSpace(message.Username) ? null : message;
        }

        public void SendMessage(Message message)
        {
            writer.WriteLine(Parser.Serialize(message));
        }

        public void DisconnectSilently()
        {
            try{ writer.Close(); } catch {/*ignored*/}
            try{ reader.Close(); } catch {/*ignored*/}
            try{ tcpClient.Close(); } catch {/*ignored*/}
        }

        public bool Connected()
        {
            return tcpClient.Connected;
        }

        public override string ToString()
        {
            return tcpClient.Client.RemoteEndPoint.ToString();
        }
    }
}