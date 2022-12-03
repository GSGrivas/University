//2017374683
//Georgio Grivas
//2019-10-11
//Practical Assignment 3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Simulator
{
    class CPlates
    {      
        public bool isOn { get; set; }

        public CPlates()
        {
            isOn = false;
        }

        public void SwitchOn()
        {
            isOn = true;
        }

        public void SwitchOff()
        {
            isOn = false;
        }
    }
}
