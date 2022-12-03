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
    class CBooking
    {
        public DateTime Date { get; set; }
        public CClient Client { get; set; }
        public CRoom Room { get; set; }
        

        public CBooking(DateTime _Date, CClient _Client, CRoom _Room)
        {
            Date = _Date;
            Client = _Client;
            Room = _Room;
        }

        public string Description()
        {
            return "Room: " + Room.Number.ToString() + "   Client: " + Client.Name + "   Date: " + Date.ToString("ddMMMyy");
        }
    }
}
