namespace csharp1.chat
{
    public static class Parser
    {
        public static string Serialize(Message message)
        {
            var serialized= message.Username + '\t' + message.Text + '\n'; 
            return serialized;
        }

        public static Message Deserialize(string data)
        {
            if (data == null)
            {
                return null;
            }

            var parsed = data.Split("\t");
            if (parsed.Length == 0) return null;
            var username = parsed[0];
            if (parsed.Length == 1)
            {
                return new Message("") {Username = username};
            }

            var text = parsed[1];
            return new Message(text) {Username = username};
        }
    }
}