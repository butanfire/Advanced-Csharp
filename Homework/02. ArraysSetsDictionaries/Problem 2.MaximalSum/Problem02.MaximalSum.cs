namespace Problem02.MaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxSum
    {
        public const int xLengthSubMatrix = 3;
        public const int yLengthSubMatrix = 3;
        public static List<int> maxSumList = new List<int>();
        public static List<int[,]> matrixList = new List<int[,]>();

        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int xLength = input[0]; //get the X / Y boundaries
            int yLength = input[1];

            int[,] matrix = new int[xLength, yLength];

            for (int i = 0; i < xLength; i++)
            {
                var numbersInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                for (int j = 0; j < yLength; j++)
                {
                    matrix[i, j] = numbersInput[j];
                }
            }

            CreateSubMatrix(matrix, xLength, yLength);
            Console.WriteLine();
            //we use the aligned lists for the sub-matrix and the Sum for each one of them.
            int sumIndex = FindSumIndex(maxSumList); //get the sub matrix ID with the largest Sum
            PrintMatrix(matrixList[sumIndex]); //print the sub matrix
        }

        public static void CreateSubMatrix(int[,] matrix, int xLengthMatrix, int yLengthMatrix) 
        {
            int tempYindex = 0; //we use the tempYindex to align the indexes of the maxSumList to the matrixList
            for (int xIndex = 0; xIndex < xLengthMatrix; xIndex++)
            {
                for (int yIndex = 0; yIndex < yLengthMatrix; yIndex++)
                {
                    {
                        bool checkXBoundaries = xIndex + xLengthSubMatrix > xLengthMatrix;
                        bool checkYBoundaries = yIndex + yLengthSubMatrix > yLengthMatrix;
                        if (checkXBoundaries || checkYBoundaries) //check whether we go outside the source matrix
                        {
                            continue; //if the found matrix does not fit the boundaries, continue searching
                        }

                        matrixList.Add(
                            CopyMatrix(matrix,
                                new int[xLengthSubMatrix, yLengthSubMatrix], //create a new two-dimensional array for the sub matrix, to be added in the matrixList
                                xIndex, //use the xIndex/yIndex of the source matrix to copy the numbers to the new two-dimentional array
                                yIndex));

                        maxSumList.Add(CalculateSum(matrixList[tempYindex])); //we add the sum for each found matrix in the maxSumList in order to find the largest afterwards.
                        tempYindex++;
                    }
                }
            }
        }

        public static int[,] CopyMatrix(int[,] matrix, int[,] subMatrix, int xIndex, int yIndex) //copy the numbers from the source matrix to the subMatrix, starting from xIndex/yIndex from the source matrix.
        {
            int sourceYindex = yIndex; //we use a temp int to keep the position of the source matrix Y position

            for (int xResultIndex = 0; xResultIndex < xLengthSubMatrix; xIndex++, xResultIndex++)
            {
                for (int yResultIndex = 0; yResultIndex < yLengthSubMatrix; yIndex++, yResultIndex++)
                {
                    subMatrix[xResultIndex, yResultIndex] = matrix[xIndex, yIndex];
                }

                yIndex = sourceYindex; //we start on the next xIndex, and from the starting yIndex from the source matrix.
            }

            return subMatrix;
        }

        public static int CalculateSum(int[,] matrix) // calculate the Sum of all numbers in the sub matrix
        {
            if (matrix == null) //if the found matrix does not meet the X or Y boundaries
            {
                return int.MinValue;
            }

            int sum = 0;
            for (int xIndex = 0; xIndex < xLengthSubMatrix; xIndex++) //iterate through the candidate matrix to get the sum of the matrix numbers
            {
                for (int yIndex = 0; yIndex < yLengthSubMatrix; yIndex++)
                {
                    sum += matrix[xIndex, yIndex];
                }
            }

            return sum;
        }

        public static int FindSumIndex(List<int> maxSum) //find the index of the largest Sum of all sub matrix 
        {
            int matrixSumMax = 0;
            int findIndex = 0;

            for (int i = 0; i < maxSum.Count; i++)
            {
                int tempSum = matrixSumMax; //get the latest matrixSumMax
                matrixSumMax = Math.Max(matrixSumMax, maxSum[i]); //if there is a larger Sum, assign it to matrixSumMax
                if (tempSum != matrixSumMax) //if matrixSumMax has changed
                {
                    findIndex = i; //assign the index of the sub-matrix with the largest Sum
                }
            }

            Console.WriteLine("Sum = {0}", matrixSumMax);
            return findIndex;
        }

        public static void PrintMatrix(int[,] matrix) //print the sub matrix 
        {
            for (int xIndex = 0; xIndex < xLengthSubMatrix; xIndex++)
            {
                for (int yIndex = 0; yIndex < yLengthSubMatrix; yIndex++)
                {
                    Console.Write("{0} ", matrix[xIndex, yIndex]);
                }

                Console.WriteLine();
            }
        }

    }
}

