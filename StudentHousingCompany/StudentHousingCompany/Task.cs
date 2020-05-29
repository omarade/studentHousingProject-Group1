using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Task
    {
        private string Taskname;
        private DateTime DueDate;
        private string Student;
        private bool Status;

        //Construtor

        /// <summary>
        /// Constuctor for the Schedule 
        /// Also finds date of next weekday day selceted
        /// </summary>
        /// <param name="taskName">The name of the task</param>
        /// <param name="firstStudent">The First student doing the Task</param>
        /// <param name="day">name of weekday due date</param>
        public Task(string taskName, string firstStudent, DayOfWeek day)
        {
            SetTaskName(taskName);
            SetStatus(false);
            this.Student = firstStudent;



            this.DueDate = DateTime.Today;
            while (DueDate.DayOfWeek != day)
            {
                this.DueDate = DueDate.AddDays(1);
            }
        }



        public void SetTaskName(string taskName)
        {
            this.Taskname = taskName;
        }

        public void NewDueDate()
        {//Set new due date for task eg. Next week friday (Auto)

            this.DueDate = this.DueDate.AddDays(7);
            //Resets of sunday 23:59
        }

        public void SetNextStudent(List<string> students)
        {//Sets new Student for the next week

            //following student in the student list index
            int index;

            index = students.FindIndex(a => a.Contains(Student));
            index += 1;
            if (students.Count <= index)
            {
                index = 0;
            }

            this.Student = students[index];

        }

        public void SetStatus(bool status)
        {//Sets status of task
            this.Status = status;
        }




        //Getters
        public string[] GetInfo()
        {
            string[] row = { this.Student, this.Taskname, "this.Status"};
            return row;
            //var listViewItem = new ListViewItem(row);
            //listView6.Items.Add(listViewItem);
        }

        public string GetTask()
        {
            return this.Taskname;
        }

        public string GetStudent()
        {
            return this.Student;
        }

        public bool GetStatus()
        {
            return this.Status;
        }

        public DateTime GetDueDate()
        {
            return this.DueDate;
        }
    
    }
}
