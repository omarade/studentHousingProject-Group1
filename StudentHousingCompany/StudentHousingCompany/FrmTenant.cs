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

            ShowAgreements();

            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;

            foreach(Tenant tenant in studentHousing.GetTenants())
            {
                clbTenantsToshare.Items.Add(tenant.Name);
            }

            //studentHousing.ProductId = 0;

            foreach (Tenant t in studentHousing.GetTenants())
            {
                dgdBlancesOverView.Rows.Add(t.Id, t.Name, t.Balance);
            }

            ShowTasks();
            FillEventsList();

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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddToShoppingList_Click(object sender, EventArgs e)
        {
            List<Tenant> tenants = studentHousing.GetTenants();

            if (tbxFullPrice.Text == null)
            {
                if (tbxProductname.Text == null)
                {
                    tbxProductname.Text = "";
                }
                tbxFullPrice.Text = "0";
            }

            //TODO NOUR
            Product newProduct = new Product(tbxProductname.Text, Convert.ToDouble(tbxFullPrice.Text), 1/*studentHousing.ProductId*/);

            //studentHousing.ProductId += 1;

            foreach (string tenantName in clbTenantsToshare.CheckedItems)
            {
              foreach(Tenant ten in tenants)
              {
                 if (ten.Name == tenantName)
                 {
                    newProduct.TenantesShredWith.Add(ten);
                 }
              }
            }

            int NumberOfParticpants = newProduct.TenantesIDShredWith.Count;
            newProduct.DevidedPrice = newProduct.FullPrice / NumberOfParticpants;

            int currentuserID = studentHousing.CurrentUser.Id;

            foreach (Tenant tenant1 in newProduct.TenantesShredWith)
            {
                foreach(Tenant tenant in tenants)
                {
                    if (tenant.Id == tenant1.Id)
                    {
                        if (tenant.Id == currentuserID)
                        {
                            tenant.Balance += newProduct.DevidedPrice;
                        }
                        else
                        {
                            tenant.Balance -= newProduct.DevidedPrice;
                        }
                    }
                }
            }

            this.studentHousing.Products.Add(newProduct);

            string sharedwith = "";

            foreach (Tenant t in newProduct.TenantesShredWith)
            {
                sharedwith += Convert.ToString(t.Id + ", ");
            }

            dgdProductSharingInfo.Rows.Add(newProduct.Name, Convert.ToString(newProduct.DevidedPrice), sharedwith);

            dgdBlancesOverView.Rows.Clear();

            foreach(Tenant t in tenants)
            {
                dgdBlancesOverView.Rows.Add(Convert.ToString(t.Id), t.Name, Convert.ToString(t.Balance));
            }
            
        }

        private void btnSendComplaint_Click(object sender, EventArgs e)
        {

        }



        private void btnTaskComplete_Click(object sender, EventArgs e)
        {//Mark checked Tasks as completed 
            foreach (string taskName in clbTenantTask.CheckedItems)
            {
                foreach (var task in studentHousing.Schedules)
                {
                    studentHousing.CompleteTask(taskName);
                }
            }
            ShowTasks();
        }

        /// <summary>
        /// This Function finds the competed taks and highlights them
        /// </summary>
        public void CheckTaskStatus()
        {
            int counter = 0;

            foreach (var task in studentHousing.Schedules)
            {
                if (task.GetStatus() == true)
                {
                    listView6.Items[counter].BackColor = Color.Green;
                }
                counter++;
            }
        }


        /// <summary>
        /// This function finds the tasks for the logedin User.
        /// </summary>
        public void ShowTasks()
        {
            clbTenantTask.Items.Clear();
            listView6.Items.Clear();

            foreach (var task in studentHousing.Schedules)
            {
                listView6.Items.Add(task.GetInfo());
                if (task.GetStudent() == studentHousing.CurrentUser.Name)
                {
                    clbTenantTask.Items.Add(task.GetTask());
                }
            }

            if (studentHousing.GetTenantTask() == "No Task")
            {
                btnTaskComplete.Enabled = false;
            }

            CheckTaskStatus();

        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            var frmAddEvent = new FrmAddEvent();
            frmAddEvent.Show();

            FillEventsList();
        }

        public void FillEventsList()
        {
            lvEventDetails.Items.Clear();

            foreach (var events in studentHousing.Events)
            {
                ListViewItem eventInfo = events.GetInfo();
                eventInfo.SubItems.Add(events.NegativeResponses.Count().ToString()+"/"+studentHousing.GetTenants().Count().ToString());
                eventInfo.SubItems.Add(events.PositiveResponses.Count().ToString() + "/" + studentHousing.GetTenants().Count().ToString());
                lvEventDetails.Items.Add(eventInfo);
            }
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            if (lvEventDetails.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem item = lvEventDetails.SelectedItems[0];

            studentHousing.AgreeToEvent(item.Text);
            FillEventsList();
        }

        private void btnDisagree_Click(object sender, EventArgs e)
        {
            if (lvEventDetails.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem item = lvEventDetails.SelectedItems[0];

            studentHousing.DisagreeToEvent(item.Text);
            FillEventsList();
        }

        private void btnNewAgreement_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmNewAgreement = new FrmNewAgreement();
            frmNewAgreement.Show();
        }

        private void ShowAgreements()
        {
            List<Agreement> agreements = studentHousing.Agreements;
            string withTenants = "";

            foreach (var agreement in agreements)
            {
                foreach (var tenant in agreement.WithTenants)
                {
                    withTenants += $"{tenant.Name}, ";
                }
                dgdAgreements.Rows.Add(agreement.Title, agreement.Description, agreement.CreatorTenant.Name, withTenants, agreement.Date.ToString("dd/MM/yyyy"));
            }
        }

        private void FrmTenant_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
