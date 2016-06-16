namespace Problem_7.Letters_Change_Numbers
{
    using System;
    using System.Linq;

    public class LetterChangeNumbers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            double result = 0;

            foreach (var element in input)
            {
                double number = Convert.ToDouble(element.Substring(1, element.Length - 2));
                var letterBeforeNumber = element.ElementAt(0);

                if (char.IsUpper(letterBeforeNumber))
                {
                    number /= LetterPosition(letterBeforeNumber);
                }
                else
                {
                    number *= LetterPosition(letterBeforeNumber);
                }

                var letterAfterNumber = element.ElementAt(element.Length - 1);
                if (char.IsUpper(letterAfterNumber))
                {
                    number -= LetterPosition(letterAfterNumber);
                }
                else
                {
                    number += LetterPosition(letterAfterNumber);
                }

                result += number;
            }

            Console.WriteLine("{0:F2}", result);
        }

        private static int LetterPosition(char c)
        {
            if (char.IsUpper(c))
            {
                return c - 64;
            }

            return c - 96;
        }
    }
}
