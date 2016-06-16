namespace Problem03.MatrixShuffling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatrixShuffling
    {
        public static void Main(string[] args)
        {
            var xLength = int.Parse(Console.ReadLine());  //get the X / Y boundaries
            var yLength = int.Parse(Console.ReadLine());

            string[,] matrix = new string[xLength, yLength];

            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                var commandInput = input.Split(' ').ToList();
                if (commandInput[0] == "swap")
                {
                    commandInput.Remove("swap");
                    var coords = commandInput.Select(int.Parse).ToList();
                    SwapCommand(coords, xLength, yLength, matrix);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        public static void SwapCommand(List<int> coordinates, int xLength, int yLength, string[,] matrix)
        {
            int firstXcoord = coordinates[0];
            int firstYcoord = coordinates[1];

            int secondXcoord = coordinates[2];
            int secondYcoord = coordinates[3];

            if (coordinates.Count != 4 ||
                ((firstXcoord > xLength || firstYcoord > yLength) ||
                (secondXcoord > xLength || secondYcoord > yLength)))
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                string firstElement = matrix[firstXcoord, firstYcoord];
                string secondElement = matrix[secondXcoord, secondYcoord];
                Console.WriteLine("after swapping {0} and {1}):\n", firstElement, secondElement);

                string tempValue = firstElement;
                matrix[firstXcoord, firstYcoord] = secondElement;
                matrix[secondXcoord, secondYcoord] = tempValue;

                PrintMatrix(matrix, xLength, yLength);
            }
        }

        public static void PrintMatrix(string[,] matrix, int xLength, int yLength)
        {
            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    Console.Write(string.Format(matrix[i, j] + " "));
                }

                Console.WriteLine();
            }
        }
    }
}
