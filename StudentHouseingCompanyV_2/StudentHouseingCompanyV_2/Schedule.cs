using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHouseingCompanyV_2
{
    class Schedule
    {
        public string TaskName { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Student { get; private set; }
        public bool Status { get; private set; }

        //Construtor

        /// <summary>
        /// Constuctor for the Schedule for a Specified task
        /// </summary>
        /// <param name="taskName">The name of the task</param>
        /// <param name="firstStudent">The First student doing the Task</param>
        /// <param name="day">name of weekday due date</param>
        public Schedule(string taskName, DayOfWeek day)
        {
            SetTaskName(taskName);
            SetStatus(false);
            SetDueDate(day);
        }


        /// <summary>
        /// Give New Taskname 
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        public void SetTaskName(string taskName)
        {
            this.TaskName = taskName;
        }

        /// <summary>
        /// Sets the weekday task need to be completed
        /// </summary>
        /// <param name="day">Name of Weekday</param>
        public void SetDueDate(DayOfWeek day)
        {
            this.DueDate = DateTime.Today;
            while (DueDate.DayOfWeek != day)
            {
                this.DueDate = DueDate.AddDays(1);
            }
        }

        public void SetStudent(string studentName)
        {
            this.Student = studentName;
        }

        /// <summary>
        /// Set next due date for task
        /// </summary>
        public void NextDueDate()
        {
            this.DueDate = this.DueDate.AddDays(7);
            //Resets of sunday 23:59
        }

        public DateTime ShowNextDate()
        {
            return this.DueDate.AddDays(7);
        }

        /// <summary>
        /// finds and Sets next Student for the next week
        /// </summary>
        /// <param name="students">List of students</param>
        public void SetNextStudent(List<Tenant> students)
        {
            int index = 0;
            bool FoundTenant = false;
            do
            {
                if (this.Student == students[index].Name)
                {
                    FoundTenant = true;
                }

                if (this.Student != students[index].Name)
                {
                    index += 1;
                }
            } while (FoundTenant == false);

            index += 1;
            if (students.Count <= index)
            {
                index = 0;
            }

            this.Student = students[index].Name;
            this.Student = students[index].Name;
            SetStatus(false);
        }

        public String ShowNextStudent(List<Tenant> students)
        {
            int index = 0;
            bool FoundTenant = false;
            do
            {
                if (this.Student == students[index].Name)
                {
                    FoundTenant = true;
                }

                if (this.Student != students[index].Name)
                {
                    index += 1;
                }
            } while (FoundTenant == false);

            index += 1;
            if (students.Count <= index)
            {
                index = 0;
            }

            return students[index].Name;
        }


        /// <summary>
        /// Sets status of task
        /// </summary>
        /// <param name="status">Status of task Completion</param>
        public void SetStatus(bool status)
        {
            this.Status = status;
        }


        //Getters

        /// <summary>
        /// Gets all the infomation from the Schedule
        /// </summary>
        /// <returns></returns>
        public ListViewItem GetInfo()
        {
            string[] arr = new string[4];
            ListViewItem itm;
            //add items to ListView
            arr[0] = Student;
            arr[1] = TaskName;
            if (Status == false)
            {
                arr[2] = "Not Completed";
            }
            else if (Status == true)
            {
                arr[2] = "Completed";
            }
            arr[3] = DueDate.ToString("dd/MM/yyyy");
            itm = new ListViewItem(arr);

            return itm;
        }


    }
}
