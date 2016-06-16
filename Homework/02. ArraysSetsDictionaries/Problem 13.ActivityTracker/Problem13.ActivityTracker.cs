namespace Problem13.ActivityTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActivityTracker
    {
        public static void Main(string[] args)
        {
            var inputLines = int.Parse(Console.ReadLine());

            Dictionary<int, Dictionary<string, int>> activityDict = new Dictionary<int, Dictionary<string, int>>();
            for (int i = 0; i < inputLines; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                var date = input[0].Split('/').ToList();

                int monthDate = int.Parse(date[1]); //extracting the month date
                string user = input[1];
                int distance = int.Parse(input[2]);

                if (!activityDict.ContainsKey(monthDate))
                {
                    Dictionary<string, int> users = new Dictionary<string, int> { { input[1], distance } };
                    activityDict.Add(monthDate, users);
                }
                else
                {
                    Dictionary<string, int> users = activityDict[monthDate];
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, distance);
                    }
                    else
                    {
                        users[user] += distance;
                    }
                }
            }
            
            List<string> output = new List<string>();
            foreach (var month in activityDict.OrderBy(s => s.Key))
            {
                output.AddRange(month.Value.OrderBy(s => s.Key).Select(user => user.Key + "(" + user.Value + ")"));
                Console.WriteLine("{0}: {1}", month.Key, string.Join(", ", output));
                output.Clear();
            }
        }
    }
}

