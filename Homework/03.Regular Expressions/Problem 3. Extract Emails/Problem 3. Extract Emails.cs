namespace Problem_3.Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string pattern = @"([a-zA-Z_\.\-]{1,})(\@)\w([a-zA-Z\._\-])+(\w\.\w{1,})";
            
            MatchCollection machMail = Regex.Matches(input, pattern);

            foreach (Match match in machMail)
            {
                bool forbiddenChars = match.Groups[0].Value.StartsWith(".") || match.Groups[0].Value.StartsWith("_") || match.Groups[0].Value.StartsWith("-");
                if (!forbiddenChars)
                {
                    Console.WriteLine(match.Value);
                }
            }

        }
    }
}
