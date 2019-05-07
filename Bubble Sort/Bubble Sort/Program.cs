using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] num = new int[10];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = rnd.Next(0, 20);
                Console.Write("({0}:{1})", i + 1, num[i]);
            }
            Console.WriteLine();

            int iteration = 0;
            bool repeat = true;
            while (repeat == true) { 
                int temp1 = 0;
                int temp2 = 1;
                int repeats = 0;
                for (int i = 0; temp2 < num.Length; i++)
                {
                    if (num[temp1] > num[temp2])
                    {
                        int temp = num[temp2];
                        num[temp2] = num[temp1];
                        num[temp1] = temp;
                    }else
                    {
                        repeats++;
                        if (repeats >= num.Length-1)
                        {
                            repeat = false;
                        } 
                    }


                    Console.WriteLine();
                    for (int k = 0; k < num.Length; k++)
                    {
                        Console.Write("{0}, ", num[k]);
                    }
                    temp1++;
                    temp2++;
                }
                iteration++;
                Console.WriteLine("Iteration: " + (iteration));

            }



            Console.ReadLine();

        }
    }
}
