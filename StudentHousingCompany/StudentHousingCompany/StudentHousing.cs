using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class StudentHousing
    {
        private static StudentHousing instance = new StudentHousing();

        List<User> users = new List<User>();

        List<Tenant> tenants = new List<Tenant>();
        


        public static StudentHousing Instance
        {
            get;
        }

        public List<User> Users
        {
            get;
        }

        public List<Tenant> Tenants
        {
            get;
        }


        private StudentHousing(){}

        public void AddUser(string name, DateTime dob, string email, string password)
        {
            User admin = new Admin(name, dob, email, password);
            users.Add(admin);
        }

        public void AddUser(string name, DateTime dob, string email, string password, string phoneNr, string postcode, string address)
        {
            User tenant = new Tenant(name, dob, email, password, phoneNr, postcode, address);
            users.Add(tenant);

            Tenant newTenant = (Tenant) tenant;
            tenants.Add(newTenant);
        }
    }
}
