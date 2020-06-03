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

            lblCurrentUserName.Text = studentHousing.CurrentUser.Name;
            label4.Text = studentHousing.GetTenantTask();

            ShowTasks();

            foreach (Tenant tenant in studentHousing.Tenants)
            {
                clbTenantsToshare.Items.Add(tenant.Name);
            }
            
        }

        public void ShowTasks()
        {
            listView6.Items.Clear();
            var schedule = studentHousing.Schedules;

            foreach (var task in schedule)
            {
                listView6.Items.Add(task.GetInfo());
            }

            if (studentHousing.GetTenantTask() == "No Task")
            { button2.Enabled = false; }
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
        //string phrase = "The quick brown fox jumps over the lazy dog.";
        //string[] words = phrase.Split(' ');
        private void btnAddToShoppingList_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product(tbxProductname.Text, Convert.ToDouble(tbxFullPrice.Text), 1);


            var Tenants = studentHousing.Tenants;

            foreach(string info in clbTenantsToshare.CheckedItems)
            {

              foreach(Tenant ten in Tenants)
              {
                    if (ten.Name == info)
                    {

                    }
              }

            }

            int NumberOfParticpants = newProduct.TenantesShredWith.Count;
            newProduct.DevidedPrice = newProduct.FullPrice / NumberOfParticpants;

            int currentuserID = studentHousing.CurrentUser.Id;

            foreach(Tenant t in newProduct.TenantesShredWith)
            {
                if(t.Id == currentuserID)
                {
                    t.Balance += newProduct.DevidedPrice;
                }
                else
                {
                    t.Balance -= newProduct.DevidedPrice;
                }
            }

            this.studentHousing.Products.Add(newProduct);

            string sharedwithh = "";
            foreach(Tenant t in newProduct.TenantesShredWith)
            {
                sharedwithh += Convert.ToString(t.Id)+", ";
            }



            foreach(Product p in studentHousing.Products)
            {
                lvwProductSharingInfo.Items.Add(p.Name, Convert.ToString(p.DevidedPrice), sharedwithh);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowTasks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentHousing.CompleteTask();
            ShowTasks();
        }
    }
}
