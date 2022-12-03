using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mBalance = 1500;
            decimal deposit;
            decimal withdraw;

            bool ViewBalance = true;

            cBalance client = new cBalance(mBalance);

            while(ViewBalance)
            {
                Console.WriteLine("Your balance is " + client.Balance.ToString("C"));
                Console.WriteLine();

                Console.Write("Please put in the amount you would like to deposit: ");
                deposit = decimal.Parse(Console.ReadLine());
                client.DepositBalance(deposit);
                Console.WriteLine(client.Balance.ToString("C"));
                Console.WriteLine();

                Console.Write("Please put in the amount you would like to withdraw: ");
                withdraw = decimal.Parse(Console.ReadLine());
                client.WithdrawBalance(withdraw);
                Console.WriteLine(client.Balance.ToString("C"));
                Console.WriteLine();

                Console.WriteLine("Would you like to exit? (Y/N)");

                if (Console.ReadLine().ToUpper() == "Y")
                {
                    ViewBalance = false;                    
                }
                else
                {
                    Console.WriteLine(mBalance.ToString("C"));
                }
            }
        }
    }
}
