using Microsoft.Data.SqlClient;
using System.Data;

namespace attaque.Data
{
    public class DatabaseSingleton
    {
        private static readonly Lazy<DatabaseSingleton> instance = new Lazy<DatabaseSingleton>(() => new DatabaseSingleton());

        private SqlConnection connection;

        private DatabaseSingleton()
        {
            string connectionString = "Server=MANOJ;Database=singletonDb;Trusted_Connection=True;TrustServerCertificate=Yes;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public static DatabaseSingleton Instance => instance.Value;

        public SqlConnection GetConnection()
        {
            return connection;
        }





    }
}



       

