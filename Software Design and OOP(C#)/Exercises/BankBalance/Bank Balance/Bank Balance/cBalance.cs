using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Balance
{
    class cBalance
    {
        public cBalance(decimal _Balance)
        {
            Balance = _Balance;
        }
        public decimal Balance { get; set; }

        public decimal Withdraw { get; set; }

        public decimal Deposit { get; set; }

        public void DepositBalance(decimal _Deposit)
        {
             Balance = _Deposit + Balance;
        }

        public void WithdrawBalance(decimal _Withdraw)
        {
            Balance = Balance - _Withdraw;
        }
    }
}
