using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Joins_Demo
{
    public class Customer
    {
        public int? CustId { get; set; }
        public string CustName { get; set; }
        public string Contact { get; set; }
        public static List<Customer> GetAllCustomer()
        {
            return new List<Customer>()
            {
                new Customer { CustId = 1, CustName = "Priyanka", Contact = "9856325874" },
                new Customer { CustId = 2, CustName = "Raj", Contact = "7958425632" },
                new Customer { CustId = 3, CustName = "Rahul", Contact = "8236589654" },
                new Customer { CustId = 4, CustName = "Sam", Contact = "7995826352" },
                new Customer { CustId = 5, CustName = "John", Contact = "45454545" }
            };
        }
    }
}
