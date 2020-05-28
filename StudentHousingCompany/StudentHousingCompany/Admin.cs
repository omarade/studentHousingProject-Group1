using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Admin : User
    {
        private int id;
        private static int idSeeder = 0;

        public Admin(string name, DateTime dateOfBirth, string email, string password)
            : base(name, dateOfBirth, email, password)
        {
            SetId();
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
