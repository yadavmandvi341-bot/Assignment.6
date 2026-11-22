using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program8
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

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Student");

                DataTable dt = ds.Tables["Student"];

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["StudentID"]) == 2)
                    {
                        row.Delete();
                        break;
                    }
                }

                adapter.Update(ds, "Student");

                Console.WriteLine("Student deleted successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
