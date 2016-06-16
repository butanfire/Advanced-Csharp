namespace Problem08.LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());
            Dictionary<int, List<int>> matrix = new Dictionary<int, List<int>>();
            
            for (int i = 0; i < 2 * numOfRows; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                matrix.Add(i, input); //we use the iterator as a key, and the 2nd array is  numOfRows + i
            }

            List<int> matrixRowLength = new List<int>(); //list will check the length of the resulting matrix
            
            for (int i = 0; i < numOfRows; i++)
            {
                int sum = matrix[i].Count + matrix[i + numOfRows].Count; //calculate the number of elements from both arrays for each line
                matrixRowLength.Add(sum);
            }

            bool canArraysFit = true;
            for (int i = 0; i < matrixRowLength.Count - 1; i++)
            {
                canArraysFit = matrixRowLength[i] == matrixRowLength[i + 1]; //if there is a row in the sequence, which is not equal to the others, then the arrays cannot fit
            }

            if (!canArraysFit)
            {
                Console.WriteLine("The total number of cells is: {0}", matrixRowLength.Sum());
            }
            else
            {
                Dictionary<int, List<int>> resultMatrix = new Dictionary<int, List<int>>(); //result matrix will be used for the output
                for (int i = 0; i < numOfRows; i++)
                {
                    matrix[i + numOfRows].Reverse(); //reverse the line from the 2nd array
                    resultMatrix.Add(i, matrix[i]); //add the first line from the 1st array
                    resultMatrix[i].AddRange(matrix[i + numOfRows]); //add the reversed line

                    Console.WriteLine("[{0}]", string.Join(", ", matrix[i])); //output the result
                }
            }
        }
    }
}
