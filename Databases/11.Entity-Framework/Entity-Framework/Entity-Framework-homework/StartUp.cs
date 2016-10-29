using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
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
            //InsertCustomer(CustomerId, "new Company name");
            var customer = GetCustomerById(CustomerId);
            UpdateCustomerCompanyName(customer, "NEW COMPANY NAME");
            DeleteCustomer(customer);

            //Insert, update, delete with NativeSQL
            InsertCustomerSql(CustomerId, "new Company name");
            UpdateCustomerCompanyNameSql(CustomerId, "NEW COMPANY NAME");
            DeleteCustomerByIdSql(CustomerId);
        }

        private static void InsertCustomerSql(string customerId, string companyName)
        {
            if (String.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException("Customer id must be provided");
            }

            if (String.IsNullOrEmpty(companyName))
            {
                throw new ArgumentException("Company name must be provided");
            }

            var dbContext = new NorthwindEntities();
            var query = @"INSERT INTO Customers (CustomerID, CompanyName)
                            VALUES (@customerId, @companyName)";
            
            dbContext.Database.ExecuteSqlCommand(
                query, 
                new SqlParameter("@customerId", customerId), 
                new SqlParameter("@companyName", companyName)
            );

            dbContext.SaveChanges();
        }

        private static void UpdateCustomerCompanyNameSql(string customerId, string companyName)
        {
            if (String.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException("Customer id must be provided");
            }

            if (String.IsNullOrEmpty(companyName))
            {
                throw new ArgumentException("Company name must be provided");
            }

            var dbContext = new NorthwindEntities();
            var query = @"UPDATE Customers
                            SET Customers.CompanyName = @companyName
                            WHERE Customers.CustomerID = @customerId";

            dbContext.Database.ExecuteSqlCommand(
                query,
                new SqlParameter("@companyName", companyName),
                new SqlParameter("@customerId", customerId)
            );

            dbContext.SaveChanges();
        }

        private static void DeleteCustomerByIdSql(string customerId)
        {
            if(String.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException("Customer id must be provided");
            }

            var dbContext = new NorthwindEntities();
            var query = @"DELETE FROM Customers
                          WHERE Customers.CustomerID = @customerId";

            dbContext.Database.ExecuteSqlCommand(
                query,
                new SqlParameter("@customerId", customerId)
            );

            dbContext.SaveChanges();
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

        private static void DeleteCustomer(Customer customer)
        {
            DAO.DeleteCustomer(customer);
        }
    }
}
