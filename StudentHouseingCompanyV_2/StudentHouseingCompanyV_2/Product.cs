using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseingCompanyV_2
{
    class Product
    {

        public static int ProductId = 0;
        public Product(string name, double fullPrice)
        {
            
            this.FullPrice = fullPrice;
            this.Name = name;
            this.PproductId = Product.ProductId;
            TenantesIDShredWith = new List<int>();
            TenantesShredWith   = new List<Tenant>();
            Product.ProductId++;
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

        public int PproductId
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
        //public ListViewItem GetBlanceInfo()
        //{
        //    string[] arr = new string[4];
        //    ListViewItem itm;
        //    //add items to ListView
        //    arr[0] = GetStudent();
        //    arr[1] = GetTask();
        //    arr[2] = GetStatus().ToString();
        //    arr[3] = GetDueDate().ToString();
        //    itm = new ListViewItem(arr);
        //    return itm;
        //}
    }
}
