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
    public partial class FrmNewAgreement : Form
    {
        int mouseY;
        int mouseX;
        bool draggable;

        private StudentHousing studentHousing;
        private FrmTenant frmTenant;

        public FrmNewAgreement(FrmTenant frmTenant)
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            ShowTenants();
            this.frmTenant = frmTenant;

        }

        public void ShowTenants()
        {
            List<Tenant> tenants = studentHousing.GetTenants();
            foreach (var tenant in tenants)
            {
                if (tenant.Id != studentHousing.CurrentUser.Id)
                {
                    ListViewItem item = new ListViewItem(new[] { tenant.Id.ToString(), tenant.Name, tenant.Address });
                    lvwTenants.Items.Add(item);
                }
            }
        }

        private void FrmNewAgreement_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void FrmNewAgreement_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void FrmNewAgreement_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmTenant.Enabled = true;
            this.Close();
        }

        private void btnCreateAgreement_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            Tenant currentTenant = (Tenant)studentHousing.CurrentUser;
            List<Tenant> withTenants = new List<Tenant>();

            List<Tenant> tenants = studentHousing.GetTenants();
            ListView.CheckedListViewItemCollection checkedTenants = lvwTenants.CheckedItems;


            foreach (ListViewItem checkedTenant in checkedTenants)
            {
                Console.WriteLine(checkedTenant.Text);
                int.TryParse(checkedTenant.Text, out int id);

                foreach (var tenant in tenants)
                {
                    if (tenant.Id == id)
                    {
                        withTenants.Add(tenant);
                    }
                }
            }
            studentHousing.CreateNewAgreement(title, description, currentTenant, withTenants);

            frmTenant.Enabled = true;
            this.Close();
        }
    }
}
