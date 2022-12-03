using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NumberArray = GetNumbers();
            int[][] NumberJaggedAr = GetFactors(NumberArray);
            PrintFactors(NumberJaggedAr);

            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE");
            Console.ReadKey();
        }

        static int[] GetNumbers()
        {
            int[] iNumbers = new int[0];
            int iInput = 0;
            int iSize = 0;

            do
            {
                iSize++;
                Console.Write("Enter the next positive integer: ");
                iInput = int.Parse(Console.ReadLine());
                if (iInput == -1)
                {

                }
                else
                {
                    Array.Resize(ref iNumbers, iSize);
                    iNumbers[iSize - 1] = iInput;
                }
            }
            while (iInput != -1);

            return iNumbers;
        }
        static int[][] GetFactors(int[] _NumberArray)
        {
            int[][] Factors = new int[0][];
            Array.Resize(ref Factors, _NumberArray.Count());

            for (int i = 0; i < _NumberArray.Count(); i++)
            {
                int iSize = 1;
                int iPosition = 0;

                for (int j = 1; j <= _NumberArray[i]; j++)
                {                  
                    if (_NumberArray[i] % j == 0)
                    {                        
                        Array.Resize(ref Factors[i], iSize);
                        Factors[i][iPosition] = j;                        
                        iPosition++;
                        iSize++;
                    }                        
                }
            }
            return Factors;
        }
        static void PrintFactors(int[][] Factors)
        {
            for (int i = 0; i < Factors.Count(); i++)
            {
                for (int j = 0; j < Factors[i].Count(); j++)
                {
                    Console.Write(Factors[i][j] + " ");
                }
                Console.WriteLine();
            }
            
        }

    }
}
