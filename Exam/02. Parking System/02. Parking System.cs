namespace _02.Parking_System
{
    using System;
    using System.Linq;

    public static class ParkingSystem
    {
        public static void Main()
        {

            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols]; //have to switch from matrix to list or Dictionary + Hashset

            for (int i = 0; i < rows; i++)
            {
                matrix[i, 0] = 0;
                for (int j = 1; j < cols; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var coordinates = input.Split(' ').Select(int.Parse).ToList();
                int startIndex = coordinates[0];
                int destinationRow = coordinates[1];
                int destinationCol = coordinates[2];
                int steps = 1;
                bool isParked = false;
                bool parkSlotsFull = destinationRow == 0 && destinationCol == 0;
                int tempCol = destinationCol;

                if (parkSlotsFull)
                {
                    Console.WriteLine("Row {0} full", destinationRow);
                }
                else
                {
                    steps += Math.Abs(destinationRow - startIndex);

                    while (isParked == false)
                    {
                        //combine both while loops
                        if (matrix[destinationRow, destinationCol] == 0)
                        {
                            while (tempCol < matrix.GetLength(1) && tempCol > 0)
                            {
                                if (matrix[destinationRow, tempCol] != 0)
                                {
                                    matrix[destinationRow, tempCol] = 0;
                                    isParked = true;
                                    steps += tempCol;
                                    break;
                                }

                                tempCol--;
                            }

                            tempCol = destinationCol;
                            if (tempCol == destinationCol && isParked == false)
                            {
                                while (tempCol < matrix.GetLength(1))
                                {
                                    if (matrix[destinationRow, tempCol] != 0)
                                    {
                                        matrix[destinationRow, tempCol] = 0;
                                        isParked = true;
                                        steps += tempCol;
                                        break;
                                    }

                                    tempCol++;
                                }
                            }
                        }
                        else
                        {
                            steps += destinationCol;
                            matrix[destinationRow, destinationCol] = 0;
                            isParked = true;
                        }

                        if (tempCol == matrix.GetLength(1))
                        {
                            break;
                        }
                    }
                }

                if (isParked == false)
                {
                    Console.WriteLine("Row {0} full", destinationRow);
                }
                else
                {
                    Console.WriteLine(steps);
                }

                input = Console.ReadLine();
            }
        }
    }
}