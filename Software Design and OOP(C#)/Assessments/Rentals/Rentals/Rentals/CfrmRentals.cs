//2017374683
//Georgio Savva Grivas
//Practical Assignment 2
//2019/10/04

using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Rentals
{
    public partial class CfrmRentals : Form
    {
        const string FILENAME = "Rooms.csv";
        const string FILENAMEC = "Clients.csv";
        const string FILENAMEB = "Bookings.csv";
        
        int iCounter;
        int iRoomNumber;        
        int iBedType;

        decimal mBasePrice;
        decimal mPrice;

        string sSingle;
        string sDouble;
        string sBed;
        string sName;
        string sNumber;
        string sRoom;
        string sBooking;

        public List<string> Names = new List<string>();
        public List<string> Numbers = new List<string>();
        public List<string> Bookings = new List<string>();

        bool hasTV;
        

        CSingleRoom singleR;
        CDoubleRoom doubleR;

        public CfrmRentals()
        {
            InitializeComponent();

            lstRooms.Items.Add(1);
            lstRooms.Items.Add(2);
            lstRooms.Items.Add(3);
            lstRooms.Items.Add(4);
            DisplayClients();
            DisplayBookings();
        }


        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRooms();
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        { 
             
            if (lstClients.SelectedIndex == -1)
            {
                lblClients.Text = "";
            }
            try
            {
                CClient client = new CClient(Names[lstClients.SelectedIndex], Numbers[lstClients.SelectedIndex]);
                lblClients.Text = client.Details();
            }
            catch
            {

            }
        }

        private void btnAddC_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room for the client.");
            }
            else
            {
                bool isLoop = true;
                
                while (isLoop)
                {
                    sName = Interaction.InputBox("Enter the name and surname of the client");
                    if (sName.All(char.IsDigit))
                    {
                        MessageBox.Show("Invalid input... Please use only letters.");
                        sName = "";
                    }
                    else
                    {
                        isLoop = false;
                    }

                }
                isLoop = true;

                while (isLoop)
                {
                    sNumber = Interaction.InputBox("Enter the number of the client");
                    if (sNumber.All(char.IsLetter))
                    {
                        MessageBox.Show("Invalid input... Please use only numbers.");
                        sNumber = "";
                    }
                    else
                    {
                        isLoop = false;
                    }
                }


                using (StreamWriter sw = new StreamWriter(FILENAMEC, true))
                {
                    sw.WriteLine(sName + "/" + sNumber);
                }
                Names.Add(sName);
                Numbers.Add(sNumber);

                lstClients.Items.Add(sName);
                MessageBox.Show("Changes have been saved.");
            }

        }

        

        public void DisplayRooms()
        {
            if (lstRooms.SelectedIndex == 0)
            {
                ReadRoom();
                CSingleRoom singleR = new CSingleRoom(mBasePrice, mPrice, hasTV, sRoom);
                lblRooms.Text = singleR.Description();
            }

            if (lstRooms.SelectedIndex == 1)
            {
                ReadRoom();
                CDoubleRoom doubleR = new CDoubleRoom(mBasePrice, mPrice, hasTV, sRoom, iBedType);
                lblRooms.Text = doubleR.Description();
            }


            if (lstRooms.SelectedIndex == 2)
            {
                ReadRoom();
                CSingleRoom singleR = new CSingleRoom(mBasePrice, mPrice, hasTV, sRoom);
                lblRooms.Text = singleR.Description();
            }
            if (lstRooms.SelectedIndex == 3)
            {
                ReadRoom();
                CDoubleRoom doubleR = new CDoubleRoom(mBasePrice, mPrice, hasTV, sRoom, iBedType);
                lblRooms.Text = doubleR.Description();
            }

        }

        void DisplayClients()
        {
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + FILENAMEC))
            {
                string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + FILENAMEC);

                foreach (string line in lines)
                {
                    bool isName = true;

                    foreach (char c in line)
                    {
                        if (c != '/' && isName)
                        {
                            sName += c;
                        }
                        else if (c == '/')
                        {
                            isName = false;
                        }
                        else if (c != '/' && !isName)
                        {
                            sNumber += c;
                        }
                    }
                    try
                    {
                        Names.Add(sName);
                        Numbers.Add(sNumber);

                        lstClients.Items.Add(sName);
                        sName = "";
                        sNumber = "";
                    }
                    catch
                    {

                    }
                    iCounter++;
                }
                iCounter = 0;
            }
        }

        void DisplayBookings()
        {
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + FILENAMEB))
            {
                string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + FILENAMEB);

                foreach (string line in lines)
                {
                    foreach (char c in line)
                    {
                        sBooking += c;
                    }
                    try
                    {
                        Bookings.Add(sBooking);
                        lstBookings.Items.Add(sBooking);
                    }
                    catch
                    {

                    }
                    iCounter++;

                }
                iCounter = 0;
                sBooking = "";
            }
        }

        void ReadRoom()
        {
            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + FILENAME);

            foreach (char c in lines[lstRooms.SelectedIndex])
            {
                if (c != ',')
                {
                    iCounter++;

                    if (iCounter == 4)
                    {
                        switch (c)
                        {
                            case 'S':
                                iBedType = 0;
                                break;
                            case 'D':
                                iBedType = 1;
                                break;
                        }
                    }

                    else switch (c)
                    {
                        case '1':
                            iRoomNumber = 1;
                            break;
                        case '2':
                            iRoomNumber = 2;
                            break;
                        case '3':
                            iRoomNumber = 3;
                            break;
                        case '4':
                            iRoomNumber = 4;
                            break;
                        case 'S':
                            sRoom = "Single";
                            break;
                        case 'D':
                            sRoom = "Double";
                            break;
                        case 'Y':
                            hasTV = true;
                            break;
                        case 'N':
                            hasTV = false;
                            break;
                    }

                }
            }
            iCounter = 0;
        }
        

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            try
            {
                int iRemoveName = 0;

                if (File.Exists(FILENAMEC))
                {
                    File.Delete(FILENAMEC);
                }

                using (StreamWriter sw = new StreamWriter(FILENAMEC))
                {
                    foreach (string item in Names)
                    {
                        if (iCounter == lstClients.SelectedIndex)
                        {
                            iRemoveName = iCounter;
                        }
                        else
                        {
                            sw.WriteLine(Names[iCounter] + "/" + Numbers[iCounter]);
                        }
                        iCounter++;
                    }
                    Names.RemoveAt(iRemoveName);
                    Numbers.RemoveAt(iRemoveName);
                    iCounter = 0;
                }

                lstClients.Items.RemoveAt(lstClients.SelectedIndex);

                try
                {
                    int iRemoveBooking = 0;

                    if (File.Exists(FILENAMEB))
                    {
                        File.Delete(FILENAMEB);
                    }

                    using (StreamWriter sw = new StreamWriter(FILENAMEB))
                    {
                        foreach (string item in Names)
                        {
                            if (iCounter == lstClients.SelectedIndex)
                            {
                                iRemoveBooking = iCounter;
                            }
                            else
                            {
                                sw.WriteLine(Names[iCounter] + "/" + Numbers[iCounter]);
                            }
                            iCounter++;
                        }
                        Bookings.RemoveAt(iRemoveBooking);
                        iCounter = 0;
                    }

                    lstBookings.Items.RemoveAt(lstBookings.SelectedIndex);
                }
                catch
                {

                }
                MessageBox.Show("Changes have been saved.");
            }
            catch
            {
                MessageBox.Show("Please select a client you would like to delete.");
            }


        }

        private void btnAddB_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room for the client.");
            }
            else if (lstClients.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client for the room.");
            }
            else
            {
                CClient client = new CClient(Names[lstClients.SelectedIndex], Numbers[lstClients.SelectedIndex]);
                CRoom room = new CSingleRoom(iRoomNumber);

                CBooking booking = new CBooking(dtCalendar.Value, client, room);

                sBooking = booking.Description();

                using (StreamWriter sw = new StreamWriter(FILENAMEB, true))
                {
                    sw.WriteLine(sBooking);
                }

                Bookings.Add(sBooking);
                lstBookings.Items.Add(sBooking);

                MessageBox.Show("Changes have been saved.");
            }
        }

        private void btnDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                int iRemoveBooking = 0;

                if (File.Exists(FILENAMEB))
                {
                    File.Delete(FILENAMEB);
                }

                using (StreamWriter sw = new StreamWriter(FILENAMEB))
                {
                    foreach (string item in Names)
                    {
                        if (iCounter == lstBookings.SelectedIndex)
                        {
                            iRemoveBooking = iCounter;
                        }
                        else
                        {
                            sw.WriteLine(Bookings[iCounter]);
                        }
                        iCounter++;
                    }
                    Bookings.RemoveAt(iRemoveBooking);
                    iCounter = 0;
                }

                lstBookings.Items.RemoveAt(lstBookings.SelectedIndex);
                MessageBox.Show("Changes have been saved.");
            }
            catch
            {
                MessageBox.Show("Please select a booking you would like to delete.");
            }
        }
    }
}
