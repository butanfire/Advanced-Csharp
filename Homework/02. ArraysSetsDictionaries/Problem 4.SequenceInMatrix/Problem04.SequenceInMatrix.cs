using System.Collections.Generic;

namespace Problem04.SequenceInMatrix
{
    using System;

    public class SequenceInMatrix
    {

        public static void Main(string[] args)
        {
            string[,] inputMatrixExample1 = new string[3, 4]
                {
                {"ha", "fifi", "ho", "hi"},
                { "fo", "ha", "hi", "xx"},
                { "xxx", "ho","ha", "xx" }
                };

            string[,] inputMatrixExample2 = new string[3, 3]
            {
                {  "s","qq","s" },
                { "pp","pp","s" },
                { "pp","qq","s" }
            };

            string[,] inputMatrix = inputMatrixExample1;

            int xLength = inputMatrix.GetLength(0); //get the X / Y boundaries
            int yLength = inputMatrix.GetLength(1);

            string[,] matrix = new string[xLength, yLength];

            for (int xIndex = 0; xIndex < xLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < yLength; yIndex++)
                {
                    matrix[xIndex, yIndex] = inputMatrix[xIndex, yIndex];
                }
            }

            string printSequence = string.Empty;
            int[] sequenceIndexes = new int[2];
            int max = 0;

            for (int xIndex = 0; xIndex < xLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < yLength; yIndex++)
                {
                    int temp = max;

                    max = Math.Max(SearchDiagonal(matrix, xIndex, yIndex, xLength, yLength), max);
                    if (temp != max)
                    {
                        temp = max;
                        sequenceIndexes = SaveCoordinates(sequenceIndexes, xIndex, yIndex);
                        printSequence = "Diagonal";
                    }

                    max = Math.Max(SearchHorizontal(matrix, yLength, xIndex, yIndex), max);
                    if (temp != max)
                    {
                        temp = max;
                        sequenceIndexes = SaveCoordinates(sequenceIndexes, xIndex, yIndex);
                        printSequence = "Horizontal";
                    }

                    max = Math.Max(SearchVertical(matrix, xLength, xIndex, yIndex), max);
                    if (temp != max)
                    {
                        sequenceIndexes = SaveCoordinates(sequenceIndexes, xIndex, yIndex);
                        printSequence = "Vertical";
                    }
                }
            }

            switch (printSequence)
            {
                case "Diagonal":
                    PrintDiagonal(matrix, sequenceIndexes, max);
                    break;
                case "Horizontal":
                    PrintHorizontal(matrix, sequenceIndexes, max);
                    break;
                case "Vertical":
                    PrintVertical(matrix, sequenceIndexes, max);
                    break;
            }
        }

        private static void PrintVertical(string[,] matrix, int[] sequenceIndexes, int max)
        {
            List<string> outputList = new List<string>();

            for (int xIndex = sequenceIndexes[0]; xIndex < matrix.GetLength(0) && max > 0; xIndex++)
            {
                outputList.Add(matrix[xIndex, sequenceIndexes[1]]);
                max--;
            }

            Console.WriteLine(string.Join(", ", outputList));
        }

        private static void PrintHorizontal(string[,] matrix, int[] sequenceIndexes, int max)
        {
            List<string> outputList = new List<string>();
            for (int yIndex = sequenceIndexes[1]; yIndex < matrix.GetLength(1) && max > 0; yIndex++)
            {
                outputList.Add(matrix[sequenceIndexes[0], yIndex]);
                max--;
            }

            Console.WriteLine(string.Join(", ", outputList));
        }

        private static void PrintDiagonal(string[,] matrix, int[] sequenceIndexes, int max)
        {
            List<string> outputList = new List<string>();
            for (int xIndex = sequenceIndexes[0]; xIndex < matrix.GetLength(0); xIndex++)
            {
                for (int yIndex = sequenceIndexes[1]; yIndex < matrix.GetLength(1) && max > 0; yIndex++)
                {
                    if (xIndex == yIndex)
                    {
                        outputList.Add(matrix[xIndex, yIndex]);
                        max--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ",outputList));
        }

        public static int[] SaveCoordinates(int[] sequenceIndexes, int xIndex, int yIndex)
        {
            sequenceIndexes[0] = xIndex;
            sequenceIndexes[1] = yIndex;

            return sequenceIndexes;
        }

        public static int SearchDiagonal(string[,] matrix, int xCoord, int yCoord, int xLength, int yLength)
        {
            int count = 0;
            string element = matrix[xCoord, yCoord];
            for (int xIndex = xCoord; xIndex < xLength; xIndex++)
            {
                for (int yIndex = yCoord; yIndex < yLength; yIndex++)
                {
                    if (xIndex == yIndex)
                    {
                        if (element == matrix[xIndex, yIndex])
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public static int SearchHorizontal(string[,] matrix, int yLength, int xCoord, int yCoord)
        {
            int count = 0;
            string element = matrix[xCoord, yCoord];
            for (int yIndex = yCoord; yIndex < yLength; yIndex++)
            {
                if (element == matrix[xCoord, yIndex])
                {
                    count++;
                }
            }

            return count;
        }

        public static int SearchVertical(string[,] matrix, int xLength, int xCoord, int yCoord)
        {
            int count = 0;
            string element = matrix[xCoord, yCoord];
            for (int xIndex = xCoord; xIndex < xLength; xIndex++)
            {
                if (element == matrix[xIndex, yCoord])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
