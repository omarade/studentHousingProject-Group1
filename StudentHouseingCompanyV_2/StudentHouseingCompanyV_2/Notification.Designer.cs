namespace StudentHouseingCompanyV_2
{
    partial class Notification
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
            this.pbTempIcon = new System.Windows.Forms.PictureBox();
            this.labelBody = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTempIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTempIcon
            // 
            this.pbTempIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.pbTempIcon.Image = global::StudentHouseingCompanyV_2.Properties.Resources.hot1;
            this.pbTempIcon.Location = new System.Drawing.Point(55, 46);
            this.pbTempIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbTempIcon.Name = "pbTempIcon";
            this.pbTempIcon.Size = new System.Drawing.Size(62, 57);
            this.pbTempIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTempIcon.TabIndex = 3;
            this.pbTempIcon.TabStop = false;
            // 
            // labelBody
            // 
            this.labelBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBody.ForeColor = System.Drawing.Color.White;
            this.labelBody.Location = new System.Drawing.Point(137, 59);
            this.labelBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(315, 44);
            this.labelBody.TabIndex = 2;
            this.labelBody.Text = "Temp is too high 25";
            this.labelBody.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelBody.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(535, 152);
            this.Controls.Add(this.pbTempIcon);
            this.Controls.Add(this.labelBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.Text = "Notification";
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notification_FormClosed);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.Click += new System.EventHandler(this.Notification_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbTempIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTempIcon;
        private System.Windows.Forms.Label labelBody;
    }
}