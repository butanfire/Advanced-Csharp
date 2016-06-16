namespace Problem01.BiggerNumber
{
    using System;

    public class BiggerNumber
    {
        public static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(firstNumber, secondNumber));
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            return firstNumber > secondNumber ? firstNumber : secondNumber;
        }
    }
}
