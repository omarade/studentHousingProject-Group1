namespace StudentHouseingCompanyV_2
{
    partial class FrmAddEvent
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
            this.gbNewEvent = new System.Windows.Forms.GroupBox();
            this.tbEventName = new System.Windows.Forms.TextBox();
            this.btnEventCancel = new System.Windows.Forms.Button();
            this.lblNewEventName = new System.Windows.Forms.Label();
            this.btnEventConfirm = new System.Windows.Forms.Button();
            this.lblNewEventDesc = new System.Windows.Forms.Label();
            this.dtEvent = new System.Windows.Forms.DateTimePicker();
            this.lblNewEventDate = new System.Windows.Forms.Label();
            this.tbEventDesc = new System.Windows.Forms.TextBox();
            this.gbNewEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNewEvent
            // 
            this.gbNewEvent.Controls.Add(this.tbEventName);
            this.gbNewEvent.Controls.Add(this.btnEventCancel);
            this.gbNewEvent.Controls.Add(this.lblNewEventName);
            this.gbNewEvent.Controls.Add(this.btnEventConfirm);
            this.gbNewEvent.Controls.Add(this.lblNewEventDesc);
            this.gbNewEvent.Controls.Add(this.dtEvent);
            this.gbNewEvent.Controls.Add(this.lblNewEventDate);
            this.gbNewEvent.Controls.Add(this.tbEventDesc);
            this.gbNewEvent.ForeColor = System.Drawing.Color.White;
            this.gbNewEvent.Location = new System.Drawing.Point(30, 33);
            this.gbNewEvent.Name = "gbNewEvent";
            this.gbNewEvent.Size = new System.Drawing.Size(306, 437);
            this.gbNewEvent.TabIndex = 19;
            this.gbNewEvent.TabStop = false;
            this.gbNewEvent.Text = "Create A new Event";
            // 
            // tbEventName
            // 
            this.tbEventName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.tbEventName.Location = new System.Drawing.Point(21, 67);
            this.tbEventName.Margin = new System.Windows.Forms.Padding(2);
            this.tbEventName.Name = "tbEventName";
            this.tbEventName.Size = new System.Drawing.Size(156, 24);
            this.tbEventName.TabIndex = 10;
            // 
            // btnEventCancel
            // 
            this.btnEventCancel.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnEventCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(118)))));
            this.btnEventCancel.Location = new System.Drawing.Point(197, 371);
            this.btnEventCancel.Name = "btnEventCancel";
            this.btnEventCancel.Size = new System.Drawing.Size(87, 43);
            this.btnEventCancel.TabIndex = 17;
            this.btnEventCancel.Text = "Cancel";
            this.btnEventCancel.UseVisualStyleBackColor = true;
            this.btnEventCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNewEventName
            // 
            this.lblNewEventName.AutoSize = true;
            this.lblNewEventName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblNewEventName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(118)))));
            this.lblNewEventName.Location = new System.Drawing.Point(18, 39);
            this.lblNewEventName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewEventName.Name = "lblNewEventName";
            this.lblNewEventName.Size = new System.Drawing.Size(112, 19);
            this.lblNewEventName.TabIndex = 11;
            this.lblNewEventName.Text = "Name of event";
            // 
            // btnEventConfirm
            // 
            this.btnEventConfirm.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnEventConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(118)))));
            this.btnEventConfirm.Location = new System.Drawing.Point(21, 371);
            this.btnEventConfirm.Name = "btnEventConfirm";
            this.btnEventConfirm.Size = new System.Drawing.Size(87, 43);
            this.btnEventConfirm.TabIndex = 16;
            this.btnEventConfirm.Text = "Confirm";
            this.btnEventConfirm.UseVisualStyleBackColor = true;
            this.btnEventConfirm.Click += new System.EventHandler(this.btnEventConfirm_Click);
            // 
            // lblNewEventDesc
            // 
            this.lblNewEventDesc.AutoSize = true;
            this.lblNewEventDesc.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblNewEventDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(118)))));
            this.lblNewEventDesc.Location = new System.Drawing.Point(18, 104);
            this.lblNewEventDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewEventDesc.Name = "lblNewEventDesc";
            this.lblNewEventDesc.Size = new System.Drawing.Size(173, 19);
            this.lblNewEventDesc.TabIndex = 14;
            this.lblNewEventDesc.Text = "Description of the event";
            // 
            // dtEvent
            // 
            this.dtEvent.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.dtEvent.Location = new System.Drawing.Point(21, 316);
            this.dtEvent.Margin = new System.Windows.Forms.Padding(2);
            this.dtEvent.Name = "dtEvent";
            this.dtEvent.Size = new System.Drawing.Size(263, 24);
            this.dtEvent.TabIndex = 12;
            // 
            // lblNewEventDate
            // 
            this.lblNewEventDate.AutoSize = true;
            this.lblNewEventDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblNewEventDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(118)))));
            this.lblNewEventDate.Location = new System.Drawing.Point(18, 285);
            this.lblNewEventDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewEventDate.Name = "lblNewEventDate";
            this.lblNewEventDate.Size = new System.Drawing.Size(131, 19);
            this.lblNewEventDate.TabIndex = 15;
            this.lblNewEventDate.Text = "Date of the event";
            // 
            // tbEventDesc
            // 
            this.tbEventDesc.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.tbEventDesc.Location = new System.Drawing.Point(21, 125);
            this.tbEventDesc.Margin = new System.Windows.Forms.Padding(2);
            this.tbEventDesc.Multiline = true;
            this.tbEventDesc.Name = "tbEventDesc";
            this.tbEventDesc.Size = new System.Drawing.Size(263, 143);
            this.tbEventDesc.TabIndex = 13;
            // 
            // FrmAddEvent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(383, 499);
            this.Controls.Add(this.gbNewEvent);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmAddEvent";
            this.Text = "FrmAddEvent";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmAddEvent_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmAddEvent_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmAddEvent_MouseUp);
            this.gbNewEvent.ResumeLayout(false);
            this.gbNewEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNewEvent;
        private System.Windows.Forms.TextBox tbEventName;
        private System.Windows.Forms.Button btnEventCancel;
        private System.Windows.Forms.Label lblNewEventName;
        private System.Windows.Forms.Button btnEventConfirm;
        private System.Windows.Forms.Label lblNewEventDesc;
        private System.Windows.Forms.DateTimePicker dtEvent;
        private System.Windows.Forms.Label lblNewEventDate;
        private System.Windows.Forms.TextBox tbEventDesc;
    }
}