using System.Data;

namespace ExamProject.DAO
{
    public interface IAbstractDao
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection connection);
    }
}
