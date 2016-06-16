namespace Problem_2.Line_Numbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main(string[] args)
        {
            string outputPath = @"output.txt";
            string readPath = @"input.txt";
            int lineCounter = 0;

            using (var reader = new StreamReader(readPath))
            {
                using (var writer = new StreamWriter(outputPath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.Write(lineCounter++ + " ");
                        foreach (char letter in line)
                        {
                            writer.Write(letter);
                        }

                        writer.WriteLine();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
