using System;

namespace csharp1.network
{
    public class HttpRequestBuilder
    {
        private const string UserAgent =
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.116 Safari/537.36";
        
        private const string Request = "{0} {1} HTTP/1.1\r\n" + 
                                       "Host: {2}\r\n" + 
                                       "Accept: {3}\r\n" + 
                                       "Connection: keep-alive\r\n" + 
                                       "Accept-Language: en-US,en;q=0.9,ru-RU;q=0.8,ru;q=0.7,tr-TR;q=0.6,tr;q=0.5\r\n" + 
                                       "Accept-Encoding: gzip, deflate\r\n" + 
                                       "User-Agent: " + UserAgent + "\r\n" + 
                                       "\r\n";

        private const string Request2 = "{0} {1} HTTP/1.1\r\n\r\n";

        private string method = "GET";
        private string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
        private readonly Uri uri;

        public HttpRequestBuilder(Uri uri)
        {
            this.uri = uri;
        }

        public void SetMethod(string value)
        {
            method = value;
        }

        public string Build()
        {
            var result = string.Format(Request, method, uri.LocalPath, uri.Host, accept);
            Console.WriteLine(result);
            return result;
        }
    }
}