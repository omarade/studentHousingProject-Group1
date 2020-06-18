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
    public partial class FrmTenant : Form
    {
        int mouseY;
        int mouseX;
        bool draggable;

        private StudentHousing studentHousing;

        public FrmTenant()
        {
            InitializeComponent();
            pnlHighlight.Left = btnGereral.Left;
            pnlHighlight.Width = btnGereral.Width;
            pnlComplaints.Visible = false;
            pnlCostControle.Visible = false;
            pnlTasks.Visible = false;
            pnlGereral.Visible = true;
            pnlEvents.Visible = false;
            pnlAgreements.Visible = false;

            pnlGereral.Width = 1155;
            pnlGereral.Height = 422;
            pnlGereral.Top = 162;
            pnlGereral.Left = 0;

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
            lblCurrentUserName.Text = "Tenant Name: " + studentHousing.CurrentUser.Name;
            lblGeneralCurrentTennatID.Text = "Tenant ID:" +(Convert.ToString(studentHousing.CurrentUser.Id));
        }


        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGereral_Click(object sender, EventArgs e)
        {
            pnlHighlight.Left = btnGereral.Left;
            pnlHighlight.Width = btnGereral.Width;
            pnlComplaints.Visible = false;
            pnlCostControle.Visible = false;
            pnlTasks.Visible = false;
            pnlGereral.Visible = true;
            pnlEvents.Visible = false;
            pnlAgreements.Visible = false;

            pnlGereral.Width = 1155;
            pnlGereral.Height = 422;
            pnlGereral.Top = 162;
            pnlGereral.Left = 0;
        }

        private void btnComplaints_Click(object sender, EventArgs e)
        {
            pnlHighlight.Left = btnComplaints.Left;
            pnlHighlight.Width = btnComplaints.Width;
            pnlComplaints.Visible = true;
            pnlCostControle.Visible = false;
            pnlTasks.Visible = false;
            pnlGereral.Visible = false;
            pnlEvents.Visible = false;
            pnlAgreements.Visible = false;

            pnlComplaints.Width = 1155;
            pnlComplaints.Height = 422;
            pnlComplaints.Top = 162;
            pnlComplaints.Left = 0;
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            pnlHighlight.Left = btnTasks.Left;
            pnlHighlight.Width = btnTasks.Width;
            pnlComplaints.Visible = false;
            pnlCostControle.Visible = false;
            pnlTasks.Visible = true;
            pnlGereral.Visible = false;
            pnlEvents.Visible = false;
            pnlAgreements.Visible = false;

            pnlTasks.Width = 1155;
            pnlTasks.Height = 422;
            pnlTasks.Top = 162;
            pnlTasks.Left = 0;
        }

        private void btnCostControle_Click(object sender, EventArgs e)
        {
            pnlHighlight.Left = btnCostControle.Left;
            pnlHighlight.Width = btnCostControle.Width;
            pnlComplaints.Visible = false;
            pnlCostControle.Visible = true;
            pnlTasks.Visible = false;
            pnlGereral.Visible = false;
            pnlEvents.Visible = false;
            pnlAgreements.Visible = false;

            pnlCostControle.Width = 1155;
            pnlCostControle.Height = 422;
            pnlCostControle.Top = 162;
            pnlCostControle.Left = 0;
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            pnlHighlight.Left = btnEvents.Left;
            pnlHighlight.Width = btnEvents.Width;
            pnlComplaints.Visible = false;
            pnlCostControle.Visible = false;
            pnlTasks.Visible = false;
            pnlGereral.Visible = false;
            pnlEvents.Visible = true;
            pnlAgreements.Visible = false;

            pnlEvents.Width = 1155;
            pnlEvents.Height = 422;
            pnlEvents.Top = 162;
            pnlEvents.Left = 0;
        }

        private void btnAgreements_Click(object sender, EventArgs e)
        {
            pnlHighlight.Left = btnAgreements.Left;
            pnlHighlight.Width = btnAgreements.Width;
            pnlComplaints.Visible = false;
            pnlCostControle.Visible = false;
            pnlTasks.Visible = false;
            pnlGereral.Visible = false;
            pnlEvents.Visible = false;
            pnlAgreements.Visible = true;

            pnlAgreements.Width = 1155;
            pnlAgreements.Height = 422;
            pnlAgreements.Top = 162;
            pnlAgreements.Left = 0;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //studentHousing.CurrentUser = null;
            this.Hide();
            var frmLogin = new FrmLogin();
            frmLogin.Show();
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
                dgdEvents.Rows.Add(currentEvent.EventId, currentEvent.EventOwner, currentEvent.EventName, currentEvent.EventDesc, currentEvent.DateOfEvent.ToString("dd/MM/yyyy"), Disagree, Agree);
            }
        }

        private void btnGoToAdmin_Click(object sender, EventArgs e)
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

                double RoundedDevidedPrice = Math.Round(newProduct.DevidedPrice, 1);


                double currentUserShare = (NumberOfParticpants - 1) * newProduct.DevidedPrice;
                // updating balances according the shared prices of each product
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
                    sharedwith += Convert.ToString(tenSharedWith.Name + ", ");
                }

                ListViewItem item1 = new ListViewItem(new[] { newProduct.Name,
                    Convert.ToString(RoundedDevidedPrice), sharedwith });

                lvwProductSharingInfo.Items.Add(item1);

                //updateBalanceView();
                //FrmBalance balanceForm = new FrmBalance();
                //balanceForm.updateBalanceView();
            }
            else
            {
                MessageBox.Show("please enter a suitable input for the full price");
            }
        }

        private void btnMessageDelete_Click(object sender, EventArgs e)
        {
            foreach (Complaint comp in studentHousing.Complaintss)
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

            tbxComSub.Clear();
            tbxCoTopic.Clear();
        }

        private void btnTaskComplete_Click(object sender, EventArgs e)
        {
            //Mark checked Tasks as completed 
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.BytesToRead > 0)
            {
                /*message = serialPort1.ReadLine();

                //Check if time display mode is enabled/disabled
                if (message.Contains("mode0"))
                {
                    timeMode = true;
                }
                else if (message.Contains("mode1") || message.Contains("mode2"))
                {
                    timeMode = false;
                }

                //Receive temperature from bed system
                if (message.Contains("Temp"))
                {
                    string msg = message.Split('0')[1];
                    temperature = Convert.ToDouble(msg);
                    msg = $"{temperature}°C";
                    lblRoomTemp.Invoke((Action)(() => lblRoomTemp.Text = msg));
                }

                //Check if alarm was turned on
                if (message.Contains("alarmOn"))
                {
                    string msg = "Alarm On";
                    TurnAlarmOn();
                    AddNewLogMsg(msg);
                }

                //Check if temperature was too high/low and turn alarm on in that case
                if (message.Contains("tempAlarm"))
                {
                    if (temperature < 16)
                    {
                        string msg = "Temperature below 16°C";
                        TurnAlarmOn();
                        AddNewLogMsg(msg);
                    }
                    else if (temperature > 27)
                    {
                        string msg = "Temperature above 27°C";
                        TurnAlarmOn();
                        AddNewLogMsg(msg);
                    }
                }*/
            }
        }

        private void btnBalances_Click(object sender, EventArgs e)
        {

        }
    }
}
