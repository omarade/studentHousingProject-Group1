using System;
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
    public partial class FrmUdateUserInfo : Form
    {
        private StudentHousing studentHousing;
        private User userToUpdate;
        private FrmAdmin frmAdmin;
        public FrmUdateUserInfo(int id, FrmAdmin frmAdmin)
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            userToUpdate = studentHousing.GetUserById(id);
            lblID.Text = userToUpdate.Id.ToString();
            lblName.Text = userToUpdate.Name;
            this.frmAdmin = frmAdmin;
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

        private void FrmUdateUserInfo_Load(object sender, EventArgs e)
        {
            if (userToUpdate is Tenant)
            {
                Tenant tenantToUpdate = (Tenant) userToUpdate;
                lblUserType.Text = "Tenant";
                txtName.Text = tenantToUpdate.Name;
                dtbDoB.Value = tenantToUpdate.DateOfBirth;
                txtEmail.Text = tenantToUpdate.Email;
                txtPhoneNr.Text = tenantToUpdate.PhoneNr;
                txtPostcode.Text = tenantToUpdate.Postcode;
                txtAddress.Text = tenantToUpdate.Address;
            }
            else
            {
                lblUserType.Text = "Admin";
                txtName.Text = userToUpdate.Name;
                dtbDoB.Value = userToUpdate.DateOfBirth;
                txtEmail.Text = userToUpdate.Email;
                txtPhoneNr.Enabled = false;
                txtPostcode.Enabled = false;
                txtAddress.Enabled = false;
            }
        }

        private void btnConfirmUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            DateTime dateOfBirth = dtbDoB.Value;
            string email = txtEmail.Text;
            string phoneNr = txtPhoneNr.Text;
            string postcode = txtPostcode.Text;
            string address = txtAddress.Text;

            if (userToUpdate is Admin && ValidateUserInput(name, dateOfBirth, email))
            {
                studentHousing.UpdateUser(userToUpdate.Id, name, dateOfBirth, email, phoneNr, postcode, address);
                frmAdmin.Enabled = true;
                this.Close();
            }
            if (userToUpdate is Tenant && ValidateUserInput(name, dateOfBirth, email) && ValidateUserInput(phoneNr, postcode, address))
            {
                studentHousing.UpdateUser(userToUpdate.Id, name, dateOfBirth, email, phoneNr, postcode, address);
                this.Hide();
                frmAdmin.Enabled = true;
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            frmAdmin.Enabled = true;
            this.Close();
        }
    }
}
