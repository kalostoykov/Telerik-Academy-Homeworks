using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;

namespace ADO_NET_Homework
{
    class StartUp
    {
        private const string ConnectionString = "Server=.\\sqlexpress; Database=Northwind; Integrated Security=true";
        private const string MySqlConnectionString = "SERVER=localhost;DATABASE=bookstore;UID=root;PWD=root;";

        static void Main(string[] args)
        {
            //I didn't have time to do the homework well
            //sorry for the bad code

            //Console.WriteLine("Task 1:");
            //CategoriesCount();

            //Console.WriteLine(new string('-', 50));

            //Console.WriteLine("Task 2:");
            //CategoriesNameAndDescription();

            //Console.WriteLine(new string('-', 50));

            //Console.WriteLine("Task 3:");
            //ExtractCategoriesAndTheirProducts();

            //Console.WriteLine(new string('-', 50));

            //Console.WriteLine("Task 4:");
            ////AddProduct("NewProduct", 4, 1, 1.20m);

            //Console.WriteLine(new string('-', 50));

            //Console.WriteLine("Task 5:");
            //ExtractAllCategoryImages();

            //Console.WriteLine(new string('-', 50));

            Console.WriteLine("Task 9:");
            ExtractBooks();

            Console.WriteLine(new string('-', 50));

            FindBookByTitle("Title 1");

            Console.WriteLine(new string('-', 50));

            AddBook("New Book", "New Author");
            ExtractBooks();
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

        private static void ExtractAllCategoryImages()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        categoryName = categoryName.Replace('/', '-');

                        byte[] fileContent = (byte[])reader["Picture"];
                        string fileName = categoryName;
                        string fileFormat = "jpg";
                        string path = "../../Images/";

                        SaveImage(path, fileName, fileFormat, fileContent);

                        Console.WriteLine($"Image {fileName}.{fileFormat} saved!");
                    }
                }
            }

            connection.Close();
        }

        private static void SaveImage(string filePath, string fileName, string fileFormat, byte[] fileContent)
        {
            string imageFullInfo = $"{filePath}{fileName}.{fileFormat}";
            FileStream stream = File.OpenWrite(imageFullInfo);

            using (stream)
            {
                stream.Write(fileContent, 78, fileContent.Length - 78);
            }
        }

        private static void ExtractBooks()
        {
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            connection.Open();

            using (connection)
            {
                MySqlCommand command = new MySqlCommand(@"SELECT title, author FROM books",
                                                    connection);

                MySqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string bookTitle = reader["title"].ToString();
                        string bookAuthor = reader["author"].ToString();

                        Console.WriteLine("{0} , {1}", bookTitle, bookAuthor);
                    }
                }
            }

            connection.Close();
        }

        private static void FindBookByTitle(string title)
        {
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            connection.Open();

            using (connection)
            {
                MySqlCommand command = new MySqlCommand(@"SELECT title, author FROM books WHERE title = @title",
                                                    connection);

                command.Parameters.AddWithValue("@title", title);

                MySqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string bookTitle = reader["title"].ToString();
                        string bookAuthor = reader["author"].ToString();

                        Console.WriteLine("{0} , {1}", bookTitle, bookAuthor);
                    }
                }
            }

            connection.Close();
        }

        private static void AddBook(string title, string author, DateTime? publishDate = null, string isbn = null)
        {
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            connection.Open();

            using (connection)
            {
                MySqlCommand command = new MySqlCommand(@"INSERT INTO books(title, author, publishDate, isbn) VALUES (@title, @author, @publishDate, @isbn)",
                                                    connection);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@publishDate", publishDate);
                command.Parameters.AddWithValue("@isbn", isbn);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
