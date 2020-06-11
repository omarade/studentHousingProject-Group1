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
    
    public partial class FrmAnnoucement : Form
    {
        private StudentHousing studentHousing;
        private FrmAdmin AdminForm;
        public FrmAnnoucement(FrmAdmin adminForm)
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            AdminForm = adminForm;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            studentHousing.CreateAnnouncement(tbSubject.Text, tbText.Text);
            AdminForm.Enabled = true;
            AdminForm.FillAnnouncement();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AdminForm.Enabled = true;
            this.Close();
        }
    }
}
