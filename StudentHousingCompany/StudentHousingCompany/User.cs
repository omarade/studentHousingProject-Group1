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
        private static int idSeeder = 0;

        public int Id
        {
            get; 
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User(string name, DateTime dateOfBirth, string email, string password)
        {
            Id = idSeeder;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.password = password;
            idSeeder++;
        }

        
    }
}