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
    public partial class FrmTenant : Form
    {
        private StudentHousing studentHousing;
        
        public FrmTenant()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;

            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmAdmin = new FrmAdmin();
            frmAdmin.Show();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(studentHousing.Users.Count.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var users = studentHousing.Tenants;
            foreach (var user in users)
            {
                int id = user.Id;
            }
        }
    }
}
