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
    class CGrillorOven : IGrillBehaviour
    {
        public bool isOvenOn { get; set; }
        public bool isGrillOn { get; set; }
        public CGrillorOven()
        {
            isOvenOn = false;
            isGrillOn = false;
        }

        public void SwitchOnGrill()
        {
            isOvenOn = true;
            isGrillOn = true;
        }
        public void SwitchOffGrill()
        {
            isGrillOn = false;
            isOvenOn = false;
        }

        public void SwitchOnOven()
        {
            isOvenOn = true;
        }
        public void SwitchOffOven()
        {
            isOvenOn = false;
        }

    }
}
