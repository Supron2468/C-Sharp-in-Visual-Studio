using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{ 
    class Program
    {
        static Random rnd = new Random();
        
        //0 = nothing
        //1 = naught
        //2 = cross
        static int[] player = { 1, 1 };
        static int[] board = new int[10];
        static string[] displayName = {"Player", "Computer" };
        static string[] graphicBoard = new string[10];

        static bool win = false;
        static int turn = 0;
        static int count = 0;

        static void initBoard()
        {
            Mechanics();
            for (int i = 1; i < board.Length; i = i + 1)
            {
                board[i] = 0;
            }
        }

        static int Mechanics()
        {
            for (int i = 0; i < board.Length; i = i + 1)
            {
                if (board[i] == 0)
                {
                    graphicBoard[i] = " ";
                }
                else if (board[i] == 1)
                {
                    graphicBoard[i] = "o";
                }
                else if (board[i] == 2)
                {
                    graphicBoard[i] = "x";
                }
            }
            
            Console.WriteLine(
                graphicBoard[7] + "|" + graphicBoard[8] + "|" + graphicBoard[9] + "\n" +
                graphicBoard[4] + "|" + graphicBoard[5] + "|" + graphicBoard[6] + "\n" +
                graphicBoard[1] + "|" + graphicBoard[2] + "|" + graphicBoard[3]);
            count += 1;
            if (   board[1] == 1 && board[2] == 1 && board[3] == 1
                || board[4] == 1 && board[5] == 1 && board[6] == 1
                || board[7] == 1 && board[8] == 1 && board[9] == 1
                || board[1] == 1 && board[5] == 1 && board[9] == 1
                || board[3] == 1 && board[5] == 1 && board[7] == 1
                || board[1] == 1 && board[4] == 1 && board[7] == 1
                || board[2] == 1 && board[5] == 1 && board[8] == 1
                || board[3] == 1 && board[6] == 1 && board[9] == 1)
            {
                win = true;
                Console.WriteLine(displayName[turn] + " wins!!!");
            }
            else if (board[1] == 2 && board[2] == 2 && board[3] == 2
                  || board[4] == 2 && board[5] == 2 && board[6] == 2
                  || board[7] == 2 && board[8] == 2 && board[9] == 2
                  || board[1] == 2 && board[5] == 2 && board[9] == 2
                  || board[3] == 2 && board[5] == 2 && board[7] == 2
                  || board[1] == 2 && board[4] == 2 && board[7] == 2
                  || board[2] == 2 && board[5] == 2 && board[8] == 2
                  || board[3] == 2 && board[6] == 2 && board[9] == 2)
            {
                win = true;
                Console.WriteLine(displayName[turn] + " wins!!!");
            }else if(count == 10)
            {
                win = true;
                Console.WriteLine("Draw!!!");
            }

            return 1;
        }

        static void Main(string[] args)
        {
            initBoard();

            while (win == false)
            {
                bool stop = false;
                while (stop == false)
                {
                    Console.WriteLine(displayName[turn] + " You Have a choice: \n7|8|9" +
                                                                              "\n4|5|6" +
                                                                              "\n1|2|3");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (board[choice] != 0)
                    {
                        Console.WriteLine("Sorry, that's already taken");
                        stop = false;
                    }
                    else
                    {
                        board[choice] = turn +1;
                        stop = true;
                    }
                }
                Console.Clear();
                Mechanics();
                turn = (turn + 1) % 2;
            }

            Console.ReadLine();
        }
    }
}
