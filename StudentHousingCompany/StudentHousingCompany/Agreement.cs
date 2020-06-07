using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Agreement
    {
        private static int idSeeder = 0;

        public int Id
        {
            get;
        }

        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public Tenant CreatorTenant
        {
            get;
            set;
        }

        public List<Tenant> WithTenants
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Agreement(string title, string description, Tenant creatorTenant, List<Tenant> withTenants)
        {
            Id = idSeeder;
            Title = title;
            Description = description;
            CreatorTenant = creatorTenant;
            WithTenants = withTenants;
            Date = DateTime.Today;
            idSeeder++;
        }
    }
}
