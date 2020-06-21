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
    public partial class FrmAddEvent : Form
    {
        int mouseY;
        int mouseX;
        bool draggable;

        private StudentHousing studentHousing;
        private FrmTenant TenantsForm;
        public FrmAddEvent(FrmTenant tenantsForm)
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            TenantsForm = tenantsForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TenantsForm.Enabled = true;
            this.Close();
        }

        private void FrmAddEvent_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void FrmAddEvent_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void FrmAddEvent_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void btnEventConfirm_Click(object sender, EventArgs e)
        {
            string EventName = tbEventName.Text;
            string EventDesc = tbEventDesc.Text;
            DateTime date = dtEvent.Value;
            studentHousing.AddEvent(EventName, date, EventDesc, studentHousing.CurrentUser.Name);
            TenantsForm.Enabled = true;
            TenantsForm.FillEventsList();
            this.Close();
        }
    }
}
