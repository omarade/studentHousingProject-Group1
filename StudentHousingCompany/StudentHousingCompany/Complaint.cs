using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{

    class Complaint
    {
        private static int ID = 0;
        private static Complaint instance = new Complaint();
        public static Complaint Instance
        {
            get { return instance; }
        }

        public Complaint() { }
        public Complaint(string subject, string topic, int tenID)
        {
            this.ComplaintTopic = topic;
            this.Subject = subject;
            this.TenID = tenID;
            ComplaintId = ID;
            ID++;
            ReplyFromAdmin = null;
        }

        public int ComplaintId
        {
            get;
            set;
        }

        public string Subject 
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
            set;
        }
        
        public int AdmID
        {
            get;
            set;
        }

        public string TenName 
        {
            get;
            set;
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

        public string GetText()
        {
            // adding date to the text  !?
            if (Anonymous)
            {
                return ComplaintTopic + "" + Subject;
            }
            else
            {
                return TenName + $" \n " + ComplaintTopic + "\n\r " + Subject;
            }
        }

        
    }
}
