using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toothbrushes
{
    public partial class CfrmToothbrush : Form
    {
        CToothbrushes Toothbrush = new CToothbrushes();
        IList<string> Toothbrushes = new List<string>();
        public CfrmToothbrush()
        {
            InitializeComponent();
        }

        private void CfrmToothbrush_Load(object sender, EventArgs e)
        {

        }
        public string ElectricalCheck()
        {
            if (rbtnYes.Checked)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public string FilterCheck()
        {
            if (rbtnElectrical.Checked)
            {
                return "Yes";
            }
            else if (rbtnManual.Checked)
            {
                return "No";
            }
            else
            {
                return null;
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lstbxToothbrushes.Items.Clear();
                CToothbrushes Toothbrush = new CToothbrushes(txtbName.Text.ToString(), ElectricalCheck(), decimal.Parse(txtbCost.Text), decimal.Parse(txtbRetail.Text));
                CToothbrushes EorMToothbrush = new CToothbrushes(FilterCheck());
                Toothbrushes.Add(Toothbrush.GetString());

                if (FilterCheck() == "Yes")
                {
                    foreach (string Item in Toothbrushes)
                    {
                        if (Item.Contains("No"))
                        {
                            
                        }
                        else
                        {
                            lstbxToothbrushes.Items.Add(Item);
                        }
                        
                    }
                }
                else if (FilterCheck() == "No")
                {
                    foreach (string Item in Toothbrushes)
                    {
                        if (Item.Contains("Yes"))
                        {

                        }
                        else
                        {
                            lstbxToothbrushes.Items.Add(Item);
                        }

                    }
                }
                else
                {
                    foreach (string Item in Toothbrushes)
                    {
                        lstbxToothbrushes.Items.Add(Item);
                    }
                }                       

            }
            catch
            {
                MessageBox.Show("Invalid Input, please put in correct values.");
            }

        }
    }
}
