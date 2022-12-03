using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_Players
{
    class CPlayer
    {
        public CPlayer(string _Name, int _Goals, int _Assists, int _Age)
        {
            Name = _Name;
            Goals = _Goals;
            Assists = _Assists;
            iAge = _Age;
        }
        public CPlayer()
        {

        }
        private int iAge;
        public string Name { get; }
        public int Goals { get; }
        public int Assists { get;  }
        

        private int Age
        {
            get
            {
                if (iAge < 15)
                {
                    return 15;
                }
                else if (iAge > 45)
                {
                    return 45;
                }
                else
                {
                    return iAge;
                }
            }
            set
            {
                iAge = value;
            }
        }

        public string Description()
        {
            return Name.PadRight(10) + iAge.ToString().PadRight(15) + Goals.ToString().PadRight(15) + Assists.ToString().PadRight(10);
        }
    }
}
