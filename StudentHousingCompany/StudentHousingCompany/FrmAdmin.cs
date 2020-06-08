using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StudentHousingCompany
{
    public partial class FrmAdmin : Form
    {
        private StudentHousing studentHousing;
        DayOfWeek day = DayOfWeek.Monday;
        private Complaint complaint;
        public FrmAdmin()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            ShowUsers();
            ShowTasks();
            timer1.Enabled = true;
            rbtnTenant.Checked = true;
            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
            cbWeekDays.SelectedIndex = 0;
            complaint = Complaint.Instance;
            
            foreach (Complaint comp in studentHousing.Complaintss)
            {
                 lbxComp.Items.Add(comp.GetText());
            }
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
            //dgdUsers.Rows.Add(name, dateOfBirth, email, password, phoneNr, postcode, address);


            //Resets task with current tenants
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
                    Tenant tenant = (Tenant) user;
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

        private bool ValidateUserInput(string name, DateTime dob, string email)
        {
            TimeSpan ageSpan = DateTime.Now.Subtract(dob);
            int age = ageSpan.Days / 365;

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

            return true;
        }

        private bool ValidateUserInput(string phoneNr, string postcode, string address)
        {


            if (phoneNr.Length <= 10)
            {
                MessageBox.Show("Please enter a valid phone number");
                return false;
            }

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

        private bool ValidateUserInput(string name, DateTime dob, string email, string password, string phoneNr, string postcode, string address)
        {
            bool validInput = ValidateUserInput(name, dob, email, password);

            if (!validInput)
            {
                return false;
            }

            if (phoneNr.Length <= 10)
            {
                MessageBox.Show("Please enter a valid phone number");
                return false;
            }

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmTenant = new FrmTenant();
            frmTenant.Show();
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
            }

            //Resets task with current tenants
            studentHousing.ResetSchedule();
            ShowTasks();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            

            if (dgdUsers.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdUsers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdUsers.Rows[selectedrowindex];
                int.TryParse(selectedRow.Cells["hxtId"].Value.ToString(), out int id);

                User user = studentHousing.GetUserById(id);
                
            
                string name = txtName.Text;
                DateTime dateOfBirth = dtbDoB.Value;
                string email = txtEmail.Text;
                string phoneNr = txtPhoneNr.Text;
                string postcode = txtPostcode.Text;
                string address = txtAddress.Text;

                if (user is Admin && ValidateUserInput(name, dateOfBirth, email))
                {
                    studentHousing.UpdateUser(id, name, dateOfBirth, email,phoneNr, postcode, address);
                }
                if (user is Tenant && ValidateUserInput(name, dateOfBirth, email) && ValidateUserInput(phoneNr, postcode, address))
                {
                    studentHousing.UpdateUser(id, name, dateOfBirth, email, phoneNr, postcode, address);
                }
                
            

                ShowUsers();
            }

        }

        private void dgdUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgdUsers.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdUsers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdUsers.Rows[selectedrowindex];
                int.TryParse(selectedRow.Cells["hxtId"].Value.ToString(), out int id);

                User user = studentHousing.GetUserById(id);
                
                txtPassword.Enabled = false;
                txtName.Text = selectedRow.Cells["hxtName"].Value.ToString();
                dtbDoB.Value = user.DateOfBirth;
                txtEmail.Text = selectedRow.Cells["hxtEmail"].Value.ToString();

                if (user is Tenant)
                {
                    rbtnTenant.Checked = true;
                    txtPhoneNr.Text = selectedRow.Cells["hxtPhoneNr"].Value.ToString();
                    txtPostcode.Text = selectedRow.Cells["hxtPostcode"].Value.ToString();
                    txtAddress.Text = selectedRow.Cells["hxtAddress"].Value.ToString();
                }
                else if (user is Admin)
                {
                    rbtnAdmin.Checked = true;
                }
                
                
            }
        }

        private void tpMngUsrs_Click(object sender, EventArgs e)
        {
            ClearSelectedUser();
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
            studentHousing.SetNextTenant();
            studentHousing.SetNextDueDay();
            ShowTasks();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {//Adds a task with a unique name
            bool NameExsists = false;
            string TaskName = tbTaskName.Text;

            foreach (var task in studentHousing.Schedules)
            {
                if (TaskName == task.GetTask())
                {
                    NameExsists = true;
                }
            }
            
            if (NameExsists == false)
            {
                studentHousing.AddTask(TaskName, day);
            } else
            {
                MessageBox.Show("Task '"+TaskName+"' already exsists");
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
        {//Sets the weekday due day for the new task
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
                cbRemoveTasks.Items.Add(task.GetTask());
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
                if (task.GetStatus() == true)
                {
                    listView6.Items[counter].BackColor = Color.Green;
                }
                counter++;
            }
        }


        private void btnRemoveTask_Click(object sender, EventArgs e)
        {//Removes task selected in the remove task combobox
            studentHousing.RemoveTask(cbRemoveTasks.Text);
            ShowTasks();
            cbRemoveTasks.Text = "";

        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnComplaintResolve_Click(object sender, EventArgs e)
        {

            ListBox.SelectedObjectCollection selectedItem = new ListBox.SelectedObjectCollection(lbxComp);
            selectedItem = lbxComp.SelectedItems;

            if (lbxComp.SelectedIndex != -1)
            {
                string selectedTextFromlbx = Convert.ToString(lbxComp.SelectedItem);

                foreach (Complaint comp in studentHousing.Complaintss)
                {
                    if (selectedTextFromlbx == comp.GetText())
                    {
                        comp.Solved = true;
                    }
                }
                for (int i = selectedItem.Count - 1; i >= 0; i--)
                {
                    lbxComp.Items.Remove(selectedItem[i]);
                } 
            }
            else
            {
                MessageBox.Show("Select a complainet ");
            } 
        }

        int selectedIndxInCompList;
        int idOfSelectedCompFromCompList;

        private void btnReplyToComp_Click(object sender, EventArgs e)
        {

            string selectedTextFromlbx = Convert.ToString(lbxComp.SelectedItem);
            
            foreach (Complaint comp in studentHousing.Complaintss)
            {
                if (selectedTextFromlbx == comp.GetText())
                {
                    selectedIndxInCompList = studentHousing.Complaintss.IndexOf(comp);
                    idOfSelectedCompFromCompList = comp.ComplaintId;
                }
            }

            tbxReply.Visible = true;

        }

        private void btnSendReply_Click(object sender, EventArgs e)
        {
            string reply = tbxReply.Text;

            foreach (Complaint comp in studentHousing.Complaintss)
            {
                
                if(comp.ComplaintId == idOfSelectedCompFromCompList)
                {
                    comp.ReplyFromAdmin =  reply;
                }
            }
            tbxReply.Visible = false;
        }


        
        private void timer1_Tick(object sender, EventArgs e)
        {//Timer to check if when a task should've been completed or when the week has passed

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
                if (task.GetDueDate().Date < DateTime.Now.Date)
                {                    
                    if (task.GetStatus() == false)
                    {
                        listView6.Items[counter].BackColor = Color.Red;
                    }
                    counter++;
                }
            }

            lbxComp.Items.Clear();
            foreach (Complaint comp in studentHousing.Complaintss)
            {
                if (!comp.Solved)
                {
                    lbxComp.Items.Add(comp.GetText());
                }
            }

        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            ClearSelectedUser();
        }

        private void FrmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
