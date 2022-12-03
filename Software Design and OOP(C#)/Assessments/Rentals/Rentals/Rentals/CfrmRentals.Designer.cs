namespace Rentals
{
    partial class CfrmRentals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRooms = new System.Windows.Forms.Label();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteC = new System.Windows.Forms.Button();
            this.btnAddC = new System.Windows.Forms.Button();
            this.lblClients = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteB = new System.Windows.Forms.Button();
            this.btnAddB = new System.Windows.Forms.Button();
            this.dtCalendar = new System.Windows.Forms.DateTimePicker();
            this.lstBookings = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRooms);
            this.groupBox1.Controls.Add(this.lstRooms);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rooms";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Location = new System.Drawing.Point(7, 225);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(0, 13);
            this.lblRooms.TabIndex = 1;
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Location = new System.Drawing.Point(6, 19);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(213, 199);
            this.lstRooms.TabIndex = 0;
            this.lstRooms.SelectedIndexChanged += new System.EventHandler(this.lstRooms_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteC);
            this.groupBox2.Controls.Add(this.btnAddC);
            this.groupBox2.Controls.Add(this.lblClients);
            this.groupBox2.Controls.Add(this.lstClients);
            this.groupBox2.Location = new System.Drawing.Point(243, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clients";
            // 
            // btnDeleteC
            // 
            this.btnDeleteC.Location = new System.Drawing.Point(119, 397);
            this.btnDeleteC.Name = "btnDeleteC";
            this.btnDeleteC.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteC.TabIndex = 4;
            this.btnDeleteC.Text = "Delete";
            this.btnDeleteC.UseVisualStyleBackColor = true;
            this.btnDeleteC.Click += new System.EventHandler(this.btnDeleteC_Click);
            // 
            // btnAddC
            // 
            this.btnAddC.Location = new System.Drawing.Point(7, 397);
            this.btnAddC.Name = "btnAddC";
            this.btnAddC.Size = new System.Drawing.Size(100, 23);
            this.btnAddC.TabIndex = 3;
            this.btnAddC.Text = "Add";
            this.btnAddC.UseVisualStyleBackColor = true;
            this.btnAddC.Click += new System.EventHandler(this.btnAddC_Click);
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(6, 225);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(0, 13);
            this.lblClients.TabIndex = 2;
            // 
            // lstClients
            // 
            this.lstClients.Location = new System.Drawing.Point(6, 19);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(213, 199);
            this.lstClients.TabIndex = 0;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteB);
            this.groupBox3.Controls.Add(this.btnAddB);
            this.groupBox3.Controls.Add(this.dtCalendar);
            this.groupBox3.Controls.Add(this.lstBookings);
            this.groupBox3.Location = new System.Drawing.Point(474, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 426);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bookings";
            // 
            // btnDeleteB
            // 
            this.btnDeleteB.Location = new System.Drawing.Point(113, 397);
            this.btnDeleteB.Name = "btnDeleteB";
            this.btnDeleteB.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteB.TabIndex = 6;
            this.btnDeleteB.Text = "Delete";
            this.btnDeleteB.UseVisualStyleBackColor = true;
            this.btnDeleteB.Click += new System.EventHandler(this.btnDeleteB_Click);
            // 
            // btnAddB
            // 
            this.btnAddB.Location = new System.Drawing.Point(7, 397);
            this.btnAddB.Name = "btnAddB";
            this.btnAddB.Size = new System.Drawing.Size(100, 23);
            this.btnAddB.TabIndex = 5;
            this.btnAddB.Text = "Add";
            this.btnAddB.UseVisualStyleBackColor = true;
            this.btnAddB.Click += new System.EventHandler(this.btnAddB_Click);
            // 
            // dtCalendar
            // 
            this.dtCalendar.CustomFormat = "dd-MMM-yy";
            this.dtCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCalendar.Location = new System.Drawing.Point(7, 371);
            this.dtCalendar.MaxDate = new System.DateTime(2019, 12, 25, 23, 59, 59, 0);
            this.dtCalendar.Name = "dtCalendar";
            this.dtCalendar.Size = new System.Drawing.Size(206, 20);
            this.dtCalendar.TabIndex = 2;
            // 
            // lstBookings
            // 
            this.lstBookings.Location = new System.Drawing.Point(6, 19);
            this.lstBookings.Name = "lstBookings";
            this.lstBookings.Size = new System.Drawing.Size(302, 199);
            this.lstBookings.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CfrmRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CfrmRentals";
            this.Text = "Guesthouse Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstRooms;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstBookings;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.Button btnDeleteC;
        private System.Windows.Forms.Button btnAddC;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.Button btnDeleteB;
        private System.Windows.Forms.Button btnAddB;
        private System.Windows.Forms.DateTimePicker dtCalendar;
        private System.Windows.Forms.ImageList imageList1;
    }
}

