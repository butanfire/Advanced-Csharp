namespace _03.Softuni_Numerals
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    public static class SoftuniNumerals
    {
        public static void Main()
        {
            string paternAA = @"aa";
            string patternABA = @"aba";
            string patternBCC = @"bcc";
            string paternCC = @"cc";
            string paternCDC = @"cdc";
            string input = Console.ReadLine();

            Regex reg = new Regex(patternABA);
            input = reg.Replace(input, "1");

            reg = new Regex(paternAA);
            input = reg.Replace(input, "0");

            reg = new Regex(paternCDC);
            input = reg.Replace(input, "4");

            reg = new Regex(patternBCC);
            input = reg.Replace(input, "2");

            reg = new Regex(paternCC);
            input = reg.Replace(input, "3");

            BigInteger output = 0;
            int numberIterator = input.Length - 1;
            for (int i = 0; i < input.Length; i++, numberIterator--)
            {
                var numb = input[numberIterator].ToString();
                BigInteger number = int.Parse(numb);
                output += (number * BigInteger.Pow(5, i));
            }
            Console.WriteLine(output.ToString());
        }
    }
}