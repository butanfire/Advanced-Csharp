namespace Problem08.NightLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NightLife
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> nightLife = new Dictionary<string, Dictionary<string, List<string>>>();

            string userInput = Console.ReadLine();
            while (userInput != "END")
            {
                var input = userInput.Split(';').ToList();
                var city = input[0];
                var venue = input[1];
                var performer = input[2];

                if (!nightLife.ContainsKey(city))
                {
                    nightLife.Add(city, new Dictionary<string, List<string>>());
                    nightLife[city].Add(venue, new List<string>());
                    nightLife[city][venue].Add(performer);
                }
                else
                {
                    if (!nightLife[city].ContainsKey(venue))
                    {
                        nightLife[city].Add(venue, new List<string>());
                        nightLife[city][venue].Add(performer);
                    }
                    else
                    {
                        if (!nightLife[city][venue].Contains(performer))
                        {
                            nightLife[city][venue].Add(performer);
                        }
                    }
                }

                userInput = Console.ReadLine();
            }

            foreach (var city in nightLife)
            {
                Console.WriteLine(city.Key);
                foreach (var venue in nightLife[city.Key].OrderBy(s => s.Key))
                {
                    venue.Value.Sort();
                    Console.WriteLine("->" + venue.Key + ": " + string.Join(", ", venue.Value));
                }
            }
        }
    }
}
