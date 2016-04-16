namespace VotingSystem
{
    partial class FormsBasedUI
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
            this.configBtn = new System.Windows.Forms.Button();
            this.RunProducerConsumerBtn = new System.Windows.Forms.Button();
            this.progressLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbx_data = new System.Windows.Forms.ListBox();
            this.ConstInfoBtn = new System.Windows.Forms.Button();
            this.constWinnerBtn = new System.Windows.Forms.Button();
            this.SumPartiesBtn = new System.Windows.Forms.Button();
            this.WinnerPartyBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdv_more_info = new System.Windows.Forms.DataGridView();
            this.lbl_help = new System.Windows.Forms.Label();
            this.lblPartyWinner = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdv_more_info)).BeginInit();
            this.SuspendLayout();
            // 
            // configBtn
            // 
            this.configBtn.Location = new System.Drawing.Point(30, 286);
            this.configBtn.Margin = new System.Windows.Forms.Padding(2);
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(191, 32);
            this.configBtn.TabIndex = 0;
            this.configBtn.Text = "Create Config Data";
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            // 
            // RunProducerConsumerBtn
            // 
            this.RunProducerConsumerBtn.Enabled = false;
            this.RunProducerConsumerBtn.Location = new System.Drawing.Point(30, 322);
            this.RunProducerConsumerBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RunProducerConsumerBtn.Name = "RunProducerConsumerBtn";
            this.RunProducerConsumerBtn.Size = new System.Drawing.Size(191, 29);
            this.RunProducerConsumerBtn.TabIndex = 1;
            this.RunProducerConsumerBtn.Text = "Load Vote Results Data";
            this.RunProducerConsumerBtn.UseVisualStyleBackColor = true;
            this.RunProducerConsumerBtn.Click += new System.EventHandler(this.RunProducerConsumerBtn_Click);
            // 
            // progressLbl
            // 
            this.progressLbl.AutoSize = true;
            this.progressLbl.Location = new System.Drawing.Point(42, 353);
            this.progressLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.progressLbl.Name = "progressLbl";
            this.progressLbl.Size = new System.Drawing.Size(73, 13);
            this.progressLbl.TabIndex = 2;
            this.progressLbl.Text = "Awaiting Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 353);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status:";
            // 
            // lbx_data
            // 
            this.lbx_data.FormattingEnabled = true;
            this.lbx_data.Location = new System.Drawing.Point(251, 115);
            this.lbx_data.Margin = new System.Windows.Forms.Padding(2);
            this.lbx_data.Name = "lbx_data";
            this.lbx_data.Size = new System.Drawing.Size(350, 82);
            this.lbx_data.TabIndex = 4;
            this.lbx_data.SelectedIndexChanged += new System.EventHandler(this.meanAsymListbox_SelectedIndexChanged);
            // 
            // ConstInfoBtn
            // 
            this.ConstInfoBtn.Enabled = false;
            this.ConstInfoBtn.Location = new System.Drawing.Point(251, 11);
            this.ConstInfoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConstInfoBtn.Name = "ConstInfoBtn";
            this.ConstInfoBtn.Size = new System.Drawing.Size(173, 32);
            this.ConstInfoBtn.TabIndex = 5;
            this.ConstInfoBtn.Text = "Display Constituency Information";
            this.ConstInfoBtn.UseVisualStyleBackColor = true;
            this.ConstInfoBtn.Click += new System.EventHandler(this.ConstInfoBtn_Click);
            // 
            // constWinnerBtn
            // 
            this.constWinnerBtn.Enabled = false;
            this.constWinnerBtn.Location = new System.Drawing.Point(251, 47);
            this.constWinnerBtn.Margin = new System.Windows.Forms.Padding(2);
            this.constWinnerBtn.Name = "constWinnerBtn";
            this.constWinnerBtn.Size = new System.Drawing.Size(173, 32);
            this.constWinnerBtn.TabIndex = 6;
            this.constWinnerBtn.Text = "Display Constituency Winner";
            this.constWinnerBtn.UseVisualStyleBackColor = true;
            this.constWinnerBtn.Click += new System.EventHandler(this.constWinnerBtn_Click);
            // 
            // SumPartiesBtn
            // 
            this.SumPartiesBtn.Enabled = false;
            this.SumPartiesBtn.Location = new System.Drawing.Point(428, 12);
            this.SumPartiesBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SumPartiesBtn.Name = "SumPartiesBtn";
            this.SumPartiesBtn.Size = new System.Drawing.Size(173, 32);
            this.SumPartiesBtn.TabIndex = 9;
            this.SumPartiesBtn.Text = "Show Parties and Their Votes";
            this.SumPartiesBtn.UseVisualStyleBackColor = true;
            this.SumPartiesBtn.Click += new System.EventHandler(this.SumPartiesBtn_Click);
            // 
            // WinnerPartyBtn
            // 
            this.WinnerPartyBtn.Enabled = false;
            this.WinnerPartyBtn.Location = new System.Drawing.Point(428, 48);
            this.WinnerPartyBtn.Margin = new System.Windows.Forms.Padding(2);
            this.WinnerPartyBtn.Name = "WinnerPartyBtn";
            this.WinnerPartyBtn.Size = new System.Drawing.Size(173, 32);
            this.WinnerPartyBtn.TabIndex = 10;
            this.WinnerPartyBtn.Text = "Show The Election Winner";
            this.WinnerPartyBtn.UseVisualStyleBackColor = true;
            this.WinnerPartyBtn.Click += new System.EventHandler(this.WinnerPartyBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VotingSystem.Properties.Resources.a;
            this.pictureBox1.InitialImage = global::VotingSystem.Properties.Resources.a;
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // grdv_more_info
            // 
            this.grdv_more_info.AllowUserToAddRows = false;
            this.grdv_more_info.AllowUserToDeleteRows = false;
            this.grdv_more_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdv_more_info.Location = new System.Drawing.Point(251, 218);
            this.grdv_more_info.Name = "grdv_more_info";
            this.grdv_more_info.ReadOnly = true;
            this.grdv_more_info.Size = new System.Drawing.Size(350, 148);
            this.grdv_more_info.TabIndex = 14;
            this.grdv_more_info.Visible = false;
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Location = new System.Drawing.Point(248, 100);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(312, 13);
            this.lbl_help.TabIndex = 15;
            this.lbl_help.Text = "To view more information, please select the wanted constituency";
            this.lbl_help.Visible = false;
            // 
            // lblPartyWinner
            // 
            this.lblPartyWinner.AutoSize = true;
            this.lblPartyWinner.Font = new System.Drawing.Font("Arial Unicode MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyWinner.Location = new System.Drawing.Point(303, 126);
            this.lblPartyWinner.Name = "lblPartyWinner";
            this.lblPartyWinner.Size = new System.Drawing.Size(0, 26);
            this.lblPartyWinner.TabIndex = 16;
            this.lblPartyWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPartyWinner.Visible = false;
            // 
            // FormsBasedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(617, 375);
            this.Controls.Add(this.lblPartyWinner);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.grdv_more_info);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WinnerPartyBtn);
            this.Controls.Add(this.SumPartiesBtn);
            this.Controls.Add(this.constWinnerBtn);
            this.Controls.Add(this.ConstInfoBtn);
            this.Controls.Add(this.lbx_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressLbl);
            this.Controls.Add(this.RunProducerConsumerBtn);
            this.Controls.Add(this.configBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormsBasedUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VotingSystem";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdv_more_info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button configBtn;
        private System.Windows.Forms.Button RunProducerConsumerBtn;
        private System.Windows.Forms.Label progressLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbx_data;
        private System.Windows.Forms.Button ConstInfoBtn;
        private System.Windows.Forms.Button constWinnerBtn;
        private System.Windows.Forms.Button SumPartiesBtn;
        private System.Windows.Forms.Button WinnerPartyBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView grdv_more_info;
        private System.Windows.Forms.Label lbl_help;
        private System.Windows.Forms.Label lblPartyWinner;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

