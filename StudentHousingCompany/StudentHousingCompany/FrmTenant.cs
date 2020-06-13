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
        
        public FrmTenant()
        {

            InitializeComponent();
            studentHousing = StudentHousing.Instance;

            ShowAgreements();

            
            foreach (Tenant tenant in studentHousing.GetTenants())
            {
                if (tenant.Id != studentHousing.CurrentUser.Id)
                {
                    clbTenantsToshare.Items.Add(tenant.Name);
                }
                
            }
            timer1.Start();
            ShowTasks();
            FillEventsList();
            rtbHouseRules.Text = studentHousing.HouseRules;
            FillAnnouncement();
            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
            tbxGeneralCurrentTennatID.Text = (Convert.ToString(studentHousing.CurrentUser.Id));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmAdmin = new FrmAdmin();
            frmAdmin.Show();
        }

        private void btnAddToShoppingList_Click(object sender, EventArgs e)
        {
            List<Tenant> tenants = studentHousing.GetTenants();

            if (tbxFullPrice.Text == null)
            {
                tbxFullPrice.Text = "0";
            }
            if (tbxProductname.Text == null)
            {
                tbxProductname.Text = "";
            }


            
            if (double.TryParse(tbxFullPrice.Text, out double fullprice)) 
            {
                Product newProduct = new Product(tbxProductname.Text, fullprice);
                string LogedInUserName = null;

                // adding the current user to the sharing list
                foreach (Tenant ten in studentHousing.GetTenants())
                {
                    if (ten.Id == studentHousing.CurrentUser.Id)
                    {
                        newProduct.TenantesShredWith.Add(ten);
                        LogedInUserName = ten.Name;
                    }
                }

                // Collect who is checked in the checkedlistBox
                foreach (string tenantName in clbTenantsToshare.CheckedItems)
                {
                    foreach (Tenant ten in tenants)
                    {
                        if (ten.Name == tenantName)
                        {
                            newProduct.TenantesShredWith.Add(ten);
                        }
                    }
                }

                int NumberOfParticpants = newProduct.TenantesShredWith.Count;
                newProduct.DevidedPrice = newProduct.FullPrice / NumberOfParticpants;
                double currentUserShare = (NumberOfParticpants - 1) * newProduct.DevidedPrice;

                foreach (Tenant tenSharedWith in newProduct.TenantesShredWith)
                {
                    foreach (Tenant tenant in tenants)
                    {
                        if (tenant.Id == tenSharedWith.Id)
                        {
                            if (tenant.Id == studentHousing.CurrentUser.Id)
                            {
                                tenant.Balance = tenant.Balance + currentUserShare;
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

                foreach (Tenant tenSharedWith in newProduct.TenantesShredWith)
                {
                    sharedwith += Convert.ToString(tenSharedWith.Id + ", ");
                }


                ListViewItem item1 = new ListViewItem(new[] { newProduct.Name, Convert.ToString(newProduct.DevidedPrice), sharedwith });
                lvwProductSharingInfo.Items.Add(item1);

                lvwBlancesOverView.Items.Clear();

                foreach (Tenant tenant in studentHousing.GetTenants())
                {
                    ListViewItem item = new ListViewItem(new[] { Convert.ToString(tenant.Id), tenant.Name, Convert.ToString(tenant.Balance) });
                    lvwBlancesOverView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("please enter a suitable input for the full price");
            }


            

            


        }        
        private void btnSendComplaint_Click(object sender, EventArgs e)
        {
            Complaint newcomplaint = new Complaint(tbxComSub.Text, tbxCoTopic.Text);
            if (cbxSendAnonymously.Checked)
            {
                newcomplaint.Anonymous = true;
            }
            else
            {
                newcomplaint.Anonymous = false;
            }

            foreach (Tenant ten in studentHousing.GetTenants())
            {
                if (ten.Id == studentHousing.CurrentUser.Id)
                {
                    ten.Complaints.Add(newcomplaint);
                }
            }

            this.studentHousing.Complaintss.Add(newcomplaint);
            tbxCoTopic.Clear();
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
                if (task.Status == true)
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
                if (task.Student == studentHousing.CurrentUser.Name)
                {
                    clbTenantTask.Items.Add(task.TaskName);
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
            
            this.Enabled = false;
            var frmAddEvent = new FrmAddEvent(this);
            frmAddEvent.Show();

            FillEventsList();
        }

        public void FillEventsList()
        {
            dgdEvents.Rows.Clear();

            foreach (var currentEvent in studentHousing.Events)
            {
                string Disagree = currentEvent.NegativeResponses.Count().ToString() + "/" + studentHousing.GetTenants().Count().ToString();
                string Agree = currentEvent.PositiveResponses.Count().ToString() + "/" + studentHousing.GetTenants().Count().ToString();
                dgdEvents.Rows.Add(currentEvent.EventId, currentEvent.EventOwner, currentEvent.EventName, currentEvent.EventDesc, currentEvent.DateOfEvent.ToString("dd/MM/yyyy"),Disagree,Agree);
            }
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            if (dgdEvents.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdEvents.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdEvents.Rows[selectedrowindex];
                string eventID = Convert.ToString(selectedRow.Cells["dgcEventID"].Value);

                studentHousing.AgreeToEvent(eventID);
                FillEventsList();
            }
        }

        private void btnDisagree_Click(object sender, EventArgs e)
        {
            if (dgdEvents.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgdEvents.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgdEvents.Rows[selectedrowindex];
                string eventID = Convert.ToString(selectedRow.Cells["dgcEventID"].Value);

                studentHousing.DisagreeToEvent(eventID);
                FillEventsList();
            }
        }

        private void btnMessageDelete_Click(object sender, EventArgs e)
        {
            foreach(Complaint comp in studentHousing.Complaintss)
            {
                if (tbxReplyFromAdm.Text == comp.ReplyFromAdmin)
                {
                    comp.ReplyFromAdmIsRead = true;
                    tbxReplyFromAdm.Clear();
                    tbxReplyFromAdm.Visible = false;
                }
            }

            btnMessageDelete.Visible = false;
            lblMessageFromAdm.Visible = false;
            lblComplaintDiscription.Visible = true;
        }

        private void btnNewAgreement_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var frmNewAgreement = new FrmNewAgreement(this);
            frmNewAgreement.Show();
        }

        private void ShowAgreements()
        {
            dgdAgreements.Rows.Clear();

            List<Agreement> agreements = studentHousing.Agreements;
            string withTenants = "";
            bool isCreator;
            bool isAgreementMember = false;

            foreach (var agreement in agreements)
            {
                isCreator = studentHousing.CurrentUser.Id == agreement.CreatorTenant.Id;
                
                foreach (var tenant in agreement.WithTenants)
                {
                    if (studentHousing.CurrentUser.Id == tenant.Id)
                    {
                        isAgreementMember = true;
                    }
                    withTenants += $"{tenant.Name}, ";
                }

                if (isCreator || isAgreementMember)
                {
                    dgdAgreements.Rows.Add(agreement.Title, agreement.Description, agreement.CreatorTenant.Name, withTenants, agreement.Date.ToString("dd/MM/yyyy"));
                }
            }
        }

        private void FrmTenant_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //studentHousing.CurrentUser = null;
            this.Hide();
            var frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (studentHousing.CurrentUser != null)
            {
                foreach (Tenant ten in studentHousing.GetTenants())
                {
                    if (ten.Id == studentHousing.CurrentUser.Id)
                    {
                        if (ten.Complaints != null)
                        {
                            foreach (Complaint comp in ten.Complaints)
                            {
                                if (comp.ReplyFromAdmin != null)
                                {
                                    if (!comp.ReplyFromAdmIsRead)
                                    {
                                        this.tbxReplyFromAdm.Text = comp.ReplyFromAdmin;
                                        this.tbxReplyFromAdm.Visible = true;
                                        this.btnMessageDelete.Visible = true;
                                        this.lblMessageFromAdm.Visible = true;
                                        this.lblComplaintDiscription.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        

        public void FillAnnouncement()
        {
            dgdAnnouncement.Rows.Clear();

            foreach (var currentAnno in studentHousing.Announcements)
            {
                dgdAnnouncement.Rows.Add(currentAnno.AnnouncementId, currentAnno.AnnouncementSubject, currentAnno.AnnouncementText);
            }
        }

        private void FrmTenant_EnabledChanged(object sender, EventArgs e)
        {
            ShowAgreements();
        }
    }
}
