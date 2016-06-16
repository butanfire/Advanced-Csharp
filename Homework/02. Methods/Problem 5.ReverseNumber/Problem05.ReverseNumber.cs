namespace Problem05.ReverseNumber
{
    using System;
    using System.Linq;

    public class ReverseNumber
    {
        public static void Main(string[] args)
        {
            double reversed = GetReversedNumber(123.45);
            Console.WriteLine(reversed);

            double input = double.Parse(Console.ReadLine());
            Console.WriteLine(GetReversedNumber(input));
        }

        private static double GetReversedNumber(double number)
        {
            var reversedNumber = number.ToString().Reverse();
            string reverse = string.Empty;

            foreach (char digit in reversedNumber)
            {
                reverse += digit;
            }

            return double.Parse(reverse);
        }
    }
}
