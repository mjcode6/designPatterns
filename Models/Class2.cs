using attaque.Data;
using Microsoft.Data.SqlClient;

namespace attaque.Models
{
    public class Class2
    {
        private SqlConnection database;

        public Class2()
        {
            database = DatabaseSingleton.Instance.GetConnection();
        }

        public void UpdateData(int id, string newData)
        {
            string query = "UPDATE YourTableName SET ColumnName = @newData WHERE ID = @id";

            using (SqlCommand command = new SqlCommand(query, database))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteData(int id)
        {
            string query = "DELETE FROM YourTableName WHERE ID = @id";

            using (SqlCommand command = new SqlCommand(query, database))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }

}
