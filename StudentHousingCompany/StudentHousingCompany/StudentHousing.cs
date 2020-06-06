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

        public static StudentHousing Instance
        {
            get { return instance; }
        }

        public List<Schedule> Schedules { get; }

        public List<string> Tasks { get; }

        public List<User> Users { get; }

        public List<Tenant> Tenants { get; }

        public User CurrentUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Complaint> Complaintss { get; set; }

        private StudentHousing()
        {
            Users = new List<User>();
            Tenants = new List<Tenant>();
            Products = new List<Product>();
            Schedules = new List<Schedule>();
            Tasks = new List<string>();
            Complaintss = new List<Complaint>();
            testdataToComplaints();
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

        public void AddUser(string name, DateTime dob, string email, string password, string phoneNr, string postcode,
            string address)
        {
            User tenant = new Tenant(name, dob, email, password, phoneNr, postcode, address);
            Users.Add(tenant);

            Tenant newTenant = (Tenant) tenant;
            Tenants.Add(newTenant);
        }

        public void UpdateUser(int id, string name, DateTime dob, string email, string phoneNr, string postcode,
            string address)
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

        public void AddTask(string taskName, DayOfWeek day)
        {//TODO Find the right student name to add to the task
            Tasks.Add(taskName);
            Schedule newTask = new Schedule(taskName, day);
            Schedules.Add(newTask);
            ResetSchedule();
        }

        public void ResetSchedule()
        {
            int counter = 0;
            foreach (Schedule task in Schedules)
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

            foreach (var task in Schedules)
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
            foreach (var task in Schedules)
            {
                if (task.GetStudent() == CurrentUser.Name)
                {
                    task.SetStatus(true);
                }
            }
        }

        public void SetNextTenant()
        {
            foreach (var task in Schedules)
            {
                task.SetNextStudent(Tenants);
            }
        }

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

        public void RemoveTask(string taskName)
        {
            for (int i = 0; i < Schedules.Count; i++)
            {
                if (Schedules[i].GetTask() == taskName)
                {
                    Schedules.RemoveAt(i);
                    Tasks.RemoveAt(i);
                }
            }
        }

        public void testdataToComplaints()
        {
            Complaint newComplaine = new Complaint("Subject 1 ", "topice 1", 1);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2", "topice1 2 ", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2", "topice 12 ", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,","topice 1 32", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 17", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 16", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 14", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 13", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 26", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 20", 2);
            Complaintss.Add(newComplaine);
            newComplaine = new Complaint("Subject 2,", "topice 4", 2);
            Complaintss.Add(newComplaine);
        }

















































































































































































































































    }
}



















































































































































































































































































































