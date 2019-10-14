using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickBall
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] game = new int[] { 0, 3, 4, 6 };
            PrintGame(game);
            Action(game);
        }
        public static void Action(int[] game)
        {
            while (true)
            {
                HumanMove(game);
                PrintGame(game);
                if (has0Group(game))
                {
                    Console.WriteLine("You lose!!");
                    break;
                }
                Console.WriteLine("Computer is thinking");
                ComputerMove(game);
                PrintGame(game);
                if (has0Group(game))
                {
                    Console.WriteLine("You win!!");
                    break;
                }
            }
        }
        public static void PrintGame(int[] game)
        {
            Console.Write("Group 1: ");
            for (int i = 0; i < game[1]; i++)
            {
                Console.Write("o ");
            }
            Console.WriteLine();
            Console.Write("Group 2: ");
            for (int i = 0; i < game[2]; i++)
            {
                Console.Write("o ");
            }
            Console.WriteLine();
            Console.Write("Group 3: ");
            for (int i = 0; i < game[3]; i++)
            {
                Console.Write("o ");
            }
            Console.WriteLine();
        }
        public static bool has0Group(int[] game)
        {
            return game[1] == 0 && game[2] == 0 && game[3] == 0;
        }
        public static void PickBalls(int[] game, int group, int balls)
        {
            game[group] -= balls;
        }
        public static void HumanMove(int[] game)
        {
            Console.WriteLine("Which group do you choose ?");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine("How many balls will you pick ?");
            int balls = int.Parse(Console.ReadLine());
            PickBalls(game, group, balls);
        }
        public static void ComputerMove(int[] game)
        {
            if (Has1Group(game))
            {
                int g = 0;
                Get1Group(game, out g);
                if (game[g] > 1)
                    PickBalls(game, g, game[g] - 1);
                else
                    PickBalls(game, g, 1);
            }
            else if (Has2Group(game))
            {
                int a = 0; int b = 0;
                Get2Group(game, out a, out b);
                if (game[a] != game[b])
                {
                    if (game[a] == 1)
                        PickBalls(game, b, game[b]);
                    else if (game[b] == 1)
                        PickBalls(game, a, game[a]);
                    else if (game[a] > game[b])
                        PickBalls(game, a, game[a] - game[b]);
                    else
                        PickBalls(game, b, game[b] - game[a]);
                }
                else
                    PickBalls(game, a, 1);
            }
            else
            {
                Random rand = new Random();
                int group = rand.Next(1, 3);
                int balls = rand.Next(1, game[group]);
                PickBalls(game, group, balls);
                Console.WriteLine("Computer pick {0} balls from group {1}", balls, group);
            }
        }
        public static bool Has1Group(int[] game)
        {
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
                return true;
            if (game[1] == 0 && game[2] > 0 && game[3] == 0)
                return true;
            if (game[1] == 0 && game[2] == 0 && game[3] > 0)
                return true;
            return false;
        }
        public static void Get1Group(int[] game, out int g)
        {
            g = 0;
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
                g = 1;
            if (game[1] == 0 && game[2] > 0 && game[3] == 0)
                g = 2;
            if (game[1] == 0 && game[2] == 0 && game[3] > 0)
                g = 3;
        }
        public static void Get2Group(int[] game, out int a, out int b)
        {
            a = 0; b = 0;
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
            {
                a = 1; b = 2;
            }
            if (game[1] > 0 && game[2] == 0 && game[3] > 0)
            {
                a = 1; b = 3;
            }
            if (game[1] == 0 && game[2] > 0 && game[3] > 0)
            {
                a = 2;
                b = 3;
            }
        }
        public static bool Has2Group(int[] game)
        {
            if (game[1] > 0 && game[2] == 0 && game[3] > 0)
                return true;
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
                return true;
            if (game[1] == 0 && game[2] > 0 && game[3] > 0)
                return true;
            return false;
        }

    }
}