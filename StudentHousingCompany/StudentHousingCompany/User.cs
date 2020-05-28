using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class User
    {
        private string name;
        private DateTime dateOfBirth;
        private string email;
        private string password;

        public User(string name, DateTime dateOfBirth, string email, string password)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.password = password;
        }
    }
}