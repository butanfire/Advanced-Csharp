namespace Problem03.CategorizeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CategorizeNumbers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(float.Parse).ToArray();
            List<float> roundSet = new List<float>();
            List<float> floatSet = new List<float>();

            foreach (var number in input)
            {
                if (number % 1 == 0)
                {
                    roundSet.Add(number);
                }
                else
                {
                    floatSet.Add(number);
                }
            }

            PrintList(floatSet);
            PrintList(roundSet);
        }

        public static void PrintList(List<float> numbers)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("[" + string.Join(", ", numbers) + "]");
            output.Append(string.Format("-> min : {0}, max : {1}, sum : {2}, avg: {3}", 
                numbers.Min(), numbers.Max(), numbers.Sum(), numbers.Average()));
            Console.WriteLine(output.ToString());
        }
    }
}
