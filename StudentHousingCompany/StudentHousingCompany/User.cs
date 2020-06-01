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
        private static int idSeeder = 0;

        public int Id
        {
            get; 
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public User(string name, DateTime dateOfBirth, string email, string password)
        {
            Id = idSeeder;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            Password = password;
            idSeeder++;
        }

        
    }
}