using System;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;

namespace csharp1.network
{
    public class HttpResponseReader
    {
        private readonly StreamReader reader;
        
        private readonly StringDictionary headers = new StringDictionary();
        private int contentLength = -1;

        public HttpResponseReader(Stream stream)
        {
            reader = new StreamReader(stream);
        }

        private void ReadHeaders()
        {
            if (contentLength >= 0)
            {
                return;
            }
            
            var status = reader.ReadLine();
            Console.WriteLine("Response:\n" + status);
            var line = reader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var divider = line.IndexOf(":", StringComparison.Ordinal);
                var name = line.Substring(0, divider);
                var value = line.Substring(divider+2);
                headers.Add(name, value);
                line = reader.ReadLine();
                Console.WriteLine(line);
            }

            if (headers.ContainsKey("Content-Length"))
            {
                contentLength = int.Parse(headers["Content-Length"]);
            }
        }

        private string Body()
        {
            ReadHeaders();
            if (contentLength > 0)
            {
                var body = new char[contentLength];
                reader.Read(body);
                return new string(body);
            }

            if ("gzip".Equals(headers["Content-Encoding"]))
            {
                using var gsr = new GZipStream(reader.BaseStream, CompressionMode.Decompress);
                using var sr = new StreamReader(gsr);
                return sr.ReadToEnd();
            }
            
            return "TODO";
        }

        public void SaveContent(string filename)
        {
            File.WriteAllText(filename, Body());
        }
    }
}
