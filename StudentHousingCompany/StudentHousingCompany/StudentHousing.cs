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
        
        List<User> users = new List<User>();
        List<Schedule> schedule = new List<Schedule>();
        List<string> tasks = new List<string>();

        //Test users
        List<string> testusers = new List<string>();

        public void AddTestData()
        {
            testusers.Add("a");
            testusers.Add("b");
            testusers.Add("c");
            testusers.Add("d");
            testusers.Add("e");
            testusers.Add("f");
            testusers.Add("g");
            testusers.Add("h");
            testusers.Add("i");

        }
        

        public void AddTenant()
        {
            //User tenant = new Tenant("Omar", );
            //users.Add(tenant);
        }





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
                task.SetStudent(testusers[counter]);
                counter++;
                if (counter >= testusers.Count)
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
            arr[0] = schedule[tasks.Count-1].GetStudent();
            arr[1] = schedule[tasks.Count-1].GetTask();
            arr[2] = schedule[tasks.Count-1].GetStatus().ToString();
            itm = new ListViewItem(arr);

            return itm;
        }
    }
}
