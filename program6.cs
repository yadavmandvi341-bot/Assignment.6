using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program6
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

                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        DataRow row = ds.Tables["Student"].NewRow();

                        Console.Write("Enter Student Name: ");
                        row["Name"] = Console.ReadLine();

                        Console.Write("Enter Student Age: ");
                        row["Age"] = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Course: ");
                        row["Course"] = Console.ReadLine();

                        ds.Tables["Student"].Rows.Add(row);

                        int rows = adapter.Update(ds, "Student");

                        if (rows > 0)
                        {
                            Console.WriteLine("\nStudent inserted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nInsertion Failed!");
                        }
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
