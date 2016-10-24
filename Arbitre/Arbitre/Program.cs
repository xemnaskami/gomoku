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

        static void Main(string[] args)
        {
            initArray();

            int first = -1;
            int second = -1;
            string UserEntry = "";
 
            while (UserEntry != "q")
            {
                if (first == -1)
                    printArray();
                UserEntry = Console.ReadLine();
                if (first == -1)
                {
                    if (!(int.TryParse(UserEntry, out first)))
                        first = -1;
                }
                else
                {
                    if (!(int.TryParse(UserEntry, out second)))
                        second = -1;
                }
                if (first != -1 && second != -1)
                {
                    pose(first, second);
                }
            } 
        }
        
        private static bool pose(int x, int y)
        {
            array[x, y] = player;
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
