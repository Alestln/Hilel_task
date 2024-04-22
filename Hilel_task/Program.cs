using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Hilel_task
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            CancellationTokenSource src = new CancellationTokenSource();
            var path = "C:\\Users\\Alestin\\Downloads\\NASA_access_log_Jul95/access_log_Jul95";
            ReadDoc readDoc = new ReadDoc(path);

            var lines = await readDoc.ReadAsync(src.Token);
            var line = lines.ElementAt(0);

            var a = new ResponseInfo(line);
            var json = await client.GetStringAsync($"https://ipinfo.io/widget/demo/{a.Ip}");

            JsonSerializer.Deserialize(json, )
        }
    }
}
