//Georgio Grivas
//2017374683
//2019-05-02
//Practical Assignment 2
//Directory

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string sAlphaLower = "abcdefghijklmnopqrstuvwxyz";
        static string sAlphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main()
        {

            string sOption = "";

            String SavePath = Directory.GetCurrentDirectory()+ @"\Save.txt";

            int iNames = -1;

            bool isMenu = true;

            List<string> NameList = new List<string>();
            List<string> NumberList = new List<string>();

            using (StreamReader Sr = new StreamReader(SavePath))
            {
                while (!Sr.EndOfStream)
                {
                    string sName = "";
                    string sNumber = "";
                    int iCount = 0;

                    foreach (char c in Sr.ReadLine())
                    {
                        if (c == ',')
                        {
                            iCount++;
                        }
                        else if (iCount == 1)
                        {
                            sName += c;
                        }
                        else if (iCount == 2)
                        {
                            sNumber += c;
                        }
                    }
                    iNames++;
                    NameList.Add(sName);
                    NumberList.Add(sNumber);
                }
            }

            while (isMenu)
            {
                Console.Clear();

                Console.WriteLine("=============================================Telephone Directory=============================================\n");
                Console.WriteLine("1. Add new person to directory");
                Console.WriteLine("2. Search for person in directory");
                Console.WriteLine("3. List all");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");

                Console.Write("\nSelect an option: ");

                sOption = Console.ReadLine();

                switch (sOption)
                {
                    case "1":
                        DirectoryEditor(sAlphaLower, sAlphaUpper, SavePath, ref NameList, ref NumberList, ref iNames);
                        break;

                    case "2":
                        DirectorySearch(NameList, NumberList, iNames);
                        break;

                    case "3":
                        DirectoryList(NameList, NumberList, iNames);
                        Console.ReadKey();
                        break;

                    case "4":
                        Save(SavePath, NameList, NumberList, iNames);
                        break;

                    case "5":
                        Delete(SavePath, NameList, NumberList, ref iNames);
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nPlease enter a valid answer. Answer must be a number from 1-6...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void DirectoryEditor(string sAlphaLower, string sAlphaUpper, string SavePath, ref List<string> NameList, ref List<string> NumberList, ref int iNames)
        {
            bool isParsed = false;
            bool isContained = true;

            while (!isParsed)
            {
                Console.Clear();

                Console.Write("Enter the person's name and surname: ");
                string sNames = Console.ReadLine();

                foreach (char c in sNames)
                {
                    if (sAlphaUpper.Contains(c) || c == ' ')
                    {
                        isContained = true;
                    }
                    else if (sAlphaLower.Contains(c) || c == ' ')
                    {
                        isContained = true;
                    }
                    else
                    {
                        isContained = false;
                        break;
                    }
                }
                if (!isContained)
                {
                    Console.WriteLine("\n Names can't contain non-alphabetic characters and diatrics...\n Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    isParsed = true;
                    NameList.Add(sNames);
                }
            }
            isParsed = false;

            while (!isParsed)
            {
                Console.Clear();
                Console.Write("Enter the person's telephone number: ");
                string sCellphone = Console.ReadLine();

                try
                {
                    double.Parse(sCellphone);
                    if (sCellphone.Count() != 10)
                    {
                        Console.WriteLine("The number must contain 10 numbers...");
                        Console.ReadKey();
                    }
                    else
                    {
                        NumberList.Add(sCellphone);
                        isParsed = true;                               
                    }
                }
                catch
                {
                    Console.Write("Hint: The telephone ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("number");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" must only contain ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("...");
                    Console.ReadKey();                            
                }
            }
            iNames++;
        }

        static void DirectoryList(List<string> NameList, List<string> NumberList, int iNames)
        {
            Console.Clear();
            Console.WriteLine("================================================Entry List================================================\n");

            if (iNames != -1)
            {
                for (int i = 0; i <= iNames; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ". " + NameList[i].PadRight(20) + NumberList[i]);
                }
            }
            else
            {
                Console.WriteLine("There are no Entries in the directory.\n\nPress any key to continue...");
            }
        }
        
        static void DirectorySearch(List<string> NameList, List<string> NumberList, int iNames)
        {
            bool hasName = false;

            Console.Clear();

            if (iNames != -1)
            {
                while (!hasName)
                {
                    Console.Write("Enter your search(Enter '1' to exit): ");
                    string sSearch = Console.ReadLine().ToLower();

                    if (sSearch == "1")
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Matches\n===================");
                    for (int i = 0; i <= iNames; i++)
                    {                       
                        if (NameList[i].ToLower().Contains(sSearch))
                        {
                            Console.WriteLine((i + 1).ToString() + ". " + NameList[i].PadRight(20) + NumberList[i]);
                            hasName = true;
                        }
                    }
                    if (hasName)
                    {
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nThere are no entries that match...\n\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no Entries in the directory.\n\nPress any key to continue...");
                Console.ReadKey();
            }


        }

        static void Save(String SavePath, List<string> NameList, List<string> NumberList, int iNames)
        {
            using (StreamWriter Sw = new StreamWriter(SavePath))
            {
                for (int i = 0; i <= iNames; i++)
                {
                    Sw.WriteLine((i + 1).ToString() + "," + NameList[i] + "," + NumberList[i]);
                }
            }
        }

        static void Delete(String SavePath, List<string> NameList, List<string> NumberList, ref int iNames)
        {
            int iName = -1;
            bool isParsed = false;


            if (iNames != -1)
            {
                while (!isParsed)
                {
                    DirectoryList(NameList, NumberList, iNames);

                    Console.Write("\nPlease choose an number you would like to remove: ");

                    try
                    {
                        iName = int.Parse(Console.ReadLine()) - 1;
                    }
                    catch
                    {

                    }

                    if (iName != -1 && iName <= iNames && iNames > -1)
                    {
                        NameList.Remove(NameList[iName]);
                        NumberList.Remove(NumberList[iName]);
                        iNames--;
                        isParsed = true;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease insert a correct value...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                DirectoryList(NameList, NumberList, iNames);
                Console.ReadKey();
            }
        }
    }
}

