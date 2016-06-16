namespace Problem10.PythagoreanNumbers
{
    using System;
    using System.Collections.Generic;

    public class PythagoreanNumbers
    {
        public static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());
            int[] arrayOfNumbers = new int[numberCount];
            List<string> outputList = new List<string>();

            for (int index = 0; index < numberCount; index++)
            {
                arrayOfNumbers[index] = int.Parse(Console.ReadLine());
            }

            int maxIndex = arrayOfNumbers.Length;
            for (int indexA = 0; indexA < maxIndex; indexA++)
            {
                for (int indexB = 0; indexB < maxIndex; indexB++)
                {
                    for (int indexC = 0; indexC < maxIndex; indexC++)
                    {
                        var numberA = arrayOfNumbers[indexA];
                        var numberB = arrayOfNumbers[indexB];
                        var numberC = arrayOfNumbers[indexC];

                        if (numberA <= arrayOfNumbers[indexB] && Math.Pow(numberA, 2) + Math.Pow(numberB, 2) == Math.Pow(numberC, 2))
                        {
                            outputList.Add(string.Format("{0}*{0} + {1}*{1} = {2}*{2}",
                                arrayOfNumbers[indexA], arrayOfNumbers[indexB], arrayOfNumbers[indexC]));
                        }
                    }
                }
            }

            if (!(outputList.Count > 0))
            {
                Console.WriteLine("No");
            }

            else
            {
                outputList.ForEach(Console.WriteLine);
            }
        }
    }
}
