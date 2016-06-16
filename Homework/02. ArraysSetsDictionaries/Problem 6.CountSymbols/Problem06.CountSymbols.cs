namespace Problem06.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main(string[] args)
        {
            Dictionary<char, int> SymbolDict = new Dictionary<char, int>();

            var input = Console.ReadLine().ToCharArray();

            foreach (var symbol in input)
            {
                if (!SymbolDict.ContainsKey(symbol))
                {
                    SymbolDict.Add(symbol, 1);
                }
                else
                {
                    SymbolDict[symbol] += 1;
                }
            }

            var outputList = SymbolDict.OrderBy(s => s.Key).ToList(); //order alphabetically

            foreach (var k in outputList)
            {
                Console.WriteLine(string.Format(k.Key + ": " + k.Value + " time/s"));
            }

            Console.WriteLine();
        }
    }
}
