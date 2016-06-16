namespace Problem07.GenericArraySort
{
    using System;

    public class GenericArraySort
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
            string[] strings = { "zaz", "cba", "baa", "azis" };
            DateTime[] dates =
            {
                new DateTime(2002,3,1), new DateTime(2015,5,6), new DateTime(2014,1,1)
            };
            
            SortArray(numbers);
            PrintArray(numbers);

            Console.WriteLine();

            SortArray(strings);
            PrintArray(strings);

            Console.WriteLine();
            
            SortArray(dates);
            PrintArray(dates);
        }

        private static void PrintArray<T>(T[] numbers)
        {
            foreach (T number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        private static void SortArray<T>(T[] numbers) where T : IComparable<T>
        {
            for (int s = 0; s < numbers.Length - 1; s++)
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int res = numbers[i].CompareTo(numbers[i + 1]);
                    if (res > 0)
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                    }
                }
            }
        }
    }
}

