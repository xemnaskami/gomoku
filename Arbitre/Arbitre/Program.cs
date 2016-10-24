using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Arbitre
{
    class Program
    {
        private static int[,] array;
        private static int player = 2;
        private static int winner;

        static void Main(string[] args)
        {
            initArray();
            winner = 0;

            int first = -1;
            int second = -1;
            string UserEntry = "";
 
            while (UserEntry != "q")
            {
                if (first == -1 && UserEntry == "n")
                    printArray();
                UserEntry = Console.ReadLine();
                if (winner != 0)
                    Console.WriteLine("player " + winner);
                if (first == -1)
                {
                    if (!(int.TryParse(UserEntry, out first)))
                        first = -1;
                    else
                        Console.WriteLine("first = " + first);
                }
                else
                {
                    if (!(int.TryParse(UserEntry, out second)))
                        second = -1;
                    else
                        Console.WriteLine("second = " + second);
                }
                if (first != -1 && second != -1)
                {
                    pose(first, second);
                    first = -1;
                    second = -1;
                }
            } 
        }
        
        private static bool pose(int x, int y)
        {
            array[x, y] = player;
            if (victory(x, y, player))
            {
                winner = player;
                Console.WriteLine("il y a un winner : " + winner);
            }
            player = player % 2 + 1;
            x = -1;
            y = -1;
            return true;
        }

        private static void printArray()
        {
            Console.Clear();
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        //fonction qui check la condition de victoire
        private static bool victory(int x, int y, int player)
        {
            //TODO check si cette fonction marche (elle marche verticalement)
            //on check pour chaque direction dans les deux sens et on additionne les resultats. on y ajoute la pierre courante
            if ((iterVictory(x + 1, y, 1, 0, 0, player) + iterVictory(x - 1, y, -1, 0, 0, player) >= 4) ||
                (iterVictory(x, y + 1, 0, 1, 0, player) + iterVictory(x, y - 1, 0, -1, 0, player) >= 4) ||
                (iterVictory(x + 1, y + 1, 1, 1, 0, player) + iterVictory(x - 1, y - 1, -1, -1, 0, player) >= 4) ||
                (iterVictory(x + 1, y - 1, 1, -1, 0, player) + iterVictory(x - 1, y + 1, -1, 1, 0, player) >= 4))
                return true;
            return false;
        }

        //fonction qui itère pour compter les pierres de la couleur du joueur autour de la pierre courante
        private static int iterVictory(int x, int y, int dirx, int diry, int result, int player)
        {
            if (result >= 5)
                return result;
            if (x >= 0 && x < 19 && y >= 0 && y < 19)
                if (array[x, y] == player)
                    return iterVictory(x + dirx, y + diry, dirx, diry, result + 1, player);
            return result;
        }

        private static bool initArray()
        {
            array = new int[19, 19];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    array[i, j] = 0;
                }
            }
            array[9, 9] = 1;
            return true;
        }
    }
}
