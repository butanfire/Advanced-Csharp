namespace Problem01.SortArray
{
    using System;
    using System.Linq;

    public class SortArray
    {
        public static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            values.Sort();
            Console.WriteLine(string.Join(" ", values));
        }
    }
}
