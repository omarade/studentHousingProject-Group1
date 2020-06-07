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
    public partial class FrmAddEvent : Form
    {
        private StudentHousing studentHousing;
        public FrmAddEvent()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string EventName = tbEventName.Text;
            string EventDesc = tbEventDesc.Text;
            DateTime date = dtEvent.Value;
            studentHousing.AddEvent(EventName, date, EventDesc, studentHousing.CurrentUser.Name);
            this.Close();
            var frmTenant = new FrmTenant();
            frmTenant.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            var frmTenant = new FrmTenant();
            frmTenant.Show();
        }
    }
}
