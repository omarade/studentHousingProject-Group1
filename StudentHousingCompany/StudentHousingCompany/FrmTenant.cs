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
        public FrmTenant()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmAdmin admin = new FrmAdmin();
            admin.Show();
        }
    }
}
