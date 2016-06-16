namespace Problem09.TerroristsWin
{
    using System;
    using System.Collections.Generic;

    public class TerroristsWin
    {
        //created a structure for easier managing the Bombs
        public struct Bomb
        {
            public string content { get; set; }
            public int damage { get; set; }
            public int indexStart { get; set; }
            public int indexEnd { get; set; }
        }

        public static void Main(string[] args) //the official Java solution is much more simple :)
        {
            string input = Console.ReadLine();

            List<Bomb> bombList = new List<Bomb>();
            List<int> bombIndexes = new List<int>();

            //find all bomb indexes
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '|')
                {
                    bombIndexes.Add(i);
                }
            }

            //add all bomb indexes
            for (int i = 0; i < bombIndexes.Count; i += 2)
            {
                bombList.Add(new Bomb()
                {
                    content = input.Substring(bombIndexes[i], bombIndexes[i + 1] - bombIndexes[i]),
                    indexStart = bombIndexes[i],
                    indexEnd = bombIndexes[i + 1]
                });
            }

            var tempInput = input.ToCharArray();

            //calculate and explode all bombs
            for (int i = 0; i < bombList.Count; i++)
            {
                var bomb = bombList[i];
                bomb.damage = CalculateBomb(bomb.content.Substring(1, bomb.content.Length - 1));
                tempInput = ExplodeBomb(bomb, tempInput);
            }

            //output the map
            foreach (char s in tempInput)
            {
                Console.Write(s);
            }
        }
        
        public static int CalculateBomb(string bombContent)
        {
            int damage = 0;

            foreach (char s in bombContent)
            {
                damage += s;
            }

            return damage % 10;
        }

        public static char[] ExplodeBomb(Bomb bomb, char[] input)
        {
            int posStart = bomb.indexStart - bomb.damage;
            if (posStart <= 0)
            {
                posStart = 0;
            }

            int posEnd = bomb.indexEnd + bomb.damage;
            if (posEnd >= input.Length)
            {
                posEnd = input.Length - 1;
            }

            for (int i = posStart; i <= posEnd; i++)
            {
                input[i] = '.';
            }

            return input;
        }
    }
}
