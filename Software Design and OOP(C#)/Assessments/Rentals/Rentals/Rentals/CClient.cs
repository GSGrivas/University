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
    public class CClient
    {
        public CClient(string _Name, string _Number)
        {
            Name = _Name;
            Number = _Number;
        }

        public string Name { get; set; }
        public string Number { get; set; }

        public string Details()
        {
            return "Name: " + Name + "\nNumber: " + Number;
        }
    }
}
