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
    abstract class CStove
    {

        public List<CPlates> Plates { get; set; }
        public IGrillBehaviour oven = new CGrillorOven();

        public abstract void Status();
    }
}
