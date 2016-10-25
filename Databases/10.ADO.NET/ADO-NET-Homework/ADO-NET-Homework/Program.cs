using System;
using System.CodeDom;
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
        private const string ConnectionString = "Server=.\\sqlexpress; Database=Northwind; Integrated Security=true";

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

            Console.WriteLine("Task 3:");
            ExtractCategoriesAndTheirProducts();

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Task 4:");
            AddProduct("NewProduct", 4, 1, 1.20m);

            Console.WriteLine(new string('-', 50));
        }

        private static void CategoriesCount()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            
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
            SqlConnection connection = new SqlConnection(ConnectionString);

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

            connection.Close();
        }

        private static void ExtractCategoriesAndTheirProducts()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(@"SELECT c.CategoryName, p.ProductName
                                                    FROM Products AS p
                                                    LEFT JOIN Categories AS c
                                                    ON p.CategoryId = c.CategoryId", 
                                                    connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = reader["CategoryName"].ToString();
                        string productName = reader["ProductName"].ToString();

                        Console.WriteLine("{0} : {1}", categoryName, productName);
                    }
                }
            }

            connection.Close();
        }

        private static void AddProduct(string productName, int supplierId, int categoryId, decimal unitPrice)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(@"INSERT INTO Products(ProductName, SupplierId, CategoryId, UnitPrice)
                                                      VALUES (@productName, @supplierId, @categoryId, @unitPrice)",
                                                    connection);

                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@supplierId", supplierId);
                command.Parameters.AddWithValue("@categoryId", categoryId);
                command.Parameters.AddWithValue("@unitPrice", unitPrice);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
