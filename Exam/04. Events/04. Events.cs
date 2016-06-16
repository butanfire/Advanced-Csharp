namespace _04.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Events
    {
        public static void Main()
        {
            string personPattern = @"^#([a-zA-Z]*):\s*@([a-zA-Z]+)\s*(\d+:\d+)$";
            int numberOfEvents = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> eventsDict = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < numberOfEvents; i++)
            {
                string inputEvent = Console.ReadLine();
                Regex eventData = new Regex(personPattern);

                var personData = eventData.Match(inputEvent).Groups[1];
                string singer = personData.Value;
                var locationData = eventData.Match(inputEvent).Groups[2];
                string town = locationData.Value;

                //parsing date and time as strings and checking the hours/minutes manually
                int hours = -1;
                int minutes = -1;
                var timeData = eventData.Match(inputEvent).Groups[3];
                if (timeData.Value.Length > 0)
                {
                    var timeChecker = timeData.Value.Split(':').Select(int.Parse).ToArray();
                    hours = timeChecker[0];
                    minutes = timeChecker[1];
                }

                if (hours <= 23 && minutes <= 59 && minutes >= 0 && hours >= 0)
                {
                    if (!eventsDict.ContainsKey(town))
                    {
                        eventsDict.Add(town, new Dictionary<string, List<string>>());
                    }
                    if (!eventsDict[town].ContainsKey(singer))
                    {
                        eventsDict[town].Add(singer, new List<string>());
                    }
                    
                    eventsDict[town][singer].Add(timeData.Value.ToString());
                }
            }

            var locationsToPrint = Console.ReadLine().Split(',').ToList();
            foreach (var location in locationsToPrint.OrderBy(s => s).Where(location => eventsDict.ContainsKey(location)))
            {
                Console.WriteLine(("{0}:"), location);
                int iterator = 1;
                foreach (var singer in eventsDict[location].OrderBy(s => s.Key))
                {
                    var dates = singer.Value.OrderBy(s => s);
                    Console.WriteLine("{0}. {1} -> {2}", iterator++, singer.Key, string.Join((", "), dates));
                }
            }
        }
    }
}