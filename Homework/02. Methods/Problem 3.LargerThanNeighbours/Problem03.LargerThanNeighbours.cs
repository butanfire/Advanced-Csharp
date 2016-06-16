namespace Problem03.LargerThanNeighbours
{
    using System;

    public class LargerThanNeighbour
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbers, i));
            }
        }

        private static bool IsLargerThanNeighbours(int[] numbers, int i)
        {
            if (i == 0)
            {
                return numbers[i] > numbers[i + 1];
            }

            if (i == numbers.Length - 1)
            {
                return numbers[i] > numbers[i - 1];
            }

            return numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1];
        }
    }
}
