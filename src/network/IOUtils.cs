using System.IO;

namespace csharp1.network
{
    public class IOUtils
    {
        public static byte[] Read(Stream stream)
        {
            const int size = 4096;
            var buffer = new byte[size];
            using var memory = new MemoryStream();
            int count;
            do
            {
                count = stream.Read(buffer, 0, size);
                if (count > 0)
                {
                    memory.Write(buffer, 0, count);
                }
            }
            while (count > 0);

            return memory.ToArray();
        }
    }
}