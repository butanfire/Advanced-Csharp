namespace Problem_1.Odd_Lines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main(string[] args)
        {
            string readPath = @"input.txt";
            int oddCounter = 0;

            using (var reader = new StreamReader(readPath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    oddCounter++;
                    if (oddCounter % 2 != 0)
                    {
                        foreach (char letter in line)
                        {
                            Console.Write(letter);
                        }

                        Console.WriteLine();
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}

