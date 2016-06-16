namespace Problem07.SubsetSumsOrdered
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSumsOrdered
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int TargetSum = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine();

                input = input.Distinct().ToArray(); // Remove duplicates from array
                double combinations = 1 << input.Length; //find how many combination are possible

                List<int> targetSum = new List<int>();//collector for numbers that sum == n
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
                            targetSum.Add(input[input.Length - 1 - z]);
                        }
                    }

                    if (sum == TargetSum)
                    {
                        allSums.Add(targetSum);
                    }

                    targetSum.Reverse();
                    targetSum = new List<int>();//clear list
                }

                if (allSums.Count != 0)
                {

                    allSums
                        .OrderBy(s => s.Count)
                        .ThenBy(s => s.FirstOrDefault())
                        .ToList()
                        .ForEach(element => Console.WriteLine("{0} = {1} ", string.Join(" + ", element), TargetSum));
                }
                else
                {
                    Console.WriteLine("No matching subsets.");
                }

                Console.WriteLine();
            }
        }
    }
}
