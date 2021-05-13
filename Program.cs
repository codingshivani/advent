using System;
using System.Linq;

namespace AdventOfCode
{
    /*
    Before you leave, the Elves in accounting just need you to fix your expense report 
    (your puzzle input); apparently, something isn't quite adding up.

    Specifically, they need you to find the two entries that sum to 2020 and then 
    multiply those two numbers together.
    */
    class Program
    {
        static int findCorrectExpenseFigure(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j=0; j<input.Length; j++)
                {
                    if (i==j)
                    {
                        continue;
                    }

                    if (input[i] + input[j] == 2020)
                    {
                        return input[i]*input[j];
                    }
                }
            }
            return 0; //only caveat is that if you had 0 and n=2020 but who would put 0 on an expense report?
        }

        static int improvedFindCorrectExpenseFigure(int[] input)
        {
            Array.Sort(input);

            int left = 0;
            int right = input.Length -1;
            while(left < right)
            {
                if (input[left] + input[right] == 2020)
                {
                    return input[left]*input[right];
                }

                if(input[left] + input[right] < 2020)
                {
                    left = left + 1;
                }
                else
                {
                    right = right - 1;
                }
            }      

            return 0;      
        }
        static void Main(string[] args)
        {
            int[] input = new int[] {3, 7, 8, 5, 345, 567, 234547, 67, 2019, 1};
            var expenseFigure = findCorrectExpenseFigure(input);
            var secondExpenseFigure = improvedFindCorrectExpenseFigure(input);
            Console.WriteLine(expenseFigure);
            Console.WriteLine(secondExpenseFigure);
        }
    }
}
