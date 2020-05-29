using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentHousingCompany
{
    class StudentHousing
    {
        
        List<User> users = new List<User>();
        List<Task> tasks = new List<Task>();
        

        public void AddTenant()
        {
            //User tenant = new Tenant("Omar", );
            //users.Add(tenant);
        }

        public void AddTask(string taskName)
        {//TODO Find the right student name to add to the task
            Task task = new Task(taskName,"Name of user from list", DayOfWeek.Friday);
            tasks.Add(task);
        }

        public void ShowAllTaskInfo()
        {
            foreach (Task task in tasks)
            {
                //Return array of values of task info
            }
        }
    }
}
