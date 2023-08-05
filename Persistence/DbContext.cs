using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Persistence;

public class DbContext : IDbContext
{
    private readonly SqlConnection conn;

    public DbContext(IOptions<DbContextOptions> options)
    {
        conn = new SqlConnection(options.Value.ConnectionString);
    }

    public void ExecuteCommand(string sql)
    {
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        cmd.ExecuteScalar();
        conn.Close();
    }

    public string ExecuteQuery(string sql)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            var sqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var enumerable = Serialize(sqlDataReader);
            var serializeObject = JsonConvert.SerializeObject(enumerable, Newtonsoft.Json.Formatting.Indented);
            return serializeObject;
        }
        finally
        {
            conn.Close();
        }
    }

    private IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
    {
        var results = new List<Dictionary<string, object>>();
        var colNames = new List<string>();
        for (var i = 0; i < reader.FieldCount; i++)
            colNames.Add(reader.GetName(i));

        while (reader.Read())
            results.Add(SerializeRow(colNames, reader));

        return results;
    }

    private Dictionary<string, object> SerializeRow(IEnumerable<string> colNames,
        SqlDataReader reader)
    {
        var result = new Dictionary<string, object>();
        foreach (var col in colNames)
            result.Add(col, reader[col]);
        return result;
    }
}