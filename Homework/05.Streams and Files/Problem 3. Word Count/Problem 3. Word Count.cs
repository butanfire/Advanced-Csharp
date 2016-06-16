namespace Problem_3.Word_Count
{
    using System.Collections.Generic;
    using System.IO;

    public class WordCounter
    {
        public static void Main(string[] args)
        {
            string inputWords = @"words.txt";
            string textFile = @"text.txt";
            string outputFile = @"result.txt";

            Dictionary<string, int> wordCountList = new Dictionary<string, int>();
            using (var reader = new StreamReader(inputWords))
            {
                using (var textMatcher = new StreamReader(textFile))
                {
                    string word = reader.ReadLine();
                    while (word != null)
                    {
                        string line = textMatcher.ReadLine();
                        while (line != null)
                        {
                            line = line.ToLowerInvariant();

                            if (!wordCountList.ContainsKey(word))
                            {
                                wordCountList.Add(word, 0);
                            }

                            if (line.Contains(word))
                            {
                                wordCountList[word]++;
                            }

                            line = textMatcher.ReadLine();
                        }

                        textMatcher.BaseStream.Position = 0;
                        word = reader.ReadLine();
                    }
                }
            }

            using (var writer = new StreamWriter(outputFile))
            {   
                foreach (var match in wordCountList)
                {
                    writer.WriteLine(match.Key + " - " + match.Value);
                }
            }
        }
    }
}
