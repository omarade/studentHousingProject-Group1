using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHousingCompany
{
    class StudentHousing
    {
        //Omarvvvvvv
        private static StudentHousing instance = new StudentHousing();
        List<User> users = new List<User>();
        List<Tenant> tenants = new List<Tenant>();
        //Omar^^^^

        List<Schedule> schedule = new List<Schedule>();
        List<string> tasks = new List<string>();

        //Omarvvvvvv
        public static StudentHousing Instance
        {
            get { return instance; }
        }
        public List<User> Users
        {
            get { return users; }
        }
        public List<Tenant> Tenants
        {
            get { return tenants; }
        }
        private StudentHousing(){}
        public void AddUser(string name, DateTime dob, string email, string password)
        {
            User admin = new Admin(name, dob, email, password);
            users.Add(admin);
        }

        public void AddUser(string name, DateTime dob, string email, string password, string phoneNr, string postcode, string address)
        {
            User tenant = new Tenant(name, dob, email, password, phoneNr, postcode, address);
            users.Add(tenant);

            Tenant newTenant = (Tenant) tenant;
            tenants.Add(newTenant);
        }
        //Omar^^^^


        public void AddTask(string taskName)
        {//TODO Find the right student name to add to the task
            tasks.Add(taskName);
            Schedule newTask = new Schedule(taskName);
            schedule.Add(newTask);
            ResetSchedule();
        }

        public void ResetSchedule()
        {
            int counter = 0;
            foreach (Schedule task in schedule)
            {
                task.SetStudent(tenants[counter].Name);
                counter++;
                if (counter >= tenants.Count)
                {
                    counter = 0;
                }
            }
        }

        /// <summary>
        /// Sets Weekdaydue day
        /// </summary>
        /// <param name="day">Name Of weekday</param>
        public void ChangeDueWeekday(DayOfWeek day)
        {
            foreach (Schedule task in schedule)
            {
                task.SetDueDate(day);
            }
        }

        public ListViewItem ShowAllTaskInfo()
        {
            string[] arr = new string[4];
            ListViewItem itm;
            //add items to ListView
            arr[0] = schedule[tasks.Count - 1].GetStudent();
            arr[1] = schedule[tasks.Count - 1].GetTask();
            arr[2] = schedule[tasks.Count - 1].GetStatus().ToString();
            itm = new ListViewItem(arr);

            return itm;
        }



    }
}
