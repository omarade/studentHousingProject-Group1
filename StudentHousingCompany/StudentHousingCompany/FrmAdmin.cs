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
    public partial class FrmAdmin : Form
    {

        StudentHousing studentHousing = new StudentHousing();
        public FrmAdmin()
        {
            InitializeComponent();
            studentHousing.AddTestData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentHousing.ChangeDueWeekday(DayOfWeek.Friday);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            studentHousing.AddTask(textBox9.Text);
            listView6.Items.Add(studentHousing.ShowAllTaskInfo());

        }
    }
}
