namespace _01.Collect_Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectResources
    {
        public static void Main()
        {
            //go through each line
            //collect each resource until collected the same
            //check max
            //output

            //valid resources - stone, gold, wood and food
            //when there is only one piece of a given resource, it can be written as wood or wood_1 (both are valid).
            string[] input = Console.ReadLine().ToLowerInvariant().Split(' ').ToArray();
            int lines = int.Parse(Console.ReadLine());
            int max = 0;

            List<int> initialCollector = new List<int>();
            for (int iterator = 0; iterator < lines; iterator++)
            {
                var stepInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int index = stepInput[0];
                int step = stepInput[1];
                step %= input.Length;
                bool condition = false;
                var tempMax = 0;
                while (!condition)
                {
                    var resource = input[index];
                    if (initialCollector.Contains(index))
                    {
                        condition = true;
                        initialCollector.Clear();
                        break;
                    }

                    initialCollector.Add(index);
                    index += step;
                    if (index >= input.Length)
                    {
                        index = index % input.Length;
                    }

                    string checkResource = string.Empty;
                    if (resource.Contains('_'))
                    {
                        var tempResource = resource.Split('_');
                        checkResource = tempResource[0];
                        int quantitiy = int.Parse(tempResource[1]);

                        if (checkResource == "stone" || checkResource == "gold" || checkResource == "wood" || checkResource == "food")
                        {
                            tempMax += quantitiy;
                        }
                    }
                    else
                    {
                        if (resource == "stone" || resource == "gold" || resource == "wood" || resource == "food")
                        {
                            tempMax++;
                        }
                    }
                }

                max = Math.Max(max, tempMax);
            }

            Console.Write(max);
        }
    }
}