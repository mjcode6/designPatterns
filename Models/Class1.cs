using attaque.Data;
using Microsoft.Data.SqlClient;

namespace attaque.Models
{
    public class Class1
    {
        private SqlConnection database;

        public Class1()
        {
            database = DatabaseSingleton.Instance.GetConnection();
        }

        public void InsertData(string data)
        {
            string query = "INSERT INTO YourTableName (ColumnName) VALUES (@data)";

            using (SqlCommand command = new SqlCommand(query, database))
            {
                command.Parameters.AddWithValue("@data", data);
                command.ExecuteNonQuery();
            }
        }

        public string GetData(int id)
        {
            string query = "SELECT ColumnName FROM YourTableName WHERE ID = @id";
            string result = null;

            using (SqlCommand command = new SqlCommand(query, database))
            {
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader["ColumnName"].ToString();
                    }
                }
            }

            return result;
        }
    }

}