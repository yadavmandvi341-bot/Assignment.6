using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program5
{
    static void Main()
    {
        string connectionString =
            @"Server = .\SQLEXPRESS;
              Database = StudentDB;
              Integrated Security = True;
              TrustServerCertificate = True;";

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "Student");

                    Console.WriteLine("Student Records");
                    Console.WriteLine();

                    foreach (DataRow row in ds.Tables["Student"].Rows)
                    {
                        Console.WriteLine("Student ID : " + row["StudentID"]);
                        Console.WriteLine("Name : " + row["Name"]);
                        Console.WriteLine("Age : " + row["Age"]);
                        Console.WriteLine("Course : " + row["Course"]);
                        Console.WriteLine();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
