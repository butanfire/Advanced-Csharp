namespace Problem12.TotheStars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TotheStars
    {
        public struct StarSystem
        {
            public string name { get; set; }
            public StarPoint coords { get; set; }
        }

        public struct StarPoint
        {
            public double xCoord { get; set; }
            public double yCoord { get; set; }
        }

        public static void Main(string[] args)
        {
            List<StarSystem> starSystems = new List<StarSystem>();

            for (int i = 0; i < 3; i++)
            {
                var starSystemsInput = Console.ReadLine().Split(' ');
                starSystems.Add(new StarSystem()
                {
                    name = starSystemsInput[0].ToLowerInvariant(),
                    coords = new StarPoint()
                    {
                        xCoord = double.Parse(starSystemsInput[1]),
                        yCoord = double.Parse(starSystemsInput[2])
                    }
                });
            }

            var normandyInput = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            StarPoint normandy = new StarPoint
            {
                xCoord = normandyInput[0],
                yCoord = normandyInput[1]
            };

            int turns = int.Parse(Console.ReadLine());

            for (int i = 0; i <= turns; i++)
            {
                bool inSpace = true;
                foreach (var system in starSystems.Where(system => InsideSystem(system, normandy)))
                {
                    Console.WriteLine(system.name);
                    inSpace = false;
                }

                if (inSpace)
                {
                    Console.WriteLine("space");
                }

                normandy.yCoord++;
            }
        }

        public static bool InsideSystem(StarSystem system, StarPoint a)
        {
            var x = a.xCoord;
            var y = a.yCoord;
            return x <= system.coords.xCoord + 1 && x >= system.coords.xCoord - 1 && y <= system.coords.yCoord + 1 && y >= system.coords.yCoord - 1;
        }
    }
}
