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
    public partial class FrmNewAgreement : Form
    {
        private StudentHousing studentHousing;

        public FrmNewAgreement()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            ShowTenants();


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

        private void btnAddUser_Click(object sender, EventArgs e)
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
            studentHousing.CreateNewAgreement(title,description, currentTenant, withTenants);
            this.Close();
            var frmTenant = new FrmTenant();
            frmTenant.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var frmTenant = new FrmTenant();
            frmTenant.Show();
        }
    }
}
