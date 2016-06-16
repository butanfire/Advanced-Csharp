namespace Problem11.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main(string[] args)
        {
            List<string> inputRows = new List<string>();

            var rotateDegrees = Console.ReadLine();
            rotateDegrees = rotateDegrees.Substring(rotateDegrees.IndexOf('(') + 1, rotateDegrees.IndexOf(')') - rotateDegrees.IndexOf('(') - 1);

            var userInput = Console.ReadLine();
            while (userInput != "END")
            {
                inputRows.Add(userInput);
                userInput = Console.ReadLine();
            }

            var length = inputRows.Max(s => s.Length);
            var biggest = inputRows.FirstOrDefault(s => s.Length == length);

            char[,] matrix = new char[inputRows.Count, biggest.Length];

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            
            for (int xIndex = 0; xIndex < rows; xIndex++)
            {
                for (int yIndex = 0; yIndex < cols; yIndex++)
                {
                    if (yIndex >= inputRows[xIndex].Length)
                    {
                        matrix[xIndex, yIndex] = ' ';
                    }
                    else
                    {
                        matrix[xIndex, yIndex] = inputRows[xIndex][yIndex];
                    }
                }
            }

            PrintMatrix(Rotate(Convert.ToInt32(rotateDegrees), matrix));
            Console.WriteLine();
        }

        private static void PrintMatrix(char[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] Rotate(int degrees, char[,] matrix)
        {
            int rotation = degrees / 90;

            if (rotation == 0)
            {
                return matrix;
            }

            if (rotation == 1)
            {
                return Rotate90(matrix);
            }

            for (int i = 0; i < rotation; i++)
            {
                matrix = Rotate90(matrix);
            }

            return matrix;
        }

        private static char[,] Rotate90(char[,] matrix)
        {
            var oldRows = matrix.GetLength(0);
            var oldCols = matrix.GetLength(1);
            char[,] newMatrix = new char[oldCols, oldRows];

            var rows = newMatrix.GetLength(0);
            var cols = newMatrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int xIndex = oldRows - 1;
                for (int j = 0; j < cols; j++, xIndex--)
                {
                    newMatrix[i, j] = matrix[xIndex, i];
                }
            }

            return newMatrix;
        }
    }
}

