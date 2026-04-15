using Microsoft.Data.SqlClient;
using System.Data;

namespace LobbyLink.DataAccess.SQLClient
{
    abstract public class BaseDao
    {
        public string ConnectionString { get; set; }

    
        public BaseDao(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
