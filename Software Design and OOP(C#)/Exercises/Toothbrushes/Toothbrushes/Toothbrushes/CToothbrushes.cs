using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toothbrushes
{
    class CToothbrushes
    {
        public CToothbrushes()
        {

        }
        public CToothbrushes(string _Name, string _Electrical, decimal _Cost, decimal _Retail)
        {
            Name = _Name;
            Electrical = _Electrical;
            Cost = _Cost;
            Retail = _Retail;
        }
        public CToothbrushes(string _Electrical)
        {
            Electrical = _Electrical;
        }

        private string Name { get; set; }
        private string Electrical { get; set; }
        private decimal Cost { get; set; }
        private decimal mRetail { get; set; }
        private decimal Retail
        {
            get
            {
            if (mRetail < Cost)
                {
                    return Cost;
                }
            else
                {
                    return mRetail;
                }
            }
            set { mRetail = value; }
        }

        public string GetString()
        {
            return Name + Electrical.ToString().PadLeft(40) + Cost.ToString().PadLeft(35) + Retail.ToString().PadLeft(40);  
        }
    }
}
