namespace Problem06.SubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSums
    {
        public static void Main(string[] args)
        {
            int TargetSum = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            input = input.Distinct().ToArray(); // Remove duplicates from array
            double combinations = 1 << input.Length; //find how many combination are possible

            List<int> targetSums = new List<int>();//collector for numbers that sum == n
            List<List<int>> allSums = new List<List<int>>();//collect all  sum == n


            for (int i = 1; i < combinations; i++) // rotate all binary combination
            {
                int sum = 0;
                for (int z = 0; z < input.Length; z++)
                {
                    int mask = i & (1 << z);
                    if (mask != 0)
                    {
                        sum += input[input.Length - 1 - z];
                        targetSums.Add(input[input.Length - 1 - z]);
                    }
                }

                if (sum == TargetSum)
                {
                    allSums.Add(targetSums);
                }

                targetSums.Reverse();
                targetSums = new List<int>();//clear list
            }

            if (allSums.Count < 1)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                foreach (var sum in allSums)
                {

                    Console.WriteLine("{0} = {1}", string.Join(" + ", sum), TargetSum);
                }
            }

            Console.WriteLine();
        }
    }
}

