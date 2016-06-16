namespace Problem_6.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Palindromes
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',', '.', ' ', '?', '!').ToList();
            List<string> output = new List<string>();

            foreach (var element in input)
            {
                if (element.Trim() != string.Empty)
                {
                    var reverseElement = element.Reverse();
                    string result = string.Empty;
                    foreach(var ch in reverseElement)
                    {
                        result += ch;
                    }

                    if (result == element)
                    {
                        output.Add(element);
                    }
                }
            }

            output.Sort();

            Console.WriteLine(string.Join(", ", output));

        }
    }
}
