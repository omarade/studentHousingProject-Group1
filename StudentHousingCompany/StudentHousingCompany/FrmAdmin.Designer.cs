namespace StudentHousingCompany
{
    partial class FrmAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tpMngUsrs = new System.Windows.Forms.TabPage();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.dgdUsers = new System.Windows.Forms.DataGridView();
            this.hxtId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hxtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hxtDob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hxtEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hxtPhoneNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hxtPostcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hxtAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtbDoB = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.cboUserType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rbtnTenant = new System.Windows.Forms.RadioButton();
            this.rbtnAdmin = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhoneNr = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnNextWeek = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.cbWeekDays = new System.Windows.Forms.ComboBox();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbRemoveTasks = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.listView6 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbTaskName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSendReply = new System.Windows.Forms.Button();
            this.tbxReply = new System.Windows.Forms.TextBox();
            this.btnReplyToComp = new System.Windows.Forms.Button();
            this.lbxComp = new System.Windows.Forms.ListBox();
            this.btnComplaintResolve = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCurrentUserName = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpMngUsrs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsers)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tpMngUsrs);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 46);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1501, 641);
            this.tabControl.TabIndex = 0;
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPage1.Size = new System.Drawing.Size(1493, 612);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "House rules";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 550);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 38);
            this.button3.TabIndex = 7;
            this.button3.Text = "Confirm";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 550);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Undo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(37, 46);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(285, 468);
            this.listBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Announcment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Subject";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(905, 550);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(500, 116);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(563, 406);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(500, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 22);
            this.textBox1.TabIndex = 0;
            // 
            // tpMngUsrs
            // 
            this.tpMngUsrs.BackColor = System.Drawing.SystemColors.Control;
            this.tpMngUsrs.Controls.Add(this.btnRemoveUser);
            this.tpMngUsrs.Controls.Add(this.dgdUsers);
            this.tpMngUsrs.Controls.Add(this.dtbDoB);
            this.tpMngUsrs.Controls.Add(this.label20);
            this.tpMngUsrs.Controls.Add(this.cboUserType);
            this.tpMngUsrs.Controls.Add(this.label19);
            this.tpMngUsrs.Controls.Add(this.rbtnTenant);
            this.tpMngUsrs.Controls.Add(this.rbtnAdmin);
            this.tpMngUsrs.Controls.Add(this.label18);
            this.tpMngUsrs.Controls.Add(this.txtAddress);
            this.tpMngUsrs.Controls.Add(this.btnUpdateUser);
            this.tpMngUsrs.Controls.Add(this.label11);
            this.tpMngUsrs.Controls.Add(this.label10);
            this.tpMngUsrs.Controls.Add(this.txtPostcode);
            this.tpMngUsrs.Controls.Add(this.btnAddUser);
            this.tpMngUsrs.Controls.Add(this.label9);
            this.tpMngUsrs.Controls.Add(this.label8);
            this.tpMngUsrs.Controls.Add(this.txtPassword);
            this.tpMngUsrs.Controls.Add(this.label7);
            this.tpMngUsrs.Controls.Add(this.label6);
            this.tpMngUsrs.Controls.Add(this.label5);
            this.tpMngUsrs.Controls.Add(this.label4);
            this.tpMngUsrs.Controls.Add(this.txtPhoneNr);
            this.tpMngUsrs.Controls.Add(this.txtEmail);
            this.tpMngUsrs.Controls.Add(this.txtName);
            this.tpMngUsrs.Location = new System.Drawing.Point(4, 25);
            this.tpMngUsrs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tpMngUsrs.Name = "tpMngUsrs";
            this.tpMngUsrs.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tpMngUsrs.Size = new System.Drawing.Size(1493, 612);
            this.tpMngUsrs.TabIndex = 3;
            this.tpMngUsrs.Text = "Manage Users";
            this.tpMngUsrs.Click += new System.EventHandler(this.tpMngUsrs_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(1219, 522);
            this.btnRemoveUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(240, 50);
            this.btnRemoveUser.TabIndex = 51;
            this.btnRemoveUser.Text = "Remove Selected User";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // dgdUsers
            // 
            this.dgdUsers.AllowUserToAddRows = false;
            this.dgdUsers.AllowUserToDeleteRows = false;
            this.dgdUsers.AllowUserToOrderColumns = true;
            this.dgdUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            this.dgdUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgdUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgdUsers.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hxtId,
            this.hxtName,
            this.hxtDob,
            this.hxtEmail,
            this.hxtPhoneNr,
            this.hxtPostcode,
            this.hxtAddress});
            this.dgdUsers.Location = new System.Drawing.Point(573, 149);
            this.dgdUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgdUsers.MultiSelect = false;
            this.dgdUsers.Name = "dgdUsers";
            this.dgdUsers.ReadOnly = true;
            this.dgdUsers.RowHeadersVisible = false;
            this.dgdUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            this.dgdUsers.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgdUsers.RowTemplate.Height = 24;
            this.dgdUsers.RowTemplate.ReadOnly = true;
            this.dgdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdUsers.Size = new System.Drawing.Size(886, 348);
            this.dgdUsers.TabIndex = 50;
            this.dgdUsers.SelectionChanged += new System.EventHandler(this.dgdUsers_SelectionChanged);
            // 
            // hxtId
            // 
            this.hxtId.HeaderText = "ID";
            this.hxtId.MinimumWidth = 30;
            this.hxtId.Name = "hxtId";
            this.hxtId.ReadOnly = true;
            this.hxtId.Width = 60;
            // 
            // hxtName
            // 
            this.hxtName.HeaderText = "Name";
            this.hxtName.MinimumWidth = 6;
            this.hxtName.Name = "hxtName";
            this.hxtName.ReadOnly = true;
            this.hxtName.Width = 84;
            // 
            // hxtDob
            // 
            this.hxtDob.HeaderText = "DoB";
            this.hxtDob.MinimumWidth = 6;
            this.hxtDob.Name = "hxtDob";
            this.hxtDob.ReadOnly = true;
            this.hxtDob.Width = 74;
            // 
            // hxtEmail
            // 
            this.hxtEmail.HeaderText = "Email";
            this.hxtEmail.MinimumWidth = 6;
            this.hxtEmail.Name = "hxtEmail";
            this.hxtEmail.ReadOnly = true;
            this.hxtEmail.Width = 81;
            // 
            // hxtPhoneNr
            // 
            this.hxtPhoneNr.HeaderText = "Phone Nr";
            this.hxtPhoneNr.MinimumWidth = 6;
            this.hxtPhoneNr.Name = "hxtPhoneNr";
            this.hxtPhoneNr.ReadOnly = true;
            this.hxtPhoneNr.Width = 107;
            // 
            // hxtPostcode
            // 
            this.hxtPostcode.HeaderText = "Postcode";
            this.hxtPostcode.MinimumWidth = 6;
            this.hxtPostcode.Name = "hxtPostcode";
            this.hxtPostcode.ReadOnly = true;
            this.hxtPostcode.Width = 106;
            // 
            // hxtAddress
            // 
            this.hxtAddress.HeaderText = "Address";
            this.hxtAddress.MinimumWidth = 6;
            this.hxtAddress.Name = "hxtAddress";
            this.hxtAddress.ReadOnly = true;
            this.hxtAddress.Width = 99;
            // 
            // dtbDoB
            // 
            this.dtbDoB.Location = new System.Drawing.Point(211, 212);
            this.dtbDoB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtbDoB.Name = "dtbDoB";
            this.dtbDoB.Size = new System.Drawing.Size(312, 22);
            this.dtbDoB.TabIndex = 49;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(573, 94);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 17);
            this.label20.TabIndex = 48;
            this.label20.Text = "Filter By";
            // 
            // cboUserType
            // 
            this.cboUserType.Items.AddRange(new object[] {
            "All",
            "Admins",
            "Tenants"});
            this.cboUserType.Location = new System.Drawing.Point(697, 90);
            this.cboUserType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboUserType.Name = "cboUserType";
            this.cboUserType.Size = new System.Drawing.Size(283, 24);
            this.cboUserType.TabIndex = 47;
            this.cboUserType.Text = "All";
            this.cboUserType.SelectedIndexChanged += new System.EventHandler(this.cboUserType_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(87, 118);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 17);
            this.label19.TabIndex = 46;
            this.label19.Text = "User Type";
            // 
            // rbtnTenant
            // 
            this.rbtnTenant.AutoSize = true;
            this.rbtnTenant.Location = new System.Drawing.Point(309, 117);
            this.rbtnTenant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnTenant.Name = "rbtnTenant";
            this.rbtnTenant.Size = new System.Drawing.Size(74, 21);
            this.rbtnTenant.TabIndex = 45;
            this.rbtnTenant.TabStop = true;
            this.rbtnTenant.Text = "Tenant";
            this.rbtnTenant.UseVisualStyleBackColor = true;
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.Location = new System.Drawing.Point(211, 117);
            this.rbtnAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(68, 21);
            this.rbtnAdmin.TabIndex = 44;
            this.rbtnAdmin.TabStop = true;
            this.rbtnAdmin.Text = "Admin";
            this.rbtnAdmin.UseVisualStyleBackColor = true;
            this.rbtnAdmin.CheckedChanged += new System.EventHandler(this.rbtnAdmin_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(87, 458);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 17);
            this.label18.TabIndex = 43;
            this.label18.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(211, 452);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(312, 22);
            this.txtAddress.TabIndex = 42;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(297, 522);
            this.btnUpdateUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(227, 50);
            this.btnUpdateUser.TabIndex = 41;
            this.btnUpdateUser.Text = "Update Selected User";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(571, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 40;
            this.label11.Text = "Users Overview";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 409);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 39;
            this.label10.Text = "Postcode";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(211, 402);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(312, 22);
            this.txtPostcode.TabIndex = 38;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(91, 522);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(172, 50);
            this.btnAddUser.TabIndex = 37;
            this.btnAddUser.Text = "Create User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "New User Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 310);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(211, 306);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(312, 22);
            this.txtPassword.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 357);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "Phone Nr";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 260);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 212);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "DoB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Name";
            // 
            // txtPhoneNr
            // 
            this.txtPhoneNr.Location = new System.Drawing.Point(211, 353);
            this.txtPhoneNr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhoneNr.Name = "txtPhoneNr";
            this.txtPhoneNr.Size = new System.Drawing.Size(312, 22);
            this.txtPhoneNr.TabIndex = 29;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(211, 260);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(312, 22);
            this.txtEmail.TabIndex = 28;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(211, 164);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(312, 22);
            this.txtName.TabIndex = 27;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.BtnNextWeek);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.cbWeekDays);
            this.tabPage2.Controls.Add(this.btnRemoveTask);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.cbRemoveTasks);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.listView6);
            this.tabPage2.Controls.Add(this.btnAddTask);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbTaskName);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1493, 612);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tasks";
            // 
            // BtnNextWeek
            // 
            this.BtnNextWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNextWeek.Location = new System.Drawing.Point(449, 553);
            this.BtnNextWeek.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.BtnNextWeek.Name = "BtnNextWeek";
            this.BtnNextWeek.Size = new System.Drawing.Size(219, 46);
            this.BtnNextWeek.TabIndex = 13;
            this.BtnNextWeek.Text = "Next Week";
            this.BtnNextWeek.UseVisualStyleBackColor = true;
            this.BtnNextWeek.Click += new System.EventHandler(this.BtnNextWeek_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(36, 153);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(137, 25);
            this.label21.TabIndex = 11;
            this.label21.Text = "Task Due Day";
            // 
            // cbWeekDays
            // 
            this.cbWeekDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWeekDays.FormattingEnabled = true;
            this.cbWeekDays.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saterday",
            "Sunday"});
            this.cbWeekDays.Location = new System.Drawing.Point(43, 186);
            this.cbWeekDays.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbWeekDays.Name = "cbWeekDays";
            this.cbWeekDays.Size = new System.Drawing.Size(217, 33);
            this.cbWeekDays.TabIndex = 10;
            this.cbWeekDays.SelectedIndexChanged += new System.EventHandler(this.cbWeekDays_SelectedIndexChanged);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTask.Location = new System.Drawing.Point(43, 551);
            this.btnRemoveTask.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(176, 46);
            this.btnRemoveTask.TabIndex = 9;
            this.btnRemoveTask.Text = "Remove";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(36, 470);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 25);
            this.label14.TabIndex = 8;
            this.label14.Text = "Tasks";
            // 
            // cbRemoveTasks
            // 
            this.cbRemoveTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRemoveTasks.FormattingEnabled = true;
            this.cbRemoveTasks.Location = new System.Drawing.Point(43, 503);
            this.cbRemoveTasks.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbRemoveTasks.Name = "cbRemoveTasks";
            this.cbRemoveTasks.Size = new System.Drawing.Size(227, 33);
            this.cbRemoveTasks.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(441, 62);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 25);
            this.label13.TabIndex = 6;
            this.label13.Text = "This Week Tasks";
            // 
            // listView6
            // 
            this.listView6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader1});
            this.listView6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView6.HideSelection = false;
            this.listView6.Location = new System.Drawing.Point(449, 114);
            this.listView6.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(928, 435);
            this.listView6.TabIndex = 5;
            this.listView6.UseCompatibleStateImageBehavior = false;
            this.listView6.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Task";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Status";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Due Day";
            this.columnHeader1.Width = 100;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.Location = new System.Drawing.Point(43, 271);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(117, 54);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 39);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "Task Title";
            // 
            // tbTaskName
            // 
            this.tbTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTaskName.Location = new System.Drawing.Point(43, 90);
            this.tbTaskName.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbTaskName.Name = "tbTaskName";
            this.tbTaskName.Size = new System.Drawing.Size(233, 30);
            this.tbTaskName.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btnSendReply);
            this.tabPage3.Controls.Add(this.tbxReply);
            this.tabPage3.Controls.Add(this.btnReplyToComp);
            this.tabPage3.Controls.Add(this.lbxComp);
            this.tabPage3.Controls.Add(this.btnComplaintResolve);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1476, 634);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Complaints";
            // 
            // btnSendReply
            // 
            this.btnSendReply.Location = new System.Drawing.Point(239, 506);
            this.btnSendReply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendReply.Name = "btnSendReply";
            this.btnSendReply.Size = new System.Drawing.Size(117, 81);
            this.btnSendReply.TabIndex = 6;
            this.btnSendReply.Text = "Send Reply";
            this.btnSendReply.UseVisualStyleBackColor = true;
            this.btnSendReply.Visible = false;
            this.btnSendReply.Click += new System.EventHandler(this.btnSendReply_Click);
            // 
            // tbxReply
            // 
            this.tbxReply.Location = new System.Drawing.Point(51, 84);
            this.tbxReply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxReply.Multiline = true;
            this.tbxReply.Name = "tbxReply";
            this.tbxReply.Size = new System.Drawing.Size(504, 358);
            this.tbxReply.TabIndex = 5;
            this.tbxReply.Visible = false;
            // 
            // btnReplyToComp
            // 
            this.btnReplyToComp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReplyToComp.Location = new System.Drawing.Point(239, 506);
            this.btnReplyToComp.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReplyToComp.Name = "btnReplyToComp";
            this.btnReplyToComp.Size = new System.Drawing.Size(117, 81);
            this.btnReplyToComp.TabIndex = 4;
            this.btnReplyToComp.Text = "Reply";
            this.btnReplyToComp.UseVisualStyleBackColor = true;
            this.btnReplyToComp.Click += new System.EventHandler(this.btnReplyToComp_Click);
            // 
            // lbxComp
            // 
            this.lbxComp.FormattingEnabled = true;
            this.lbxComp.ItemHeight = 16;
            this.lbxComp.Location = new System.Drawing.Point(53, 84);
            this.lbxComp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lbxComp.Name = "lbxComp";
            this.lbxComp.Size = new System.Drawing.Size(501, 356);
            this.lbxComp.TabIndex = 3;
            // 
            // btnComplaintResolve
            // 
            this.btnComplaintResolve.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnComplaintResolve.Location = new System.Drawing.Point(53, 506);
            this.btnComplaintResolve.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnComplaintResolve.Name = "btnComplaintResolve";
            this.btnComplaintResolve.Size = new System.Drawing.Size(120, 81);
            this.btnComplaintResolve.TabIndex = 2;
            this.btnComplaintResolve.Text = "Resolve";
            this.btnComplaintResolve.UseVisualStyleBackColor = true;
            this.btnComplaintResolve.Click += new System.EventHandler(this.btnComplaintResolve_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(47, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 29);
            this.label15.TabIndex = 1;
            this.label15.Text = "Complaintes";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 17);
            this.label16.TabIndex = 1;
            this.label16.Text = "Admin Name";
            // 
            // lblCurrentUserName
            // 
            this.lblCurrentUserName.AutoSize = true;
            this.lblCurrentUserName.Location = new System.Drawing.Point(121, 11);
            this.lblCurrentUserName.Name = "lblCurrentUserName";
            this.lblCurrentUserName.Size = new System.Drawing.Size(0, 17);
            this.lblCurrentUserName.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1375, 20);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 34);
            this.button4.TabIndex = 3;
            this.button4.Text = "Go to Tenant";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1258, 20);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(89, 34);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 692);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblCurrentUserName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FrmAdmin";
            this.Text = "Student Housing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAdmin_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpMngUsrs.ResumeLayout(false);
            this.tpMngUsrs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tpMngUsrs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbTaskName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView listView6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbRemoveTasks;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnComplaintResolve;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCurrentUserName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbWeekDays;
        private System.Windows.Forms.Button BtnNextWeek;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.DataGridView dgdUsers;
        private System.Windows.Forms.DateTimePicker dtbDoB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboUserType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rbtnTenant;
        private System.Windows.Forms.RadioButton rbtnAdmin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhoneNr;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtId;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtDob;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtPhoneNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtPostcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn hxtAddress;
        private System.Windows.Forms.ListBox lbxComp;
        private System.Windows.Forms.Button btnReplyToComp;
        private System.Windows.Forms.TextBox tbxReply;
        private System.Windows.Forms.Button btnSendReply;
        private System.Windows.Forms.Button btnLogout;
    }
}