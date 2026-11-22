using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program4
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
                    @"DELETE FROM Student
                      WHERE StudentId = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", 2);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Console.WriteLine("Student record deleted successfully");
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
