using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Complaint
    {

        public int complaintId
        {
            get;
            set;
        }

        public string Subject 
        {
            get;
            set;
        }

        public string complaintTopic
        {
            get;
            set;
        }

        public int senderID
        {
            get;
            set;
        }
        
        public int recieverID
        {
            get;
            set;
        }


    }
}
