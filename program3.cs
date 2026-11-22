using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program3
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

                string query =
                    @"UPDATE Student
                      SET Name = @name,
                          Age = @age,
                          Course = @course
                      WHERE StudentId = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", 2);
                    cmd.Parameters.AddWithValue("@name", "Shubham");
                    cmd.Parameters.AddWithValue("@age", 21);
                    cmd.Parameters.AddWithValue("@course", "CS");

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("Student details updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("Student record not found");
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
