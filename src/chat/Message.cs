using System;

namespace csharp1.chat
{
    public class Message
    {
        public string Username;
        public DateTime Date = DateTime.Now;
        public string Text;

        public Message(string text)
        {
            Text = text;
        }
    }
}