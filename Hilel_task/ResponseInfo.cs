using System.Globalization;
using System.Text;

namespace Hilel_task
{
    internal class ResponseInfo
    {
        public string Ip { get; set; }

        public DateTime Date { get; set; }

        public string MethodRequest { get; set; }

        public string Uri { get; set; }

        public string Protocol { get; set; }

        public int StatusCode { get; set; }

        public int SizeInBytes { get; set; }


        public ResponseInfo(string response)
        {
            var arr = response.Split(' ');
            Ip = arr[0];

            var builder = new StringBuilder();
            builder.Append(arr[3]);
            builder.Append(" ");
            builder.Append(arr[4]);
            builder.Remove(0, 1);
            builder.Remove(builder.Length - 1, 1);

            Date = DateTime.ParseExact(builder.ToString(), "dd/MMM/yyyy:HH:mm:ss zzzz", CultureInfo.InvariantCulture);

            MethodRequest = arr[5].TrimStart('"');
            Uri = arr[6];
            Protocol = arr[7].TrimEnd('"');

            StatusCode = int.Parse(arr[8]);
            SizeInBytes = int.Parse(arr[9]);
        }
    }
}
