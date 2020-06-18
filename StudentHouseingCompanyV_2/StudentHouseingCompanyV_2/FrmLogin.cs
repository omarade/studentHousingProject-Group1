using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHouseingCompanyV_2
{
    public partial class FrmLogin : Form
    {
        int mouseY;
        int mouseX;
        bool draggable;

        private StudentHousing studentHousing;
        public FrmLogin()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void FrmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
