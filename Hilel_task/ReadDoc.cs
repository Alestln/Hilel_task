namespace Hilel_task
{
    internal class ReadDoc
    {
        private string _path;

        public ReadDoc(string path)
        {
            _path = path;
        }

        public async Task<IEnumerable<string>> ReadAsync(CancellationToken cancellationToken)
        {
            var lines = new List<string>();

            using (FileStream stream = new FileStream(_path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string? line = "";

                    while(line is not null)
                    {
                        line = await reader.ReadLineAsync(cancellationToken);

                        if (line is not null)
                        {
                            lines.Add(line);
                            break;
                        }
                    }
                }
            }

            return lines;
        }
    }
}
