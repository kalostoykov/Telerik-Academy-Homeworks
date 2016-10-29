using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Framework_homework.Data;

namespace Entity_Framework_homework
{
    public class DAO
    {
        public static NorthwindEntities GetDBContext()
        {
            var dbContext = new NorthwindEntities();

            return dbContext;
        }

        public static Customer GetCustomerById(string id)
        {
            var dbContext = GetDBContext();
            var foundCustomer = dbContext.Customers.Find(id);

            if (foundCustomer == null)
            {
                throw new ArgumentNullException("Customer does not exist!");
            }

            return foundCustomer;
        }

        public static void InsertCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var dbContext = GetDBContext();

            if (dbContext.Customers.Find(customer.CustomerID) != null)
            {
                throw new ArgumentException("This customer already exists in the database!");    
            }

            dbContext.Customers.Add(customer);

            DbContextSaveChanges(dbContext);
        }
        
        public static void SaveUpdatesToCustomer(Customer customerWithUpdates)
        {
            if (customerWithUpdates == null)
            {
                throw new ArgumentNullException(nameof(customerWithUpdates));
            }

            var dbContext = GetDBContext();
            var customerToUpdate = dbContext.Customers.Find(customerWithUpdates.CustomerID);

            if (customerWithUpdates == null)
            {
                throw new ArgumentNullException("Customer does not exist!");
            }

            var dataToUpdate = dbContext.Entry(customerToUpdate).CurrentValues;
            dataToUpdate.SetValues(customerWithUpdates);

            DbContextSaveChanges(dbContext);
        }

        public static void DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var dbContext = GetDBContext();
            var foundCustomer = dbContext.Customers.Find(customer.CustomerID);

            if (foundCustomer == null)
            {
                throw new ArgumentNullException("Customer does not exist!");
            }

            dbContext.Customers.Remove(foundCustomer);

            DbContextSaveChanges(dbContext);
        }

        private static void DbContextSaveChanges(NorthwindEntities dbContext)
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
