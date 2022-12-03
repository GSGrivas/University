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
    class Program
    {
        static void Main(string[] args)
        {
            CStove stove = new CTwoPlateStove();
            stove.Plates[0].SwitchOn();
            stove.Status();
            Console.WriteLine();
            stove = new CBasicStoveWithOven();
            stove.Plates[2].SwitchOn();
            ((CBasicStoveWithOven)stove).oven.SwitchOnGrill();
            stove.Status();
            Console.WriteLine();
            stove = new CExpensiveStoveWithOven();
            stove.Plates[1].SwitchOn();
            ((CExpensiveStoveWithOven)stove).oven.SwitchOnGrill();
            stove.Status();
            Console.ReadKey();
        }
    }
}
