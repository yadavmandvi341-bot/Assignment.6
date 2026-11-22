using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program2
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
                    @"INSERT INTO Student(Name, Age, Course)
                      VALUES(@name, @age, @course)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", "Rahul");
                    cmd.Parameters.AddWithValue("@age", 23);
                    cmd.Parameters.AddWithValue("@course", "MCA");

                    int rows1 = cmd.ExecuteNonQuery();

                    cmd.Parameters["@name"].Value = "Abhishek";
                    cmd.Parameters["@age"].Value = 24;
                    cmd.Parameters["@course"].Value = "BCA";

                    int rows2 = cmd.ExecuteNonQuery();

                    int totalRows = rows1 + rows2;

                    if (totalRows == 2)
                    {
                        Console.WriteLine("2 Students inserted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Insertion Failed");
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
