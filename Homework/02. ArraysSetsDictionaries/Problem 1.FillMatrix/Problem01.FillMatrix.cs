namespace Problem01.FillMatrix
{
    using System;

    public class FillMatrix
    {
        public static void PrintMatrix(int[,] array)
        {
            int maxIndex = array.GetLength(0);

            for (int i = 0; i < maxIndex; i++)
            {
                for (int j = 0; j < maxIndex; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void FillPatternA(int[,] array)
        {
            int fillingNumber = 1;
            int maxIndex = array.GetLength(0);

            for (int i = 0; i < maxIndex; i++)
            {
                for (int j = 0; j < maxIndex; j++)
                {
                    array[j, i] = fillingNumber++;
                }
            }
        }

        public static void FillPatternB(int[,] array)
        {
            int fillingNumber = 1;
            int maxIndex = array.GetLength(0);

            for (int i = 0; i < maxIndex; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < maxIndex; j++)
                    {
                        array[j, i] = fillingNumber++;
                    }
                }
                else
                {
                    for (int j = maxIndex - 1; j >= 0; j--)
                    {
                        array[j, i] = fillingNumber++;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int inputN = int.Parse(Console.ReadLine());
            int[,] matrix = new int[inputN, inputN];
            //FillPatternA(matrix);
            FillPatternB(matrix);
            PrintMatrix(matrix);
        }
    }
}
