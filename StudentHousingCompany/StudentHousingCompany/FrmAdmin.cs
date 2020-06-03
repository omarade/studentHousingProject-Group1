﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHousingCompany
{
    public partial class FrmAdmin : Form
    {
        private StudentHousing studentHousing;
        public FrmAdmin()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            ShowUsers();
            rbtnTenant.Checked = true;
            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
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
            dgdUsers.ClearSelection();
            txtPassword.Enabled = true;
            txtName.Text = "";
            dtbDoB.Value = DateTime.Now;
            txtEmail.Text = "";
            txtPhoneNr.Text = "";
            txtPostcode.Text = "";
            txtAddress.Text = "";
        }
    }
}
