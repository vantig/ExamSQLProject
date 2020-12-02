using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamProject.DAO
{
    public class MsSqlAbstractDao : IAbstractDao
    {
        private readonly string _connectionString;

        public MsSqlAbstractDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["customerConnection"].ConnectionString;
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public void ReleaseConnection(IDbConnection connection)
        {
            connection.Close();
        }
    }
}
