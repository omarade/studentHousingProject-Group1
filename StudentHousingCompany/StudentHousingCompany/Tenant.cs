using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Tenant : User
    {
        private int id;
        private string phoneNr;
        private string postcode;
        private string address;
        private static int idSeeder = 0;

        public Tenant(string name, DateTime dateOfBirth, string email, string password, string phoneNr, string postcode, string address)
            : base(name, dateOfBirth, email, password)
        {
            SetId();
            this.phoneNr = phoneNr;
            this.postcode = postcode;
            this.address = address;
        }
        public int GetId()
        {
            return id;
        }
        public void SetId()
        {
            id = idSeeder;
            idSeeder++;
        }

    }
}