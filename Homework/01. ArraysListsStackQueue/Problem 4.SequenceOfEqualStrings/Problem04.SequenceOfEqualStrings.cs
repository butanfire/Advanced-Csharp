namespace SequenceOfEqualStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SequenceOfEqualStrings
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            Dictionary<string, int> seqCounter = new Dictionary<string, int>();

            foreach (var word in input)
            {
                if (seqCounter.ContainsKey(word))
                {
                    seqCounter[word] += 1;
                }
                else
                {
                    seqCounter.Add(word, 0);
                }
            }

            StringBuilder output = new StringBuilder();

            foreach (var word in seqCounter)
            {
                for (int i = 0; i <= word.Value; i++)
                {
                    output.AppendFormat(word.Key + " ");
                }
                output.AppendLine();
            }

            Console.WriteLine(output.ToString());
        }
    }
}
