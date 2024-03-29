﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace StudentHouseingCompanyV_2
{
    public partial class FrmAdmin : Form
    {
        int mouseY;
        int mouseX;
        bool draggable;

        private double temperature = 18;
        private bool tempAlarm = false;
        private DateTime timeAlarmOn = DateTime.UtcNow;

        private StudentHousing studentHousing;
        DayOfWeek day = DayOfWeek.Monday;

        public FrmAdmin()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            ShowUsers();
            ShowTasks();
            timer1.Enabled = true;
            tmrUpdateComplaintes.Start();
            rbtnTenant.Checked = true;
            rbtnAdmin.Checked = false;
            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
            rtbHouseRules.Text = studentHousing.HouseRules;
            cbWeekDays.SelectedIndex = 0;
            prevNmrOfComp = nmrOfComp;

            if (IsArduinoConnected())
            {
                ChoosePortNumber();
                serialPort1.Open();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            studentHousing.CurrentUser = null;
            this.Hide();
            var frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            rtbHouseRules.Clear();
            rtbHouseRules.Text = studentHousing.HouseRules;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            DateTime dateOfBirth = dtbDoB.Value;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (rbtnAdmin.Checked)
            {
                if (ValidateUserInput(name, dateOfBirth, email, password))
                {
                    studentHousing.AddUser(name, dateOfBirth, email, password);
                }
            }
            else if (rbtnTenant.Checked)
            {
                string phoneNr = txtPhoneNr.Text;
                string postcode = txtPostcode.Text;
                string address = txtAddress.Text;

                if (ValidateUserInput(name, dateOfBirth, email, password, phoneNr, postcode, address))
                {
                    studentHousing.AddUser(name, dateOfBirth, email, password, phoneNr, postcode, address);
                }
            }

            ShowUsers();
            studentHousing.ResetSchedule();
            ShowTasks();
        }

        private void NewUserType()
        {
            if (rbtnAdmin.Checked)
            {
                txtPhoneNr.Enabled = false;
                txtPostcode.Enabled = false;
                txtAddress.Enabled = false;
            }
            else if (rbtnTenant.Checked)
            {
                txtPhoneNr.Enabled = true;
                txtPostcode.Enabled = true;
                txtAddress.Enabled = true;
            }
        }

        private void rbtnAdmin_CheckedChanged(object sender, EventArgs e)
        {
            NewUserType();
        }

        private void ShowUsers()
        {
            dgdUsers.Rows.Clear();
            var users = studentHousing.Users;

            foreach (var user in users)
            {
                if (user is Admin && cboUserType.Text != "Tenants")
                {
                    dgdUsers.Rows.Add(user.Id, user.Name, user.DateOfBirth.ToString("dd/MM/yyyy"), user.Email);
                }
                else if (user is Tenant && cboUserType.Text != "Admins")
                {
                    Tenant tenant = (Tenant)user;
                    dgdUsers.Rows.Add(tenant.Id, tenant.Name, tenant.DateOfBirth.ToString("dd/MM/yyyy"), tenant.Email, tenant.PhoneNr, tenant.Postcode, tenant.Address);
                }
            }
        }

        private bool ValidateUserInput(string name, DateTime dob, string email, string password)
        {
            TimeSpan ageSpan = DateTime.Now.Subtract(dob);
            int age = ageSpan.Days / 365;

            var users = studentHousing.Users;

            if (name == "")
            {
                MessageBox.Show("Name cannot be empty");
                return false;
            }

            if (age < 15)
            {
                MessageBox.Show("Invalid date of birth");
                return false;
            }

            if (email == "")
            {
                MessageBox.Show("Please enter an email");
                return false;
            }

            foreach (var user in users)
            {
                if (email == user.Email)
                {
                    MessageBox.Show("There is already an acount created with this email");
                    return false;
                }
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Password is too short");
                return false;
            }
            return true;
        }

        private bool ValidateUserInput(string name, DateTime dob, string email, string password, string phoneNr, string postcode, string address)
        {
            bool validInput = ValidateUserInput(name, dob, email, password);

            if (!validInput)
            {
                return false;
            }

            /*
            if (phoneNr.Length <= 9)
            {
                MessageBox.Show("Please enter a valid phone number");
                return false;
            }
            */

            if (postcode.Length != 6)
            {
                MessageBox.Show("Please enter the postcode in this format \"4356PP\" ");
                return false;
            }

            if (address == "")
            {
                MessageBox.Show("Please enter the address");
                return false;
            }
            return true;
        }

        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUsers();
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (dgdUsers.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdUsers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdUsers.Rows[selectedrowindex];
                int.TryParse(selectedRow.Cells["hxtId"].Value.ToString(), out int id);
                studentHousing.RemoveUser(id);
                ShowUsers();
                studentHousing.ResetSchedule();
                ShowTasks();
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgdUsers.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdUsers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdUsers.Rows[selectedrowindex];
                int.TryParse(selectedRow.Cells["hxtId"].Value.ToString(), out int id);

                FrmUdateUserInfo frmUdateUser = new FrmUdateUserInfo(id, this);
                this.Enabled = false;
                frmUdateUser.Show();
            }
            studentHousing.ResetSchedule();
            ShowTasks();
        }

        private void pnlUsers_Paint(object sender, PaintEventArgs e)
        {
            if (dgdUsers.SelectedCells.Count > 0)
            {
                ClearSelectedUser();
            }
        }

        private void ClearSelectedUser()
        {
            dgdUsers.ClearSelection();
            txtPassword.Enabled = true;
            txtName.Text = "";
            dtbDoB.Value = DateTime.Now;
            txtEmail.Text = "";
            txtPhoneNr.Text = "";
            txtPostcode.Text = "";
            txtAddress.Text = "";
        }

        private void BtnNextWeek_Click(object sender, EventArgs e)
        {
            //studentHousing.SetNextTenant();
            //studentHousing.SetNextDueDay();
            //ShowTasks();

            listView6.Items.Clear();
            var schedule = studentHousing.ShowNextWeek();

            foreach (var task in schedule)
            {
                listView6.Items.Add(task);
            }

            BtnNextWeek.Visible = false;
            btnCurrentWeek.Visible = true;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            //Adds a task with a unique name
            bool NameExsists = false;
            string TaskName = tbTaskName.Text;

            foreach (var task in studentHousing.Schedules)
            {
                if (TaskName == task.TaskName)
                {
                    NameExsists = true;
                }
            }

            if (NameExsists == false)
            {
                studentHousing.AddTask(TaskName, day);
            }
            else
            {
                MessageBox.Show("Task '" + TaskName + "' already exsists");
            }

            ShowTasks();
        }

        /// <summary>
        /// Fills the Listview with the info of every task
        ///
        /// </summary>
        public void ShowTasks()
        {
            listView6.Items.Clear();
            var schedule = studentHousing.Schedules;

            foreach (var task in schedule)
            {
                listView6.Items.Add(task.GetInfo());
            }
            FillRemoveTask();
            CheckTaskStatus();
        }

        private void cbWeekDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets the weekday due day for the new task
            switch (cbWeekDays.SelectedIndex)
            {
                case 0:
                    day = DayOfWeek.Monday;
                    break;

                case 1:
                    day = DayOfWeek.Tuesday;
                    break;

                case 2:
                    day = DayOfWeek.Wednesday;
                    break;

                case 3:
                    day = DayOfWeek.Thursday;
                    break;

                case 4:
                    day = DayOfWeek.Friday;
                    break;

                case 5:
                    day = DayOfWeek.Saturday;
                    break;

                case 6:
                    day = DayOfWeek.Sunday;
                    break;

                default:
                    day = DayOfWeek.Monday;
                    break;
            }
        }

        /// <summary>
        /// Fills the combobax with every task to remove the task
        /// </summary>
        public void FillRemoveTask()
        {
            cbRemoveTasks.Items.Clear();
            var schedule = studentHousing.Schedules;

            foreach (var task in schedule)
            {
                cbRemoveTasks.Items.Add(task.TaskName);
            }
        }

        /// <summary>
        /// Checks every task and highlights it in the listview to mark competion
        /// </summary>
        public void CheckTaskStatus()
        {
            int counter = 0;

            foreach (var task in studentHousing.Schedules)
            {
                if (task.Status == true)
                {
                    listView6.Items[counter].BackColor = Color.Green;
                }
                counter++;
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            //Removes task selected in the remove task combobox
            studentHousing.RemoveTask(cbRemoveTasks.Text);
            ShowTasks();
            cbRemoveTasks.Text = "";
        }

        private void btnComplaintResolve_Click(object sender, EventArgs e)
        {
            int selectdIndex = dgdComp.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgdComp.Rows[selectdIndex];
            //PS.I do not know why i can not delete the ToString method and take only the value yet?
            CompID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());

            foreach (Complaint comp in studentHousing.Complaintss)
            {
                if (comp.ComplaintId == CompID)
                {
                    comp.Solved = true;
                }
            }

            if (dgdComp.SelectedCells.Count > 0)
            {
                foreach (DataGridViewRow item in this.dgdComp.SelectedRows)
                {
                    dgdComp.Rows.RemoveAt(item.Index);

                }
            }
            else
            {
                MessageBox.Show("Select a complainet ");
            }
        }

        int idOfSelectedComp;
        int CompID;
        private void btnReplyToComp_Click(object sender, EventArgs e)
        {
            if (dgdComp.SelectedCells.Count > 0)
            {
                int selectdIndex = dgdComp.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdComp.Rows[selectdIndex];
                //PS.I do not know why i can not delete the ToString method and take only the value yet?
                CompID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
            }
            else
            {
                MessageBox.Show("please select a cpmlaint to reply to");
            }

            dgdComp.Visible = false;
            tbxReply.Visible = true;
            btnReplyToComp.Visible = false;
            btnSendReply.Visible = true;
        }

        private void btnSendReply_Click(object sender, EventArgs e)
        {
            //foreach (Complaint comp in studentHousing.Complaintss)
            //{
            //    if (comp.ComplaintId == CompID)
            //    {
            //        comp.ReplyFromAdmin = tbxReply.Text;
            //    }
            //}
            foreach (Tenant ten in studentHousing.GetTenants())
            {
                foreach (Complaint comp in ten.Complaints)
                {
                    if (comp.ComplaintId == CompID)
                    {
                        string reply = tbxReply.Text;
                        comp.ReplyFromAdmin = reply;
                    }
                }
            }

            tbxReply.Clear();
            tbxReply.Visible = false;
            dgdComp.Visible = true;

            btnReplyToComp.Visible = true;
            btnSendReply.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer to check if when a task should've been completed or when the week has passed

            //Checks if the next week startes to show new weekly tasks
            if (studentHousing.IsEndOfWeek() == true)
            {
                studentHousing.SetNextTenant();
                ShowTasks();
            }


            //Checks task that havent been competed by there due day
            int counter = 0;

            foreach (var task in studentHousing.Schedules)
            {
                if (task.DueDate.Date < DateTime.Now.Date)
                {
                    if (task.Status == false)
                    {
                        listView6.Items[counter].BackColor = Color.Red;
                    }
                    counter++;
                }
            }
        }

        private void btnUpdateHouseRules_Click(object sender, EventArgs e)
        {
            studentHousing.HouseRules = rtbHouseRules.Text;
        }

        private void btnAnnoCreate_Click(object sender, EventArgs e)
        {
            
            this.Enabled = false;
            var frmAnnouncement = new FrmAnnouncement(this);
            frmAnnouncement.Show();

            FillAnnouncement();
        }

        public void FillAnnouncement()
        {
            dgdAnnouncement.Rows.Clear();

            foreach (var currentAnno in studentHousing.Announcements)
            {
                dgdAnnouncement.Rows.Add(currentAnno.AnnouncementId, currentAnno.AnnouncementSubject, currentAnno.AnnouncementText);
            }
        }

        private void FrmAdmin_EnabledChanged(object sender, EventArgs e)
        {
            ShowUsers();
        }

        int nmrOfComp;
        int prevNmrOfComp;
        private void tmrUpdateComplaintes_Tick(object sender, EventArgs e)
        {
            nmrOfComp = studentHousing.Complaintss.Count();
            if (nmrOfComp != prevNmrOfComp)
            {
                dgdComp.Rows.Clear();
                prevNmrOfComp = nmrOfComp;
                foreach (Complaint comp in studentHousing.Complaintss)
                {
                    if (!comp.Solved)
                    {
                        if (comp.Anonymous)
                        {
                            dgdComp.Rows.Add(comp.ComplaintId, "Anonymous", comp.GetText());
                        }
                        else
                        {
                            dgdComp.Rows.Add(comp.ComplaintId, comp.CreaterName, comp.GetText());
                        }
                    }
                }
            }
        }

        private bool IsArduinoConnected()
        {
            string message = "Is the temperature monitoring system running?";
            string title = "Arduino Connection";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        void ChoosePortNumber()
        {
            bool validPortNum = false;
            while (!validPortNum)
            {
                string portnumber = Interaction.InputBox("Please choose the COM port number", "COM Port Number", "3");
                validPortNum = int.TryParse(portnumber, out int result);
                if (validPortNum)
                {
                    serialPort1.PortName = $"COM{result}";
                }
                else
                {
                    MessageBox.Show("Please enter a valid integer");
                }
            }
        }

        private void NewTemperatureLog(DateTime dateTime, string message)
        {
            string date = dateTime.ToString("dd/MM/yyyy");
            string time = dateTime.ToString("hh:mm tt");
            dgdTemperature.Invoke((Action)(() => dgdTemperature.Rows.Add(date, time, message)));
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.BytesToRead > 0)
            {
                string message = serialPort1.ReadLine();

                if (message.Contains("tempAlarm") && !tempAlarm)
                {
                    string msg = "";
                    tempAlarm = true;

                    if (temperature < 16)
                    {
                        msg = $"{temperature}°C, Temperature Too low!";
                    }
                    else if (temperature > 23)
                    {
                        msg = $"{temperature}°C, Temperature too high!";
                    }

                    NewTemperatureLog(DateTime.Now, msg);
                    timeAlarmOn = DateTime.UtcNow;
                }

                if (timeAlarmOn.AddMinutes(30) <= DateTime.UtcNow)
                {
                    tempAlarm = false;
                }

                //Receive temperature
                if (message.Contains("Temp"))
                {
                    string temp = message.Split('0')[1];
                    temperature = Convert.ToDouble(temp);
                    temp = $"{temperature}°C";
                    lblTemperature.Invoke((Action)(() => lblTemperature.Text = temp));
                }
            }
        }

        private void btnCurrentWeek_Click(object sender, EventArgs e)
        {
            ShowTasks();
            BtnNextWeek.Visible = true;
            btnCurrentWeek.Visible = false;
        }

        private void btnDeleteAnno_Click(object sender, EventArgs e)
        {
            if (dgdAnnouncement.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdAnnouncement.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdAnnouncement.Rows[selectedrowindex];
                int.TryParse(selectedRow.Cells[0].Value.ToString(), out int id);
                studentHousing.DeleteAnnoucement(id);

                FillAnnouncement();
            }
        }
    }
}




