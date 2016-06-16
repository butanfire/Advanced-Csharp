namespace Problem_2.ReplaceAtag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceAtag
    {
        public static void Main(string[] args)
        {
            //var input1 = "<ul> <li>  <a href="http://softuni.bg">SoftUni</a> </li></ul>"
            //var input2 = "<ul> <li> <a href='http://softuni.bg'>SoftUni </a> </li> </ul>"

            var input = Console.ReadLine();
            string output = input;

            output = Regex.Replace(output, @"(\<a)", @"[URL");
            output = Regex.Replace(output, @"(\W{2}a\W{1})", @"[/URL]");
            output = Regex.Replace(output, @"(.bg\W{2})", @".bg]");
            output = Regex.Replace(output, @"(=\W{1})", @"=[");

            Console.WriteLine(output);
        }
    }
}
