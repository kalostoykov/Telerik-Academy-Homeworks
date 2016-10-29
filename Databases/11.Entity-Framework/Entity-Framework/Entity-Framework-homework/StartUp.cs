using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Framework_homework.Data;

namespace Entity_Framework_homework
{
    public class StartUp
    {
        private const string CustomerId = "QWERT";

        static void Main(string[] args)
        {
            InsertCustomer(CustomerId, "new Contact name");
        }

        private static void InsertCustomer(string id,string name)
        {
            var customer = new Customer()
            {
                CustomerID = id,
                CompanyName = name
            };

            DAO.InsertCustomer(customer);
        }
    }
}
