using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ADO_NET_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //I didn't have time to do the homework well
            //sorry for the bad code

            Console.WriteLine("Task 1:");
            CategoriesCount();

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Task 2:");
            CategoriesNameAndDescription();

            Console.WriteLine(new string('-', 50));
        }

        private static void CategoriesCount()
        {
            SqlConnection connection = new SqlConnection("Server=.\\sqlexpress; Database=Northwind; Integrated Security=true");
            
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Categories count is {0}", reader[0]);
                    }
                }
            }
        }

        private static void CategoriesNameAndDescription()
        {
            SqlConnection connection = new SqlConnection("Server=.\\sqlexpress; Database=Northwind; Integrated Security=true");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Category: {0}; Description: {1}", reader["CategoryName"], reader["Description"]);
                    }
                }
            }
        }
        
    }
}
