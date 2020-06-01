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
    public partial class FrmLogin : Form
    {
        private StudentHousing studentHousing;
        public FrmLogin()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            studentHousing.AddDummyData();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User user = studentHousing.ValidateCredentials(email, password, studentHousing.Users);
            Login(user);
        }

        private void Login(User user)
        {
            if (user == null)
            {
                txtEmail.Clear();
                txtPassword.Clear();
                MessageBox.Show("Credentials are wrong");
            } 
            else if (user is Admin)
            {
                this.Hide();
                var frmAdmin = new FrmAdmin();
                frmAdmin.Show();
            }
            else if (user is Tenant)
            {
                this.Hide();
                var frmTenant = new FrmTenant();
                frmTenant.Show();
            }
        }
    }
}
