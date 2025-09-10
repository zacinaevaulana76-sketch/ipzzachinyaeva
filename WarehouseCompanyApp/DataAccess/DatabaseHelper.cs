using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WarehouseCompanyApp.DataAccess
{
    public class DatabaseHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["WarehouseDB"].ConnectionString;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}