//2017374683
//Georgio Savva Grivas
//Practical Assignment 2
//2019/10/04

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentals
{
    class CSingleRoom : CRoom
    {
        
        public CSingleRoom(decimal _BasePrice, decimal _Price, bool _HasTV, string _Room)
        {
            BasePrice = _BasePrice;
            Price = _Price;
            HasTV = _HasTV;
            Room = _Room;
        }

        public CSingleRoom(int _Number)
        {
            Number = _Number;
        }

        public static decimal mBasePrice;

        public static decimal BasePrice
        {
            get
            {
                return mBasePrice;
            }
            set
            {
                mBasePrice = 500;
            }
        }

        public override string Description()
        {
            if (HasTV)
                return Room + "\nHas television" + "\nPrice: " + "R" + ((decimal)Price + (decimal)BasePrice);
            else 
                return
                   Room + "\nNo television" + "\nPrice: " + "R" + ((decimal)Price + (decimal)BasePrice);
        }   
    }
}
