//2017374683
//Georgio Grivas
//2019-05-16
//Practical Assignment 3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frequency
{
    class Program
    {
        static string sAlphabet = "abcdefghijklmnopqrstuvwxyz";
        static string sDiatrics = "[]{}!@#$%^&*()-_=*-+,./<>?:\"|\\;`~";
        static string sNumbers = "1234567890";        

        static void Main(string[] args)
        {
            int iLetterCount = 0;

            List<int> Tally = new List<int>();
            List<string> Sentences = new List<string>();


            bool isMenu = true;

            while(isMenu)
            {
                Console.Write("Please enter a sentence to calculate the frequencies: ");
                string sInput = Console.ReadLine();
                Console.WriteLine();

                if (sInput.Contains("  "))
                {
                    Console.WriteLine("Please make sure your sentence doesn't contain double spaces...\nPress any key to continue...");
                }
                else if (!sInput.Contains(".") && !sInput.Contains("?") && !sInput.Contains("!"))
                {
                    Console.WriteLine("Please enter a full sentence.(A sentence consists of more than 1 word and a fullstop, exclamation or question mark)\nPress any key to continue...");
                }
                else
                {
                    Counter(sInput, ref Tally);
                    Display(sInput, ref iLetterCount, Tally, ref isMenu);
                }

                sInput = "";
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        static void Counter(string _sInput, ref List<int> _Tally)
        {
            int iCount = -1;

            foreach (char cInput in sAlphabet)
            {
                foreach (char cLetter in _sInput.ToLower())
                {                    
                    if (cInput == cLetter)
                    {                       
                        iCount++;
                    }                  
                }
                _Tally.Add(iCount);
                iCount = -1;
            }
        }

        static void Display(string _sInput, ref int _iLetterCount, List<int> _Tally, ref bool _isMenu)
        {
            int iCount = 0;
            int iWords = 1;
            int iSentences = 0;
            int iDiatrics = 0;
            int iNumbers = 0;
            double dAverageWords = 0;

            foreach (char C in _sInput)
            {
                if (C == ' ')
                {
                    iWords++;
                }
                if (C == '.' || C == '?' || C == '!')
                {
                    iSentences++;
                }

                foreach (char D in sDiatrics)
                {
                    if (D==C)
                    {
                        iDiatrics++;
                    }
                }

                foreach (char N in sNumbers)
                {
                    if (N == C)
                    {
                        iNumbers++;
                    }
                }
            }

            if (iWords == 1)
            {
                Console.WriteLine("Please enter a full sentence.(A sentence consists of more than 1 word and a fullstop, exclamation or question mark)\nPress any key to continue...");
                return;
            }

            foreach (char cLetter in sAlphabet)
            {   
                string sQuantity = "";
                int iQuantity = _Tally[iCount];

                for (int i = 0; i <= iQuantity; i++)
                {                   
                    sQuantity += "*";
                    _iLetterCount++;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(cLetter.ToString().ToUpper());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" |");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sQuantity + "\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                iCount++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  |====|====|====|====|====|====|====");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  0    5    10   15   20   25   30 \n");


                dAverageWords = iWords / iSentences;

                Console.WriteLine("\n==============\n  Statistics\n==============");
                Console.WriteLine("Diatrics Count: " + iDiatrics.ToString());
                Console.WriteLine("Number Count: " + iNumbers.ToString());
                Console.WriteLine("Letter Count: " + _iLetterCount.ToString());
                Console.WriteLine("Word Count: " + iWords.ToString());
                Console.WriteLine("Sentence Count: " + iSentences.ToString());
                Console.WriteLine("Average words per sentence: " + dAverageWords.ToString("0.##"));
                Console.WriteLine("Average letters per word: " + (_iLetterCount / dAverageWords).ToString("0.##"));

                _isMenu = false;
        }
    }
}
