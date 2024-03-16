namespace net8
{
    public class RandomRead
    {

        private static string filePath = "user_agent.txt";
        private static List<string> lines = new List<string>();
        private Random rand = new Random();

        public async Task<string> OpenTextAsync ()
        {
            try
            {
                // 使用异步方式打开文件并读取
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // 读取文件的每一行到列表中
                    if (lines.Count == 0)
                    {
                        var lines = await ReadLinesAsync(sr);
                    }

                    // 生成一个随机数生成器


                    // 随机选择一行并打印出来
                    int randomIndex = rand.Next(0,lines.Count);
                    string randomLine = lines[randomIndex];
                    await Console.Out.WriteLineAsync(randomLine);
                    return randomLine;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        private static async Task<List<string>> ReadLinesAsync (StreamReader reader)
        {

            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }
            return lines;
        }
    }
}
