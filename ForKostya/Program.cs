using System;
using System.Data.SqlClient;
using System.Text.Json;
using System.Configuration;

namespace ForKostya
{
    class Program
    {
        /*class Person
        {
             public int Id { get; }
             public string Title { get; set; }
             public Person(string id, string title)
             {
                 Id = id;
                 Title = title;
             }
        }*/
        private static SqlConnection SqlConnection = null;
        private static string connectionString = @"Data Source=(local);Initial Catalog=Books;Integrated Security=True";
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод данных в формате JSON:");
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
            SqlDataReader books = null;
            string command = string.Empty;
            while (true)
            {
                Console.Write("> ");
                command = Console.ReadLine();

                SqlCommand sqlCommand = new SqlCommand(command, SqlConnection);
                books = sqlCommand.ExecuteReader();
                /*Person tom = new Person("id", "title","price","year","AuthorId");
                string json = JsonSerializer.Serialize(tom);
                Console.WriteLine(json);*/
                while (books.Read())
                {
                    Console.WriteLine($"ID: {books["id"]}; НАЗВАНИЕ: {books["title"]}; ЦЕНА: {books["price"]}; ГОД ИЗДАНИЯ: {books["year"]}; КОД АВТОРА: {books["AuthorId"]};");
                    Console.WriteLine(new string('-',100));
                }

                if (books != null)
                {
                    books.Close();
                }
            }
        }
    }
}
