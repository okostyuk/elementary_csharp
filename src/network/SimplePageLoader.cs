using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace csharp1.network
{
    public static class SimplePageLoader
    {
        public static void Download(string url, string file)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new IOException("Invalid url: " + url);
            }
            
            using var stream = new TcpClient(uri.Host, uri.Port).GetStream();
            var request = new HttpRequestBuilder(uri).Build();
            var requestData = Encoding.ASCII.GetBytes(request);
            stream.Write(requestData);
            stream.Flush();
            var responseReader = new HttpResponseReader(stream);
            responseReader.SaveContent(file);
        }
    }
}