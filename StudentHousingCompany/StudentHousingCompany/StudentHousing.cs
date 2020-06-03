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
        private static StudentHousing instance = new StudentHousing();

        List<Schedule> schedule = new List<Schedule>();
        List<string> tasks = new List<string>();

        public List<Schedule> Schedules
        {
            get { return schedule; }
        }

        public static StudentHousing Instance
        {
            get { return instance; }
        }

        public List<User> Users
        {
            get;
        }

        public List<Tenant> Tenants
        {
            get;
        }

        public User CurrentUser
        {
            get;
            set;
        }

        // list of all the products 
        public List<Product> Products
        {
            get;
            set;
        }

        private StudentHousing()
        {

            Users = new List<User>();
            Tenants = new List<Tenant>();
            Products = new List<Product>();
        }

        public User ValidateCredentials(string email, string password, List<User> users)
        {
            foreach (var user in users)
            {
                if (email == user.Email && password == user.Password)
                {
                    CurrentUser = user;
                    return user;
                }
            }

            return null;
        }

        public void AddUser(string name, DateTime dob, string email, string password)
        {
            User admin = new Admin(name, dob, email, password);
            Users.Add(admin);
        }

        public void AddUser(string name, DateTime dob, string email, string password, string phoneNr, string postcode, string address)
        {
            User tenant = new Tenant(name, dob, email, password, phoneNr, postcode, address);
            Users.Add(tenant);

            Tenant newTenant = (Tenant) tenant;
            Tenants.Add(newTenant);
        }

        public void UpdateUser(int id)
        {
            foreach (var user in Users)
            {

                if (id == user.Id)
                {
                    if (user.Id == 0 || user.Id == CurrentUser.Id)
                    {
                        MessageBox.Show("Selected user cannot be deleted");
                        return;
                    }
                    Users.Remove(user);
                    return;
                }
            }
        }

        public void RemoveUser(int id)
        {
            foreach (var user in Users)
            {
                
                if (id == user.Id)
                {
                    if (user.Id == 0 || user.Id == CurrentUser.Id)
                    {
                        MessageBox.Show("Selected user cannot be deleted");
                        return;
                    }
                    Users.Remove(user);
                    return;
                }
            }
        }

        public void AddDummyData()
        {
            DateTime dob = new DateTime(1987, 03, 06);
            AddUser("Admin", dob, "admin", "1234");

            dob = new DateTime(1990, 03, 05);
            AddUser("Omar Dehn", dob, "omar@live.com", "1234");

            dob = new DateTime(1985, 03, 05);
            AddUser("Bill burr", dob, "bill@live.com", "1234");

            dob = new DateTime(1999, 03, 15);
            AddUser("Rob bill", dob, " ", "1234", "0031683443453", "3456LA", "Aakstraat 140");

            dob = new DateTime(1994, 03, 15);
            AddUser("Kevin Hart", dob, "kev@live.com", "1234", "0031638746587", "3456LA", "Aakstraat 141");

            dob = new DateTime(1993, 03, 15);
            AddUser("George Carlin", dob, "George@live.com", "1234", "0031683746583", "3456LA", "Aakstraat 142");

            dob = new DateTime(1992, 03, 15);
            AddUser("Jerry Seinfeld", dob, "Jerry@live.com", "1234", "0031614780292", "3456LA", "Aakstraat 143");

            dob = new DateTime(2001, 03, 15);
            AddUser("Chris Rock", dob, "Chris@live.com", "1234", "0031682994347", "3456LA", "Aakstraat 144");
        }

        // list of all the products that will be shared



        public void AddTask(string taskName, DayOfWeek day)
        {//TODO Find the right student name to add to the task
            tasks.Add(taskName);
            Schedule newTask = new Schedule(taskName, day);
            schedule.Add(newTask);
            ResetSchedule();
        }

        public void ResetSchedule()
        {
            int counter = 0;
            foreach (Schedule task in schedule)
            {
                task.SetStudent(Tenants[counter].Name);
                counter++;
                if (counter >= Tenants.Count)
                {
                    counter = 0;
                }
            }
        }

        public string GetTenantTask()
        {
            string taskname = "No Task";

            foreach (var task in schedule)
            {
                if (task.GetStudent() == CurrentUser.Name)
                {
                    taskname = task.GetTask();
                }
            }
            return taskname;
        }

        public void CompleteTask()
        {
            foreach (var task in schedule)
            {
                if (task.GetStudent() == CurrentUser.Name)
                {
                    task.SetStatus(true);
                }
            }
        }

        public void SetNextTenant()
        {
            foreach (var task in schedule)
            {
                task.SetNextStudent(Tenants);
            }
        }

        public void SetNextDueDay()
        {
            foreach (var task in schedule)
            {
                task.NextDueDate();
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
            arr[3] = schedule[tasks.Count - 1].GetDueDate().ToString();
            itm = new ListViewItem(arr);

            return itm;
        }

    }
}
