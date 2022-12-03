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
    class CDoubleRoom : CRoom
    {
        public static decimal mBasePrice;
        public string sBedType;
                           //0          1  
        public enum Beds { SingleBed, DoubleBed };
        public Beds beds = new Beds();

        public int iBedType;

        public CDoubleRoom(decimal _BasePrice, decimal _Price, bool _HasTV, string _Room, int _iBedType)
        {
            BasePrice = _BasePrice;
            Price = _Price;
            HasTV = _HasTV;
            Room = _Room;
            iBedType = _iBedType;
        }

        public CDoubleRoom(string _Room)
        {
            Room = _Room;
        }

        public static decimal BasePrice
        {
            get
            {
                return mBasePrice;
            }
            set
            {
                mBasePrice = 800;
            }
        }


        public override string Description()
        {               
            if (iBedType == (int)Beds.SingleBed)
            {
                sBedType = "Has 2 Single beds";
            }
            else if (iBedType == (int)Beds.DoubleBed)
            {
                sBedType = "Has a double bed";
            }

            if (HasTV)
            {
                return Room + "\nHas television" + "\nBeds: " + sBedType + "\nPrice: " + "R" + (Price + BasePrice).ToString();
            }

            else
            {
                return Room + "\nNo television" + "\nBeds: " + sBedType + "\nPrice: " + "R" + (Price + BasePrice).ToString();
            }
        }
    }
}
