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
    public partial class FrmBalance : Form
    {
        int mouseY;
        int mouseX;
        bool draggable;

        private StudentHousing studentHousing;
        public FrmTenant tenForm;

        public FrmBalance()
        {
            InitializeComponent();
            studentHousing = StudentHousing.Instance;
            timer1.Start();
            tenForm = new FrmTenant();
        }

        public void updateBalanceView()
        {
            foreach (Tenant tenant in studentHousing.GetTenants())
            {
                if (tenant.PrevBalance != tenant.Balance)
                {
                    lvwBlancesOverView.Items.Clear();
                    foreach (Tenant ten in studentHousing.GetTenants())
                    {
                        double roundedBalance = Math.Round(ten.Balance, 2);
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(ten.Id),
                                                 ten.Name, Convert.ToString(roundedBalance) });
                        lvwBlancesOverView.Items.Add(item);
                    }
                    tenant.PrevBalance = tenant.Balance;
                }
            }
        }

        private void btnExitBalnce_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBalance_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseY = Cursor.Position.Y - this.Top;
            mouseX = Cursor.Position.X - this.Left;
        }

        private void FrmBalance_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                this.Top = Cursor.Position.Y - mouseY;
                this.Left = Cursor.Position.X - mouseX;
            }
        }

        private void FrmBalance_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateBalanceView();
            //foreach (Tenant tenant in studentHousing.GetTenants())
            //{
            //    if (tenant.PrevBalance != tenant.Balance)
            //    {
            //        lvwBlancesOverView.Items.Clear();
            //        foreach (Tenant ten in studentHousing.GetTenants())
            //        {
            //            ListViewItem item = new ListViewItem(new[] { Convert.ToString(ten.Id),
            //                                     ten.Name, Convert.ToString(ten.Balance) });
            //            lvwBlancesOverView.Items.Add(item);
            //        }
            //        tenant.PrevBalance = tenant.Balance;
            //    }
            //}
        }
    }
}
