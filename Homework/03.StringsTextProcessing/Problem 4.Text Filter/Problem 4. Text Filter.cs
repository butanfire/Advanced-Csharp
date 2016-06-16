namespace TextFilter
{
    using System;
    using System.Linq;

    public class TextFilter
    {
        public static void Main(string[] args)
        {
            var banWords = Console.ReadLine().Split(',').ToList();

            for (int i = 0; i < banWords.Count; i++)
            {
                if (banWords[i].Contains(" "))
                {
                    banWords[i] = banWords[i].Remove(0, 1);
                }
            }
            
            var inputText = Console.ReadLine();

            foreach (var word in banWords)
            {
                inputText = inputText.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(inputText);
        }
    }
}
