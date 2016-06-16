namespace Problem05.CollectCoins
{
    using System;
    using System.Linq;

    public class CollectCoins
    {
        public const int matrixRows = 4;
        public static int coins = 0;
        public static int wallsHit = 0;

        public static void Main(string[] args)
        {
            string[,] matrix = new string[matrixRows, 1];
            for (int i = 0; i < matrixRows; i++)
            {
                matrix[i, 0] = Console.ReadLine();
            }

            var commandInput = Console.ReadLine();
            var commands = commandInput.ToArray();

            int playerXindex = 0, playerYindex = 0;
            char[][] gameField = {
            matrix[0, 0].ToCharArray(),
            matrix[1, 0].ToCharArray(),
            matrix[2, 0].ToCharArray(),
            matrix[3, 0].ToCharArray()
            };

            TraverseGameField(gameField, commands, playerXindex, playerYindex);
            PrintStatistics();
        }

        private static void PrintStatistics()
        {
            Console.WriteLine("Coins collected: {0}", coins);
            Console.WriteLine("Walls hit: {0}", wallsHit);
        }

        private static void TraverseGameField(char[][] matrix, char[] commands, int playerXindex, int playerYindex)
        {
            int iterator = -1;
            while (commands.Length - 1> iterator)
            {
                iterator++;
                switch (commands[iterator])
                {
                    case 'V':
                        if (!WallCollision(matrix, playerXindex + 1, playerYindex))
                        {
                            playerXindex++;
                            break;
                        }

                        continue;
                    case '>':
                        if (!WallCollision(matrix, playerXindex, playerYindex + 1))
                        {
                            playerYindex++;
                            break;
                        }

                        continue;
                    case '^':
                        if (!WallCollision(matrix, playerXindex - 1, playerYindex))
                        {
                            playerXindex--;
                            break;
                        }

                        continue;
                    case '<':
                        if (!WallCollision(matrix, playerXindex, playerYindex - 1))
                        {
                            playerYindex--;
                            break;
                        }

                        continue;
                }

                FindCoins(matrix, playerXindex, playerYindex);
            }
        }

        private static bool WallCollision(char[][] matrix, int playerXindex, int playerYindex)
        {
            if (playerXindex < 0 || 
                playerYindex < 0 || 
                playerXindex >= matrixRows || 
                playerYindex >= matrix[playerXindex].Length)
            {
                wallsHit++;
                return true;
            }

            return false;
        }

        private static void FindCoins(char[][] matrix, int playerXindex, int playerYindex)
        {
            if (matrix[playerXindex][playerYindex] == '$')
            {
                coins++;
            }
        }
    }
}
