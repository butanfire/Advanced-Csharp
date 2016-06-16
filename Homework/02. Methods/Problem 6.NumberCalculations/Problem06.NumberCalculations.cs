namespace Problem06.NumberCalculations
{
    using System;

    public class NumberCalculation
    {
        public static void Main(string[] args)
        {
            int[] sequence = { 1, 2, 3, 4, 5, 6, 6 };
            Console.WriteLine("Min :" + FindMin(sequence));
            Console.WriteLine("Max :" + FindMax(sequence));
            Console.WriteLine("Sum :" + FindSum(sequence));
            Console.WriteLine("Average :" + FindAverage(sequence));
            Console.WriteLine("Product :" + FindProduct(sequence));

            Console.WriteLine();

            double[] sequenceD = { 1.5, 2.2, 3.4, 4.4, 5.1, 6.2, 6.3 };
            Console.WriteLine("Min :" + FindMin(sequenceD));
            Console.WriteLine("Max :" + FindMax(sequenceD));
            Console.WriteLine("Sum :" + FindSum(sequenceD));
            Console.WriteLine("Average :" + FindAverage(sequenceD));
            Console.WriteLine("Product :" + FindProduct(sequenceD));

            Console.WriteLine();

            decimal[] sequenceDec = { 1.324M, 2.342M, 3.15M, 4.441M, 5.555M, 6.324M, 7.327M };
            Console.WriteLine("Min :" + FindMin(sequenceDec));
            Console.WriteLine("Max :" + FindMax(sequenceDec));
            Console.WriteLine("Sum :" + FindSum(sequenceDec));
            Console.WriteLine("Average :" + FindAverage(sequenceDec));
            Console.WriteLine("Product :" + FindProduct(sequenceDec));
        }

        private static int FindMin(int[] sequence)
        {
            int min = int.MaxValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (min > sequence[i])
                {
                    min = sequence[i];
                }
            }

            return min;
        }
        private static double FindMin(double[] sequence)
        {
            double min = double.MaxValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (min > sequence[i])
                {
                    min = sequence[i];
                }
            }

            return min;
        }
        private static decimal FindMin(decimal[] sequence)
        {
            decimal min = decimal.MaxValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (min > sequence[i])
                {
                    min = sequence[i];
                }
            }

            return min;
        }

        private static int FindMax(int[] sequence)
        {
            int max = int.MinValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (max < sequence[i])
                {
                    max = sequence[i];
                }
            }

            return max;
        }
        private static double FindMax(double[] sequence)
        {
            double max = double.MinValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (max < sequence[i])
                {
                    max = sequence[i];
                }
            }

            return max;
        }
        private static decimal FindMax(decimal[] sequence)
        {
            decimal max = decimal.MinValue;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (max < sequence[i])
                {
                    max = sequence[i];
                }
            }

            return max;
        }

        private static int FindSum(int[] sequence)
        {
            int sum = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }

            return sum;
        }
        private static double FindSum(double[] sequence)
        {
            double sum = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }

            return sum;
        }
        private static decimal FindSum(decimal[] sequence)
        {
            decimal sum = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }

            return sum;
        }

        private static int FindAverage(int[] sequence)
        {
            return FindSum(sequence) / sequence.Length;
        }
        private static double FindAverage(double[] sequence)
        {
            return FindSum(sequence) / sequence.Length;
        }
        private static decimal FindAverage(decimal[] sequence)
        {
            return FindSum(sequence) / sequence.Length;
        }

        private static int FindProduct(int[] sequence)
        {
            int product = 1;

            for (int i = 0; i < sequence.Length; i++)
            {
                product *= sequence[i];
            }

            return product;
        }
        private static double FindProduct(double[] sequence)
        {
            double product = 1;

            for (int i = 0; i < sequence.Length; i++)
            {
                product *= sequence[i];
            }

            return product;
        }
        private static decimal FindProduct(decimal[] sequence)
        {
            decimal product = 1;

            for (int i = 0; i < sequence.Length; i++)
            {
                product *= sequence[i];
            }

            return product;
        }
    }
}
