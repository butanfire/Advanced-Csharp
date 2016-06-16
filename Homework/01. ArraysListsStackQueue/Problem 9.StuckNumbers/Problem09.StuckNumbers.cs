namespace Problem09.StuckNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StuckNumbers
    {
        public static void Main()
        {
            int numberCount = int.Parse(Console.ReadLine());
            List<string> inputList = new List<string>();
            inputList = Console.ReadLine().Split(' ').ToList();
            List<string> outputList = new List<string>();

            for (int indexA = 0; indexA < numberCount; indexA++)
            {
                for (int indexB = 0; indexB < numberCount; indexB++)
                {
                    var numberA = inputList[indexA];
                    var numberB = inputList[indexB];
                    string numberABconcat = string.Concat(numberA, numberB);
                    for (int indexC = 0; indexC < numberCount; indexC++)
                    {
                        for (int indexD = 0; indexD < numberCount; indexD++)
                        {
                            var numberC = inputList[indexC];
                            var numberD = inputList[indexD];
                            string numberBCconcat = string.Concat(numberC, numberD);
                            bool isCandidate = numberA != numberB &&
                                            numberA != numberC &&
                                            numberA != numberD &&
                                            numberB != numberC &&
                                            numberB != numberD &&
                                            numberC != numberD &&
                                           numberABconcat == numberBCconcat;
                            if (isCandidate)
                            {
                                string strContactListOut = string.Concat(
                                    inputList[indexA], "|", inputList[indexB],
                                    "==",
                                    inputList[indexC], "|", inputList[indexD]);
                                outputList.Add(strContactListOut);
                            }
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