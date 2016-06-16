namespace Problem_1.Series_of_Letters
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class SeriesofLetters
    {
        public static void Main(string[] args)
        {
            List<string> output = new List<string>();

            var input = Console.ReadLine();

            string pattern = @"\w{1,}?";
            MatchCollection match = Regex.Matches(input,pattern);

            foreach (Match letter in match)
            {
                if (letter.NextMatch().Value != letter.Value)
                {
                    output.Add(letter.Value);
                }
            }

            Console.WriteLine(string.Join("",output));
        }
    }
}
