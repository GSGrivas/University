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
    class CBasicStoveWithOven : CStove
    {
        int iCounter = 0;
        

        public CBasicStoveWithOven()
        {
            Plates = new List<CPlates>();
            Plates.Add(new CPlates());
            Plates.Add(new CPlates());
            Plates.Add(new CPlates());
            Plates.Add(new CPlates());
            oven = new CGrillorOven();
        }


        public override void Status()
        {

            Console.WriteLine("No grill installed. \nStove with four plates and oven without grill.");
            foreach (CPlates plate in Plates)
            {
                
                if (plate.isOn)
                {
                    Console.WriteLine("Plate " + iCounter.ToString() + ": On");
                }
                else
                {
                    Console.WriteLine("Plate " + iCounter.ToString() + ": Off");
                }
                iCounter++;
            }
            iCounter = 0;

            if (oven.isOvenOn)
            {
                Console.WriteLine("Oven: On");
            }
            else
            {
                Console.WriteLine("Oven: Off");
            }
        }
    }
}
