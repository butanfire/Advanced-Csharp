namespace Problem10.Plus_Remove
{
    using System;
    using System.Collections.Generic;

    public class PlusRemove
    {
        public static List<int> xIndex = new List<int>();
        public static List<int> yIndex = new List<int>();

        public static void Main(string[] args)
        {

            var input = Console.ReadLine();
            List<string> rows = new List<string>();
            int columns = 0;

            while (input != "END")
            {
                rows.Add(input);
                columns++;
                input = Console.ReadLine();
            }

            char[][] plusMatrix = new char[rows.Count][];

            for (int i = 0; i < rows.Count; i++)
            {
                plusMatrix[i] = rows[i].ToCharArray();
            }

            FindPlus(plusMatrix);
            DeletePlus(plusMatrix);
            PrintMatrix(plusMatrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            var rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j].ToString().Trim());
                }

                Console.WriteLine();
            }
        }

        private static void DeletePlus(char[][] matrix)
        {
            for (int i = 0; i < xIndex.Count; i++)
            {
                matrix[xIndex[i]][yIndex[i]] = ' ';
                matrix[xIndex[i] - 1][yIndex[i]] = ' ';
                matrix[xIndex[i] + 1][yIndex[i]] = ' ';
                matrix[xIndex[i]][yIndex[i] - 1] = ' ';
                matrix[xIndex[i]][yIndex[i] + 1] = ' ';
            }
        }

        private static void FindPlus(char[][] matrix)
        {
            var rows = matrix.GetLength(0) - 1;

            for (int i = 0; i < rows; i++)
            {
                var cols = matrix[i].Length - 1;
                for (int j = 0; j < cols; j++)
                {
                    if (i - 1 < 0 || i + 1 > rows ||
                        j + 1 > cols || j - 1 < 0 || 
                        j > matrix[i - 1].Length - 1 || j > matrix[i + 1].Length - 1)
                    {
                        continue;
                    }

                    var middleElement = matrix[i][j].ToString().ToLowerInvariant();
                    var topElement = matrix[i - 1][j].ToString().ToLowerInvariant();
                    var leftElement = matrix[i][j - 1].ToString().ToLowerInvariant();
                    var rightElement = matrix[i][j + 1].ToString().ToLowerInvariant();
                    var bottomElement = matrix[i + 1][j].ToString().ToLowerInvariant();

                    if (middleElement == topElement &&
                        middleElement == leftElement &&
                        middleElement == rightElement &&
                        middleElement == bottomElement)
                    {
                        xIndex.Add(i);
                        yIndex.Add(j);
                    }
                }
            }

        }
    }
}
