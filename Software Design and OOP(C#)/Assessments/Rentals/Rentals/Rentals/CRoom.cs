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
    public abstract class CRoom
    { 
        public int Number {get; set;}
        public bool HasTV { get; set; }

        public string Room { get; set; }
        public decimal Price
        {
            get
            {
                if (HasTV)
                {
                    return 50;
                }         
                else
                {
                    return 0;
                }
            }
            set
            {
                value = Price;
            }
        }


        public virtual string Description()
        {
            return "\nBeds: " + "\nPrice: " + Price;
        }
    }
}
