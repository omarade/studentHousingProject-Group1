using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Tenant : User
    {
        private string phoneNr;
        private string postcode;
        private string address;
        private int balance;

        public string PhoneNr
        {
            get { return phoneNr; }
            set { phoneNr = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Tenant(string name, DateTime dateOfBirth, string email, string password, string phoneNr, string postcode, string address)
            : base(name, dateOfBirth, email, password)
        {
            this.phoneNr = phoneNr;
            this.postcode = postcode;
            this.address = address;
            this.balance = 0;
        }
    }
}