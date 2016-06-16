namespace Problem_4.Sentence_Extractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            string pattern = @"(?<=[?!.])\D";
            var sentences = Regex.Split(text, pattern);

            foreach(var match in sentences)
            {
                if (match.Trim().EndsWith("?") || match.Trim().EndsWith(".") || match.Trim().EndsWith("!"))
                {
                    bool sentence = false;
                    foreach(var words in match.Split(' '))
                    {
                        if(words == word)
                        {
                            sentence = true;
                        }
                    }

                    if (sentence)
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}
