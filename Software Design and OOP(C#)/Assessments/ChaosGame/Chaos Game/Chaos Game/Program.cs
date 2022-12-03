using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chaos_Game
{
    class Program
    {
        static Form frmChaosGame = new Form();
        static Button btnStart = new Button();
        static Button btnStop = new Button();
        static NumericUpDown nudIterations = new NumericUpDown();
        static Label lblIterations = new Label();
        static Panel plCanvas = new Panel();
        static RadioButton rdbtnTriangle = new RadioButton();
        static RadioButton rdbtnFern = new RadioButton();
        static RadioButton rdbtnSquare = new RadioButton();
        static ComboBox cmbxSquares = new ComboBox();

        static Timer tmrChaosIter = new Timer();

        static int iDie = 0;
        static int iCounter = 0;
        static double dY = 0;
        static double dX = 0;
        static int iY = 0;
        static int iX = 0;
        static int iPreAns = 0;


        static Random ran = new Random();

        static void Main(string[] args)
        {
       

            frmChaosGame.Text = "Chaos Game";
            frmChaosGame.Width = 650;
            frmChaosGame.Height = 750;
            frmChaosGame.WindowState = FormWindowState.Normal;
            frmChaosGame.StartPosition = FormStartPosition.CenterScreen;
            frmChaosGame.MaximizeBox = frmChaosGame.MinimizeBox = false;

            btnStart.Text = "Start";
            btnStart.Left = 30;
            btnStart.Top = 625; 
            frmChaosGame.Controls.Add(btnStart);
            btnStart.Click += btnStartClick;

            btnStop.Text = "Stop";
            btnStop.Left = 30;
            btnStop.Top = 650;
            btnStop.Enabled = false;
            btnStop.Click += BtnStop_Click;
            frmChaosGame.Controls.Add(btnStop);

            rdbtnTriangle.Text = "Triangle";
            rdbtnTriangle.Left = 250;
            rdbtnTriangle.Top = 620;
            rdbtnTriangle.Width = 65;
            frmChaosGame.Controls.Add(rdbtnTriangle);
            rdbtnTriangle.Click += RdbtnTriangle_Click;

            rdbtnFern.Text = "Fern";
            rdbtnFern.Left = 250;
            rdbtnFern.Top = 660;
            rdbtnFern.Width = 60;
            frmChaosGame.Controls.Add(rdbtnFern);
            rdbtnFern.Click += RdbtnFern_Click;

            rdbtnSquare.Text = "Square";
            rdbtnSquare.Left = 250;
            rdbtnSquare.Top = 640;
            rdbtnSquare.Width = 60;
            frmChaosGame.Controls.Add(rdbtnSquare);
            rdbtnSquare.Click += RdbtnSquare_Click;

            cmbxSquares.Items.Add(1);
            cmbxSquares.Items.Add(2);
            cmbxSquares.Items.Add(3);
            cmbxSquares.Items.Add(4);
            cmbxSquares.Left = 320;
            cmbxSquares.Top = 645;
            cmbxSquares.Width = 35;
            cmbxSquares.SelectedItem = 1;
            cmbxSquares.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxSquares.Visible = false;
            frmChaosGame.Controls.Add(cmbxSquares);

            nudIterations.Width = 100;
            nudIterations.Left = 500;
            nudIterations.Top = 640;
            nudIterations.Maximum = 100000;
            nudIterations.Minimum = 1000;
            nudIterations.Increment = 1000;
            frmChaosGame.Controls.Add(nudIterations);
           
            lblIterations.Text = "Iterations";
            lblIterations.Left = 497;
            lblIterations.Top = 625;
            frmChaosGame.Controls.Add(lblIterations);

            plCanvas.Width = 610;
            plCanvas.Height = 610;
            plCanvas.Left = 15;
            plCanvas.Top = 10;
            plCanvas.BackColor = (Color.Beige);
            frmChaosGame.Controls.Add(plCanvas);

            Application.Run(frmChaosGame);


        }

        private static void RdbtnTriangle_Click(object sender, EventArgs e)
        {
            cmbxSquares.Visible = false;
        }

        private static void RdbtnFern_Click(object sender, EventArgs e)
        {
            cmbxSquares.Visible = false;
        }

        private static void RdbtnSquare_Click(object sender, EventArgs e)
        {
            cmbxSquares.Visible = true;
        }

        private static void BtnStop_Click(object sender, EventArgs e)
        {
            iCounter = (int)nudIterations.Value;
        }

        static void btnStartClick(object sender, EventArgs e)
        {
            if (rdbtnFern.Checked == false && rdbtnTriangle.Checked == false && rdbtnSquare.Checked == false)
            {
                MessageBox.Show("Please select a shape you would like to generate", "No shape selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnStart.Enabled = false;
                rdbtnFern.Enabled = false;
                rdbtnTriangle.Enabled = false;
                rdbtnSquare.Enabled = false;
                nudIterations.Enabled = false;
                cmbxSquares.Enabled = false;
                btnStop.Enabled = true;
                

                GenerateInitialEllipse(plCanvas, rdbtnFern, rdbtnTriangle, rdbtnSquare, ran, ref dX, ref dY, ref iPreAns);

                tmrChaosIter.Start();
                tmrChaosIter.Interval = 1;
                tmrChaosIter.Tick += TmrChaosIter_Tick;
            }
        }

        private static void TmrChaosIter_Tick(object sender, EventArgs e)
        {
            GenerateChaos();

            Graphics gChaos = plCanvas.CreateGraphics();
            Brush brBlue = new SolidBrush(Color.Blue);

            if (dX != 0 || dY != 0)
            {
                iX = (int)dX;
                iY = (int)dY;

                gChaos.FillEllipse(brBlue, iX, iY, 3, 3);

                if (iCounter == nudIterations.Value)
                {
                    tmrChaosIter.Stop();
                    btnStart.Enabled = true;
                    rdbtnFern.Enabled = true;
                    rdbtnTriangle.Enabled = true;
                    rdbtnSquare.Enabled = true;
                    nudIterations.Enabled = true;
                    cmbxSquares.Enabled = true;
                }
                iCounter++;
            }

        }
        static void GenerateInitialEllipse(Panel _plCanvas, RadioButton _rdbtnFern, RadioButton _rdbtnTriangle, RadioButton _rdbtnSquare, Random _ran, ref double _dX, ref double _dY, ref int _iPreAns)
        {

            Graphics gChaos = _plCanvas.CreateGraphics();
            Brush brRed = new SolidBrush(Color.Red);
            gChaos.Clear(Color.Beige);

            if (_rdbtnTriangle.Checked == true)
            {
                gChaos.FillEllipse(brRed, 300, 0, 10, 10);
                gChaos.FillEllipse(brRed, 600, 600, 10, 10);
                gChaos.FillEllipse(brRed, 0, 600, 10, 10);

                _dX = _ran.Next(0, 600);
                _dY = _ran.Next(0, 600);
            }
            else if (_rdbtnFern.Checked == true)
            {
                gChaos.FillEllipse(brRed, 300, 500, 10, 10);

                _dX = 300;
                _dY = 500;
            }
            else if (_rdbtnSquare.Checked == true)
            {
                gChaos.FillEllipse(brRed, 0, 0, 10, 10);
                gChaos.FillEllipse(brRed, 600, 600, 10, 10);
                gChaos.FillEllipse(brRed, 0, 600, 10, 10);
                gChaos.FillEllipse(brRed, 600, 0, 10, 10);

                _dX = _ran.Next(0, 500);
                _dY = _ran.Next(50, 500);
            }
        }
        static void GenerateChaos()
        {
            if (rdbtnTriangle.Checked == true)
            {
                iDie = ran.Next(1, 4);

                switch (iDie)
                {
                    case 1:
                        dX = (dX + 300) / 2;
                        dY = (dY + 0) / 2;
                        break;
                    case 2:
                        dX = (dX + 600) / 2;
                        dY = (dY + 600) / 2;
                        break;
                    case 3:
                        dX = (dX + 0) / 2;
                        dY = (dY + 600) / 2;
                        break;
                }
            }

            else if (rdbtnFern.Checked == true)
            {
                iDie = ran.Next(100);

                if (iDie < 1)
                {
                    dX = 0;
                    dY = 0.16 * dY;
                }
                else if (iDie < 85)
                {
                    dX = 0.85 * dX + 0.04 * dY;
                    dY = -0.04 * dX + 0.85 * dY + 1.6;
                }
                else if (iDie < 93)
                {
                    dX = 0.2 * dX - 0.26 * dY;
                    dY = 0.23 * dX + 0.22 * dY + 1.6;
                }
                else
                {
                    dX = -0.15 * dX + 0.28 * dY;
                    dY = 0.26 * dX + 0.24 * dY + 0.44;
                }
            }

            else if (rdbtnSquare.Checked == true)
            {
                iDie = ran.Next(1, 5);

                switch (cmbxSquares.SelectedItem)
                {
                    case 1:                     
                        if (iPreAns == iDie)
                        {
                            dX = 0;
                            dY = 0;
                        }
                        else
                        {
                            Square();
                        }
                    break;

                    case 2:
                        if ((iDie == 1 && iPreAns == 3) || (iDie == 3 && iPreAns == 1) || (iDie == 4 && iPreAns == 2) || (iDie == 2 && iPreAns == 4))
                        {
                            dX = 0;
                            dY = 0;
                        }
                        else
                        {
                            Square();
                        }
                        break;

                    case 3:
                        if (iPreAns == 4 && iDie == 1)
                        {
                            dX = 0;
                            dY = 0;
                        }
                        else if (iPreAns == iDie-1)
                        {
                            dX = 0;
                            dY = 0;
                        }
                        else
                        {
                            Square();
                        }
                    break;

                    case 4:
                        break;
                }

                iPreAns = iDie;
            }
        }

        static void Square()
        {
            switch (iDie)
            {
                case 1:
                    dX = (dX + 0) / 2;
                    dY = (dY + 0) / 2;
                    break;
                case 2:
                    dX = (dX + 600) / 2;
                    dY = (dY + 0) / 2;
                    break;
                case 3:
                    dX = (dX + 600) / 2;
                    dY = (dY + 600) / 2;
                    break;
                case 4:
                    dX = (dX + 0) / 2;
                    dY = (dY + 600) / 2;
                    break;
            }
        }
    }
}

