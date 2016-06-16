namespace Problem02.Radioactive_Bunnies
{
    using System;
    using System.Linq;

    public class RadioactiveBunnies
    {
        public static int PlayerXcoord, PlayerYcoord;
        public static bool GameState = false;

        public static void Main(string[] args)
        {
            var arraySize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = arraySize[0];
            int cols = arraySize[1];
            char[,] array = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var map = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = map[j];
                }
            }

            GetPlayerCoord(array);
            array[PlayerXcoord, PlayerYcoord] = '.';
            string movementCommand = Console.ReadLine();

            foreach (var moveCommand in movementCommand)
            {
                int oldPlayerRow = PlayerXcoord;
                int oldPlayerCol = PlayerYcoord;
                MovePlayer(moveCommand);

                array = BunnyMultiply(array);

                if (PlayerXcoord >= rows || PlayerXcoord < 0 || PlayerYcoord >= cols || PlayerYcoord < 0)
                {
                    PrintResult(array, "won", oldPlayerRow, oldPlayerCol);
                    break;
                }
                if (array[PlayerXcoord, PlayerYcoord] == 'B')
                {
                    PrintResult(array, "dead", PlayerXcoord, PlayerYcoord);
                    break;
                }
            }
        }

        public static char[,] BunnyMultiply(char[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            
            var tempArray = (char[,])array.Clone();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] == 'B')
                    {
                        if (i + 1 < rows)
                        {
                            tempArray[i + 1, j] = 'B';
                        }
                        if (i - 1 >= 0)
                        {
                            tempArray[i - 1, j] = 'B';
                        }
                        if (j + 1 < cols)
                        {
                            tempArray[i, j + 1] = 'B';
                        }
                        if (j - 1 >= 0)
                        {
                            tempArray[i, j - 1] = 'B';
                        }
                    }
                }
            }

            return tempArray;
        }

        public static void GetPlayerCoord(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 'P')
                    {
                        PlayerXcoord = i;
                        PlayerYcoord = j;
                    }
                }
            }
        }

        public static void MovePlayer(char command)
        {
            switch (command)
            {
                case 'U':
                    PlayerXcoord--;
                    break;
                case 'L':
                    PlayerYcoord--;
                    break;
                case 'R':
                    PlayerYcoord++;
                    break;
                case 'D':
                    PlayerXcoord++;
                    break;
            }
        }

        public static void PrintResult(char[,] array, string result, int playerRow, int playerCol)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(result + ": {0} {1}", playerRow, playerCol);
        }
    }
}
