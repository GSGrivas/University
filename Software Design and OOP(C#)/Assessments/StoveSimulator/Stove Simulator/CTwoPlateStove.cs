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
    class CTwoPlateStove : CStove
    {
        int iCounter = 0;

        public CTwoPlateStove()
        {
            Plates = new List<CPlates>();
            Plates.Add(new CPlates());
            Plates.Add(new CPlates());
        }


        public override void  Status()
        {
            Console.WriteLine("Stove with two plates and no oven");
            foreach (CPlates plate in Plates)
            {
                if (plate.isOn)
                {
                    Console.WriteLine("Plate "+ iCounter.ToString() + ": On");
                }
                else
                {
                    Console.WriteLine("Plate " + iCounter.ToString() + ": Off");
                }
                iCounter++;
            }
            iCounter = 0;
        }
    }
}
