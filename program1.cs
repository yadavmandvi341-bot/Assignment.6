using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program1
{
    static void Main()
    {
        string connectionString =
            @"Server=.\SQLEXPRESS;
              Database=StudentDB;
              Integrated Security=True;
              TrustServerCertificate=True;";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                Console.WriteLine("Database Connected Successfully");
                Console.WriteLine();

                string query = "SELECT * FROM Student";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                reader["StudentId"] + " " +
                                reader["Name"] + " " +
                                reader["Age"] + " " +
                                reader["Course"]);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }
}
