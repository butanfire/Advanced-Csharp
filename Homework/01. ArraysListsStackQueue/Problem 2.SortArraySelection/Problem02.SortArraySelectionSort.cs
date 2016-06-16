namespace Problem02.SortArraySelectionSort
{
    using System;
    using System.Linq;

    public class SortArraySelection
    {
        public static void SelectionSort(int[] array)
        {
            for (int prevIndex = 0; prevIndex < array.Length - 1; prevIndex++)
            {
                int prevElementIndex = prevIndex;

                for (int currentIndex = prevIndex + 1; currentIndex < array.Length; currentIndex++)
                {
                    if (array[currentIndex] < array[prevElementIndex])
                    {
                        prevElementIndex = currentIndex;

                        array[prevIndex] ^= array[prevElementIndex];
                        array[prevElementIndex] ^= array[prevIndex];
                        array[prevIndex] ^= array[prevElementIndex];

                        prevElementIndex = prevIndex;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            SelectionSort(values);
            Console.WriteLine(string.Join(" ", values));
        }
    }
}
