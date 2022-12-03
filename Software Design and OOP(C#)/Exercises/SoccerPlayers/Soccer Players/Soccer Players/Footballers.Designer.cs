namespace Soccer_Players
{
    partial class Footballers
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
            this.txbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.nudGoals = new System.Windows.Forms.NumericUpDown();
            this.nudAssists = new System.Windows.Forms.NumericUpDown();
            this.grpbAddPlayer = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstbxPlayers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGoals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAssists)).BeginInit();
            this.grpbAddPlayer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(6, 43);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(100, 20);
            this.txbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Goals";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Assists";
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(6, 86);
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(40, 20);
            this.nudAge.TabIndex = 5;
            // 
            // nudGoals
            // 
            this.nudGoals.Location = new System.Drawing.Point(6, 129);
            this.nudGoals.Name = "nudGoals";
            this.nudGoals.Size = new System.Drawing.Size(40, 20);
            this.nudGoals.TabIndex = 6;
            // 
            // nudAssists
            // 
            this.nudAssists.Location = new System.Drawing.Point(6, 170);
            this.nudAssists.Name = "nudAssists";
            this.nudAssists.Size = new System.Drawing.Size(40, 20);
            this.nudAssists.TabIndex = 7;
            // 
            // grpbAddPlayer
            // 
            this.grpbAddPlayer.Controls.Add(this.btnAdd);
            this.grpbAddPlayer.Controls.Add(this.txbName);
            this.grpbAddPlayer.Controls.Add(this.nudAssists);
            this.grpbAddPlayer.Controls.Add(this.label1);
            this.grpbAddPlayer.Controls.Add(this.nudGoals);
            this.grpbAddPlayer.Controls.Add(this.label2);
            this.grpbAddPlayer.Controls.Add(this.nudAge);
            this.grpbAddPlayer.Controls.Add(this.label3);
            this.grpbAddPlayer.Controls.Add(this.label4);
            this.grpbAddPlayer.Location = new System.Drawing.Point(12, 26);
            this.grpbAddPlayer.Name = "grpbAddPlayer";
            this.grpbAddPlayer.Size = new System.Drawing.Size(160, 220);
            this.grpbAddPlayer.TabIndex = 1;
            this.grpbAddPlayer.TabStop = false;
            this.grpbAddPlayer.Text = "Add Player";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(94, 167);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstbxPlayers);
            this.groupBox1.Location = new System.Drawing.Point(194, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 323);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player List";
            // 
            // lstbxPlayers
            // 
            this.lstbxPlayers.FormattingEnabled = true;
            this.lstbxPlayers.Location = new System.Drawing.Point(18, 19);
            this.lstbxPlayers.Name = "lstbxPlayers";
            this.lstbxPlayers.Size = new System.Drawing.Size(203, 290);
            this.lstbxPlayers.TabIndex = 1;
            // 
            // Footballers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbAddPlayer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Footballers";
            this.Text = "Footballers";
            this.Load += new System.EventHandler(this.Footballers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGoals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAssists)).EndInit();
            this.grpbAddPlayer.ResumeLayout(false);
            this.grpbAddPlayer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.NumericUpDown nudGoals;
        private System.Windows.Forms.NumericUpDown nudAssists;
        private System.Windows.Forms.GroupBox grpbAddPlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstbxPlayers;
    }
}

