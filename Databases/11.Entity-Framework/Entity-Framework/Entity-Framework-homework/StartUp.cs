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

            var customer = GetCustomerById(CustomerId);

            UpdateCustomerCompanyName(customer, "NEW COMPANY NAME");
        }

        private static Customer GetCustomerById(string id)
        {
            var foundCustomer = DAO.GetCustomerById(id);

            return foundCustomer;
        }

        private static void InsertCustomer(string id, string companyName)
        {
            var customer = new Customer()
            {
                CustomerID = id,
                CompanyName = companyName
            };

            DAO.InsertCustomer(customer);
        }

        private static void UpdateCustomerCompanyName(Customer customer, string companyName)
        {
            customer.CompanyName = companyName;

            DAO.SaveUpdatesToCustomer(customer);
        }
    }
}
