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
        static void Main(string[] args)
        {
            int[,] array = Program.initArray();

            int num = 0;
            string UserEntry = "";
            bool IsOk = false;
            do
            {
                UserEntry = Console.ReadLine();
                IsOk = int.TryParse(UserEntry, out num);
            } while (!IsOk && UserEntry != "q");
        }
        
        void print(int[,] array)
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

        int[,] initArray()
        {
            int[,] array = new int[19, 19];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    array[i, j] = 0;
                }
            }
            array[9, 9] = 1;
            return (array);
        }

    }
}
