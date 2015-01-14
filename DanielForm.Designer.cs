namespace SimFarm
{
    partial class DanielForm
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
            this.tmrFarmAge = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrFarmAge
            // 
            this.tmrFarmAge.Enabled = true;
            this.tmrFarmAge.Interval = 1000;
            this.tmrFarmAge.Tick += new System.EventHandler(this.tmrFarmAge_Tick);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 25;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(787, 9);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(39, 13);
            this.lblMoney.TabIndex = 0;
            this.lblMoney.Text = "Money";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(790, 26);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(52, 13);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Farm Age";
            // 
            // DanielForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 189);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblMoney);
            this.DoubleBuffered = true;
            this.Name = "DanielForm";
            this.Text = "SimFarm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SimFarmForm_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SimFarmForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DanielForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SimFarmForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SimFarmForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrFarmAge;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblAge;
    }
}

