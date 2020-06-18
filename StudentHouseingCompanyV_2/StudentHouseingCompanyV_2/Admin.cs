using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseingCompanyV_2
{
    class Admin : User
    {

        public Admin(string name, DateTime dateOfBirth, string email, string password)
            : base(name, dateOfBirth, email, password)
        {
            
        }

    }
}
