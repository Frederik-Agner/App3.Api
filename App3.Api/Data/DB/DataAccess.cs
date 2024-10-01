using System.Data;
using Npgsql;
using Dapper;

namespace App3.Api.Data.DB;

public class DataAccess : IDataAccess {
    private readonly IConfiguration _config;

    public DataAccess(IConfiguration config) {
        _config = config;
    }

    public async Task<List<T>> LoadDataQuery<T, U>(string Query, string connectionStringName) {
        string connectionString = _config.GetConnectionString(connectionStringName);

        using (IDbConnection connection = new NpgsqlConnection(connectionString)) {
            connection.Open();
            var rows = await connection.QueryAsync<T>(Query);
            return rows.ToList();
        }
    }

    public async Task<long> SaveDataQuery<T>(string Query, T Obj, string connectionStringName) {
        string connectionString = _config.GetConnectionString(connectionStringName);

        using (IDbConnection connection = new NpgsqlConnection(connectionString)) {
            connection.Open();
            var result = await connection.QueryAsync<long>(Query, Obj);
            return result.FirstOrDefault();
        }
    }
}
