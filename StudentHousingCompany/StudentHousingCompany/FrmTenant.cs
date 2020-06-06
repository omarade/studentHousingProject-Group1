using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHousingCompany
{
    public partial class FrmTenant : Form
    {
        private StudentHousing studentHousing;
        private Complaint complaint;
        public FrmTenant()
        {

            InitializeComponent();
            studentHousing = StudentHousing.Instance;

            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
            complaint = Complaint.Instance;
            foreach (Tenant tenant in studentHousing.GetTenants())
            {
                clbTenantsToshare.Items.Add(tenant.Name);
            }
           
            ShowTasks();
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

            if(tbxFullPrice.Text == null)
            {
                tbxFullPrice.Text = "0";
                if (tbxProductname.Text == null)
                {
                    tbxProductname.Text = "";
                }
                
            }

            Product newProduct = new Product(tbxProductname.Text, Convert.ToDouble(tbxFullPrice.Text));

            string LogedInUserName = "";
            int LogedInUserID = studentHousing.CurrentUser.Id;
            foreach(Tenant ten in studentHousing.GetTenants())
            {
                if (ten.Id == LogedInUserID)
                {
                    newProduct.TenantesShredWith.Add(ten);
                    LogedInUserName = ten.Name;
                }
            }

            // Collect who is checked in the checkedlistBox
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


            int NumberOfParticpants = newProduct.TenantesShredWith.Count;
            newProduct.DevidedPrice = newProduct.FullPrice / NumberOfParticpants;

            

            foreach(Tenant tenSharedWith in newProduct.TenantesShredWith)
            {
                foreach(Tenant tenant in tenants)
                {
                    if(tenant.Id == tenSharedWith.Id)
                    {
                        if (tenant.Id == LogedInUserID)
                        {
                            tenant.Balance = tenant.Balance  + newProduct.DevidedPrice;
                        }
                        else
                        {
                            tenant.Balance = tenant.Balance - newProduct.DevidedPrice;
                        }
                    }
                }
            }

            this.studentHousing.Products.Add(newProduct);

            string sharedwith = "";

            foreach(Tenant tenSharedWith in newProduct.TenantesShredWith)
            {
                sharedwith += Convert.ToString(tenSharedWith.Id + ", ");
            }


            ListViewItem item1 = new ListViewItem(new[] { newProduct.Name, Convert.ToString(newProduct.DevidedPrice), sharedwith });
            lvwProductSharingInfo.Items.Add(item1);

            FILLBALANCELIST();


        }

        public void FILLBALANCELIST()
        {
            //lvwBlancesOverView.Clear();

            foreach (Tenant tenant in studentHousing.GetTenants())
            {
                ListViewItem item = new ListViewItem(new[] { Convert.ToString(tenant.Id), tenant.Name, Convert.ToString(tenant.Balance) });
                lvwBlancesOverView.Items.Add(item);
            }
        }

        string comSub;
        string comTopic;
        private void btnSendComplaint_Click(object sender, EventArgs e)
        {
            Complaint newcomplaint = new Complaint(tbxComSub.Text, tbxCoTopic.Text, studentHousing.CurrentUser.Id);
            if (cbxSendAnonymously.Checked)
            {
                newcomplaint.Anonymous = false;
            }
            else
            {
                foreach(Tenant ten in studentHousing.GetTenants())
                {
                    if(newcomplaint.TenID == ten.Id)
                    {
                        newcomplaint.TenName = ten.Name;
                    }
                }
            }

            tbxReplyFromAdm.Visible = true;
            tbxReplyFromAdm.Text = "dlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlk" +
                "fndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlk" +
                "fndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfn" +
                "dlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkf" +
                "ndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfn" +
                "dlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkf" +
                "ndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlk" +
                "fndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfn" +
                "dlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndl" +
                "kfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfndlkfn";
            this.studentHousing.Complaintss.Add(newcomplaint);
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
            var schedule = studentHousing.Schedules;

            foreach (var task in schedule)
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

        private void FrmTenant_Load(object sender, EventArgs e)
        {

        }
    }
}
