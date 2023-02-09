using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dal
{
    public class Conductos
    {
        public void AddEmply(string firstName, string lastName, string Type)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.130.54.80";
                builder.UserID = "sa";
                builder.Password = "A1234a56!89";
                builder.InitialCatalog = "cardealership";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    string initial = firstName.Substring(0, 1) + lastName.Substring(0, 1);
                    String sql = "INSERT INTO emplys (first_name, last_name, initial, emply_type) VALUES ('" + firstName + "', '" + lastName + "', '" + initial + "', '" + Type + "');";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public string GetEmply()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.130.54.80";
                builder.UserID = "sa";
                builder.Password = "A1234a56!89";
                builder.InitialCatalog = "cardealership";
                string tabel = "emplys";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    String sql = "SELECT TOP (50) emply_id, first_name, last_name , initial , emply_type FROM " + tabel + " FOR JSON AUTO;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        var jsonResult = new StringBuilder();
                        SqlDataReader oReader = command.ExecuteReader();
                        while (oReader.Read())
                        {
                            jsonResult.Append(oReader[0]);
                        }
                        return jsonResult.ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        //Get Emply detail based on Emplyee id
        public string GetEmply(int emplyId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.130.54.80";
                builder.UserID = "sa";
                builder.Password = "A1234a56!89";
                builder.InitialCatalog = "cardealership";
                string tabel = "emplys";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    String sql = "SELECT emply_id, initial, first_name, last_name ,emply_type FROM " + tabel + " WHERE emply_id=" + emplyId + " FOR JSON AUTO;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        var jsonResult = new StringBuilder();
                        SqlDataReader oReader = command.ExecuteReader();
                        while (oReader.Read())
                        {
                            int i = 0;
                            jsonResult.Append(oReader[i]);
                            i++;
                        }
                        return jsonResult.ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        //Delte Emply detail based on Emplyee id
        public string DeleteEmply(int emplyId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.130.54.80";
                builder.UserID = "sa";
                builder.Password = "A1234a56!89";
                builder.InitialCatalog = "cardealership";
                string tabel = "emplys";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    String sql = "DELETE FROM " + tabel + " WHERE emply_id=" + emplyId + ";";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        connection.Open();
                        command.ExecuteNonQuery();
                        return "success";
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }

        //Delte Emply detail based on Emplyee id
        public string UpdateEmply(int emplyId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.130.54.80";
                builder.UserID = "sa";
                builder.Password = "A1234a56!89";
                builder.InitialCatalog = "cardealership";
                string tabel = "emplys";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    String sql = "UPDATE " + tabel + " WHERE emply_id=" + emplyId + ";";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        connection.Open();
                        command.ExecuteNonQuery();
                        return "success";
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }


    }
}
