namespace Problem01.ArrayManipulator
{
    using System;
    using System.Linq;

    public class ArrayManipulator
    {
        public static void Main(string[] args)
        {
            int[] numberArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                var arguments = input.Split(' ');
                string command = arguments[0];

                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(arguments[1]);
                        if (index < 0 || index >= numberArray.Length)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numberArray = Exchange(numberArray, int.Parse(arguments[1]) + 1);
                        }
                        break;
                    case "max":
                        Console.WriteLine(arguments[1] == "odd" ? MaxOdd(numberArray) : MaxEven(numberArray));
                        break;
                    case "min":
                        Console.WriteLine(arguments[1] == "odd" ? MinOdd(numberArray) : MinEven(numberArray));
                        break;
                    case "first":
                        int count = int.Parse(arguments[1]);
                        Console.WriteLine(arguments[2] == "odd"
                            ? FirstOdd(numberArray, count)
                            : FirstEven(numberArray, count));
                        break;
                    case "last":
                        Console.WriteLine(arguments[2] == "odd"
                            ? LastOdd(numberArray, int.Parse(arguments[1]))
                            : LastEven(numberArray, int.Parse(arguments[1])));
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", numberArray));
        }

        public static string FirstEven(int[] array, int count)
        {
            if (count > array.Length)
            {
                return "Invalid count";
            }

            int[] filtered = array.Where(n => n % 2 == 0).ToArray();


            return "[" + string.Join(", ", filtered.Take(count)) + "]";
        }

        public static string FirstOdd(int[] array, int count)
        {
            if (count > array.Length)
            {
                return "Invalid count";
            }

            int[] filtered = array.Where(n => n % 2 == 1).ToArray();

            return "[" + string.Join(", ", filtered.Take(count)) + "]";
        }
        public static string LastOdd(int[] array, int count)
        {
            if (count > array.Length)
            {
                return "Invalid count";
            }

            int[] filtered = array.Where(n => n % 2 == 1).ToArray();

            return "[" + string.Join(", ", filtered.Reverse().Take(count).Reverse()) + "]";
        }

        public static string LastEven(int[] array, int count)
        {
            if (count > array.Length)
            {
                return "Invalid count";
            }

            int[] filtered = array.Where(n => n % 2 == 0).ToArray();

            return "[" + string.Join(", ", filtered.Reverse().Take(count).Reverse()) + "]";
        }

        public static string MaxEven(int[] array)
        {
            var filteredArray = array.Where(s => s % 2 == 0).ToArray();
            return !filteredArray.Any() ? 
                "No matches" : 
                Array.LastIndexOf(array, filteredArray.Max()).ToString();
        }

        public static string MaxOdd(int[] array)
        {
            var filteredArray = array.Where(s => s % 2 == 1).ToArray();
            return !filteredArray.Any() ? 
                "No matches" : 
                Array.LastIndexOf(array, filteredArray.Max()).ToString();
        }

        public static string MinEven(int[] array)
        {
            var filteredArray = array.Where(s => s % 2 == 0).ToArray();
            return !filteredArray.Any() ? 
                "No matches" : 
                Array.LastIndexOf(array, filteredArray.Min()).ToString();
        }

        public static string MinOdd(int[] array)
        {
            var filteredArray = array.Where(s => s % 2 == 1).ToArray();
            return !filteredArray.Any() ? 
                "No matches" : 
                Array.LastIndexOf(array, filteredArray.Min()).ToString();
        }

        public static int[] Exchange(int[] array, int index)
        {
            return array.Skip(index).Concat(array.Take(index)).ToArray();
        }
    }
}
