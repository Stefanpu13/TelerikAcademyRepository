using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public class Customer
    {
        public string FullName { get; set; }

        public string Adress { get; set; }

        public Customer(string fullName, string adress) 
        {
            this.FullName = fullName;
            this.Adress = adress;
        }
    }
}
