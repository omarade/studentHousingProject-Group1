﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingCompany
{
    class Tenant : User
    {

        public string PhoneNr
        {
            get;
            set;
        }

        public string Postcode
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public int Balance
        {
            get;
            set;
        }

        public Tenant(string name, DateTime dateOfBirth, string email, string password, string phoneNr, string postcode, string address)
            : base(name, dateOfBirth, email, password)
        {
            PhoneNr = phoneNr;
            Postcode = postcode;
            Address = address;
            Balance = 0;
        }
    }
}