namespace Problem_5.Unicode_Characters
{
    using System;

    public class UnicodeCharacters
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            foreach (char number in input)
            {
                Console.Write("\\u{0:x4}", (int)number);
            }
        }
    }
}
