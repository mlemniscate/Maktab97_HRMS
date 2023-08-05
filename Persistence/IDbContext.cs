using System.Data.SqlClient;

namespace Persistence;

public interface IDbContext
{
    void ExecuteCommand(string sql);
    string ExecuteQuery(string sql);
}