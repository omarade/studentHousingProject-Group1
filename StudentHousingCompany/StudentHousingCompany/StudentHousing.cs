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

        public static StudentHousing Instance { get { return instance; } }

        public User CurrentUser { get; set; }

        public List<Schedule> Schedules { get; }

        public List<User> Users { get; }

        public List<Agreement> Agreements { get; }

        // list of all the products 
        public List<Product> Products { get; set; }

        private StudentHousing()
        {

            Users = new List<User>();
            Products = new List<Product>();
            Schedules = new List<Schedule>();
            Agreements = new List<Agreement>();

        }

        public User GetUserById(int id)
        {
            foreach (var user in Users)
            {
                if (id == user.Id)
                {
                    return user;
                }
            }

            return null;
        }

        public List<Tenant> GetTenants()
        {
            List<Tenant> tenants = new List<Tenant>();
            foreach (var user in Users)
            {
                if (user is Tenant)
                {
                    Tenant tenant = (Tenant)user;
                    tenants.Add(tenant);
                }
            }

            return tenants;
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
        }

        public void UpdateUser(int id, string name, DateTime dob, string email, string phoneNr, string postcode, string address)
        {
            foreach (var user in Users)
            {

                if (id == user.Id)
                {
                    if (user.Id == 0)
                    {
                        MessageBox.Show("You cannot update this user");
                        return;
                    }

                    user.Name = name;
                    user.DateOfBirth = dob;
                    user.Email = email;

                    if (user is Tenant)
                    {
                        Tenant tenant = (Tenant) user;
                        tenant.PhoneNr = phoneNr;
                        tenant.Postcode = postcode;
                        tenant.Address = address;
                    }

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

            dob = new DateTime(1985, 03, 05);
            AddUser("Bill burr", dob, "bill@live.com", "1234");

            dob = new DateTime(1999, 03, 15);
            AddUser("Rob bill", dob, "rob@live.com", "1234", "0031683443453", "3456LA", "Aakstraat 140");

            dob = new DateTime(1994, 03, 15);
            AddUser("Kevin Hart", dob, "kev@live.com", "1234", "0031638746587", "3456LA", "Aakstraat 141");

            dob = new DateTime(1993, 03, 15);
            AddUser("George Carlin", dob, "George@live.com", "1234", "0031683746583", "3456LA", "Aakstraat 142");

            dob = new DateTime(1992, 03, 15);
            AddUser("Jerry Seinfeld", dob, "Jerry@live.com", "1234", "0031614780292", "3456LA", "Aakstraat 143");

            dob = new DateTime(2001, 03, 15);
            AddUser("Chris Rock", dob, "Chris@live.com", "1234", "0031682994347", "3456LA", "Aakstraat 144");

            AddTask("Bathroom", DayOfWeek.Friday);
            AddTask("LivingRoom", DayOfWeek.Friday);
            AddTask("Kitchen", DayOfWeek.Friday);
            AddTask("General House Items", DayOfWeek.Friday);
            AddTask("Task1", DayOfWeek.Friday);
            AddTask("Task2", DayOfWeek.Friday);
            AddTask("Task3", DayOfWeek.Friday);
            AddTask("Task4", DayOfWeek.Friday);
            AddTask("Task5", DayOfWeek.Thursday);

        }

        /// <summary>
        /// Creates a new task
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        /// <param name="day">Weekday name</param>
        public void AddTask(string taskName, DayOfWeek day)
        {
            Schedule newTask = new Schedule(taskName, day);
            Schedules.Add(newTask);
            ResetSchedule();
        }

        /// <summary>
        /// ReOrders the tasks between tenants
        /// </summary>
        public void ResetSchedule()
        {
            List<Tenant> tenants = GetTenants();
            int counter = 0;
            foreach (Schedule task in Schedules)
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
        /// Finds if the loged in user has a task
        /// </summary>
        /// <returns></returns>
        public string GetTenantTask()
        {
            string taskname = "No Task";

            foreach (var task in Schedules)
            {
                if (task.GetStudent() == CurrentUser.Name)
                {
                    taskname = task.GetTask();
                }
            }
            return taskname;
        }

        /// <summary>
        /// Marks a task as completed
        /// </summary>
        /// <param name="taskName">Name of task that need to be completed</param>
        public void CompleteTask(string taskName)
        {
            foreach (var task in Schedules)
            {
                if (task.GetTask() == taskName)
                {
                    task.SetStatus(true);
                }
            }
        }

        /// <summary>
        /// Sets the next tenant to do the task
        /// </summary>
        public void SetNextTenant()
        {
            List<Tenant> tenants = GetTenants();
            foreach (var task in Schedules)
            {
                task.SetNextStudent(tenants);
            }
            SetNextDueDay();
        }

        /// <summary>
        /// Changes a due date to the next week
        /// </summary>
        public void SetNextDueDay()
        {
            foreach (var task in Schedules)
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
            foreach (Schedule task in Schedules)
            {
                task.SetDueDate(day);
            }
        }

        /// <summary>
        /// Removes selected task from the list
        /// </summary>
        /// <param name="taskName">Name of task</param>
        public void RemoveTask(string taskName)
        {
            for (int i = 0; i < Schedules.Count; i++)
            {
                if (Schedules[i].GetTask() == taskName)
                {
                    Schedules.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Finds if the end of the week has been reached
        /// </summary>
        /// <returns></returns>
        public bool IsEndOfWeek()
        {
            DayOfWeek day = DayOfWeek.Sunday;
            DayOfWeek today = DateTime.Now.DayOfWeek;
            if (day == today)
            {
                return true;
            }
            else { return false; }

        }

        public void CreateNewAgreement(string title, string description, Tenant currentTenant, List<Tenant> withTenants)
        {
            Agreement agreement = new Agreement(title, description, currentTenant, withTenants);
            Agreements.Add(agreement);
        }
    }
}
