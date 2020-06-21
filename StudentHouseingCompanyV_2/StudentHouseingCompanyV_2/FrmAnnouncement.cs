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
    public partial class FrmAnnouncement : Form
    {

        int mouseY;
        int mouseX;
        bool draggable;

        private StudentHousing studentHousing;
        private FrmAdmin AdminForm;

        public FrmAnnouncement(FrmAdmin adminForm)
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            AdminForm = adminForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AdminForm.Enabled = true;
            this.Close();
        }

        private void FrmAnnouncement_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void FrmAnnouncement_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void FrmAnnouncement_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            studentHousing.CreateAnnouncement(tbSubject.Text, tbText.Text);
            AdminForm.Enabled = true;
            AdminForm.FillAnnouncement();
            this.Close();
        }
    }
}
