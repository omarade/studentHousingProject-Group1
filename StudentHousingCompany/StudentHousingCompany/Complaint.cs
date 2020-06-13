using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHousingCompany
{

    class Complaint
    {
        private static int ID = 0;

        public int ComplaintId
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ComplaintTopic
        {
            get;
            set;
        }

        public int TenID
        {
            get;
            private set;
        }
        
        public int AdmID
        {
            get;
            set;
        }

         public string CreaterName 
        {
             get;
            private set;
        }

        public bool Anonymous
        {
            get;
            set;
        }

        public string ReplyFromAdmin
        {
            get;
            set;
        }

        public string ReplyFromTen
        {
            get;
            set;
        }

        public bool Solved
        {
            get;
            set;
        }

        public bool ReplyFromAdmIsRead
        {
            get;
            set;
        }

        public Complaint(string Description, string topic)
        {
            this.ComplaintTopic = topic;
            this.Description = Description;
            ComplaintId = ID;
            ID++;
            
            this.TenID = StudentHousingCompany.StudentHousing.Instance.CurrentUser.Id;
            this.CreaterName = StudentHousingCompany.StudentHousing.Instance.CurrentUser.Name;
        }

        public string GetText()
        {
            return ComplaintTopic + ":" + "\n" + Description;
        }

        
        
    }
}
