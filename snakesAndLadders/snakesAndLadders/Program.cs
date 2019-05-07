using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{


    class Program
    {

        static Random rnd = new Random();

        static int[] board = new int[31];

        static int[] player = { 1, 1 };

        static string[] displayName = { "Player", "Computer" };

        static void initBoard()
        {

            for (int i = 0; i < 31; i = i + 1)
            {

                board[i] = 0;

            }

            board[3] = 22;
            board[5] = 8;
            board[11] = 26;
            board[20] = 29;

            board[17] = 4;
            board[19] = 7;
            board[21] = 9;
            board[27] = 1;

        }

        static int walkBoard(int from, int steps)
        {

            int now = from;

            now = now + steps;

            if (now >= 30)
            {

                now = 30;

            }
            else
            {

                if (board[now] != 0)
                {

                    if (board[now] > now)
                    {

                        Console.WriteLine("# climbs a ladder from {0} to {1}", now, board[now]);

                    }
                    else if (board[now] < now)
                    {

                        Console.WriteLine("~ falls down a snake from {0} to {1}", now, board[now]);

                    }

                    now = board[now];

                }

            }

            return now;

        }

        static void Main(string[] args)
        {

            int turn = 0;

            initBoard();

            while (player[0] != 30 && player[1] != 30)
            {
                if (turn == 0)
                {
                    Console.WriteLine(displayName[turn] + ":\n");

                    Console.WriteLine(displayName[turn] + " is at {0}", player[turn]);

                    Console.WriteLine("choose 1-6");
                    int dice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Rolls a {0}", dice);

                    player[turn] = walkBoard(player[turn], dice);

                    Console.WriteLine("Lands at {0}", player[turn]);
                    Console.WriteLine();

                    turn = (turn + 1) % 2;
                }
                else
                {
                    Console.WriteLine(displayName[turn] + ":\n");
                    Console.WriteLine(displayName[turn] + " is at {0}", player[turn]);
                    int tempPos = player[turn];
                    int finalPos = 0;
                    int dice = 1;
                    int optimalDice = 1;
                    for (dice = 1; dice <= 6; dice++)
                    {
                        tempPos = walkBoard(player[turn], dice);
                        if (tempPos > finalPos)
                        {
                            finalPos = tempPos;
                            optimalDice = dice;
                        }
                    }
                    Console.WriteLine("Rolls a {0}", optimalDice);

                    player[turn] = walkBoard(player[turn], optimalDice);

                    Console.WriteLine("Lands at {0}", player[turn]);
                    Console.WriteLine();

                    turn = (turn + 1) % 2;

                }

            }


            if (player[0] == 30)
            {

                Console.WriteLine("Player wins!");

            }
            else if (player[1] == 30)
            {

                Console.WriteLine("Computer wins!");

            }
            else
            {
                Console.WriteLine("Error");
            }

            Console.ReadLine();

        }

    }
}

