namespace CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLowerInvariant();
            var occurrence = Console.ReadLine().ToLowerInvariant();

            int count = 0;
            int position = 0;

            while ((position = input.IndexOf(occurrence, position)) != -1)
            {
                count++;
                position++;
            }

            Console.WriteLine("{0}", count);
        }
    }
}
