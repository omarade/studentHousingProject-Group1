using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Product
    {


        public Product(string name, double fullPrice, int ID)
        {
            this.FullPrice = fullPrice;
            this.Name = name;
            this.ProductId = ID;
            TenantesIDShredWith = new List<int>();
            TenantesShredWith   = new List<Tenant>();
        }

        public string Name
        {
            get;
            set;
        }

        public double FullPrice
        {
            get;
            set;
        }

        public double DevidedPrice
        {
            get;
            set;
        }

        public int ProductId
        {
            get;
            set;
        }

        public List<Tenant> TenantesShredWith
        {
            get;
            set;
        }

        public List<int> TenantesIDShredWith
        {
            get;
            set;
        }
        

    }
}