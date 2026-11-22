using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program9
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

                DataRow newRow = dt.NewRow();

                newRow["StudentID"] = 100;
                newRow["Name"] = "Suresh";
                newRow["Age"] = 22;
                newRow["Course"] = "MCA";

                dt.Rows.Add(newRow);

                adapter.Update(ds, "Student");

                Console.WriteLine("Record inserted.");

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["StudentID"]) == 1)
                    {
                        row["Name"] = "Rahul Updated";
                        row["Age"] = 23;
                        row["Course"] = "MCA";
                        break;
                    }
                }

                adapter.Update(ds, "Student");

                Console.WriteLine("Record updated.");

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["StudentID"]) == 3)
                    {
                        row.Delete();
                        break;
                    }
                }

                adapter.Update(ds, "Student");

                Console.WriteLine("Record deleted.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
