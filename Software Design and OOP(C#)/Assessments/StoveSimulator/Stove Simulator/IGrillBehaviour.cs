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
    interface IGrillBehaviour
    {
        bool isGrillOn { get; set; }
        bool isOvenOn { get; set; }
        void SwitchOnGrill();
        void SwitchOffGrill();
        void SwitchOnOven();
        void SwitchOffOven();
    }
}
