namespace StudentHouseingCompanyV_2
{
    partial class FrmBalance
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
            this.btnExitBalnce = new System.Windows.Forms.Button();
            this.lvwBlancesOverView = new System.Windows.Forms.ListView();
            this.IDInfrm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameInFrm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.balancInFrm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnExitBalnce
            // 
            this.btnExitBalnce.Location = new System.Drawing.Point(69, 502);
            this.btnExitBalnce.Name = "btnExitBalnce";
            this.btnExitBalnce.Size = new System.Drawing.Size(267, 41);
            this.btnExitBalnce.TabIndex = 33;
            this.btnExitBalnce.Text = "Back out from Balance";
            this.btnExitBalnce.UseVisualStyleBackColor = true;
            this.btnExitBalnce.Click += new System.EventHandler(this.btnExitBalnce_Click);
            // 
            // lvwBlancesOverView
            // 
            this.lvwBlancesOverView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDInfrm,
            this.NameInFrm,
            this.balancInFrm});
            this.lvwBlancesOverView.HideSelection = false;
            this.lvwBlancesOverView.Location = new System.Drawing.Point(35, 62);
            this.lvwBlancesOverView.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lvwBlancesOverView.Name = "lvwBlancesOverView";
            this.lvwBlancesOverView.Size = new System.Drawing.Size(349, 391);
            this.lvwBlancesOverView.TabIndex = 32;
            this.lvwBlancesOverView.UseCompatibleStateImageBehavior = false;
            this.lvwBlancesOverView.View = System.Windows.Forms.View.Details;
            // 
            // IDInfrm
            // 
            this.IDInfrm.Text = "Id";
            this.IDInfrm.Width = 57;
            // 
            // NameInFrm
            // 
            this.NameInFrm.Text = "Name";
            this.NameInFrm.Width = 75;
            // 
            // balancInFrm
            // 
            this.balancInFrm.Text = "Balance";
            this.balancInFrm.Width = 213;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmBalance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(418, 582);
            this.Controls.Add(this.btnExitBalnce);
            this.Controls.Add(this.lvwBlancesOverView);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBalance";
            this.Text = "FrmBalance";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBalance_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmBalance_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmBalance_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExitBalnce;
        private System.Windows.Forms.ListView lvwBlancesOverView;
        private System.Windows.Forms.ColumnHeader IDInfrm;
        private System.Windows.Forms.ColumnHeader NameInFrm;
        private System.Windows.Forms.ColumnHeader balancInFrm;
        private System.Windows.Forms.Timer timer1;
    }
}