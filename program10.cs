using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program10
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

                newRow["StudentID"] = 102;
                newRow["Name"] = "Vikas";
                newRow["Age"] = 22;
                newRow["Course"] = "MCA";

                dt.Rows.Add(newRow);

                adapter.Update(ds, "Student");

                Console.WriteLine("Student inserted.");

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["StudentID"]) == 1)
                    {
                        row["Name"] = "Rahul Kumar";
                        row["Age"] = 23;
                        row["Course"] = "MCA";
                        break;
                    }
                }

                adapter.Update(ds, "Student");

                Console.WriteLine("Student updated.");

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["StudentID"]) == 4)
                    {
                        row.Delete();
                        break;
                    }
                }

                adapter.Update(ds, "Student");

                Console.WriteLine("Student deleted.");

                Console.WriteLine("\nStudent Records:");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                        "ID: " + row["StudentID"] +
                        ", Name: " + row["Name"] +
                        ", Age: " + row["Age"] +
                        ", Course: " + row["Course"]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
