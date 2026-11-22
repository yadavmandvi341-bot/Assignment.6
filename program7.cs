using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program7
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
                string query = "SELECT * FROM Student";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Student");

                DataTable dt = ds.Tables["Student"];

                DataRow[] rows = dt.Select("StudentId = 1");

                if (rows.Length > 0)
                {
                    rows[0]["Name"] = "Abhishek";
                    rows[0]["Age"] = 24;
                    rows[0]["Course"] = "BCA";

                    SqlCommandBuilder builder =
                        new SqlCommandBuilder(adapter);

                    int result = adapter.Update(ds, "Student");

                    if (result > 0)
                    {
                        Console.WriteLine("Student details updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("No changes found");
                    }
                }
                else
                {
                    Console.WriteLine("Student record not found");
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
