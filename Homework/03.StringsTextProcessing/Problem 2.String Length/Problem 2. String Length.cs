namespace StringLength
{
    using System;
    using System.Text;
    public class StringLength
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            StringBuilder output = new StringBuilder();

            if (input.Length < 20)
            {
                output.Append(string.Join("", input));
                output.Append(new string('*', 20 - input.Length));                
            }

            else
            {
                for(int i = 0; i < 20; i++)
                {
                    output.Append(input[i]);
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
