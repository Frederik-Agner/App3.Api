using App3.Api.Data.Interface;
using App3.Api.Data.DB;
using App3.Api.Models;

namespace App3.Api.Data.Repository;

public class UserRepository : IUserRepository {
    private readonly DataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;

    public UserRepository(DataAccess dataAccess, ConnectionStringData connectionString) {
        _dataAccess = dataAccess;
        _connectionString = connectionString;
    }

    public async Task<List<User>> GetAll() {
        try {
            string tableName = "User";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\"";
            List<User> result = await _dataAccess.LoadDataQuery<User, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result.Count > 0) return result;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public async Task<long> Register(User user) {
        try {
            string tableName = "User";
            string PGQuery =
                $"INSERT INTO public.\"{tableName}\" (\"Username\", \"Password\", \"Type\") " +
                $"VALUES (@Username, @Password, @Type) " +
                "RETURNING \"Id\";";
            user.Id = await _dataAccess.SaveDataQuery(PGQuery, user, _connectionString.SqlConnectionName);
            return user.Id;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return 0;
        }
    }

    public async Task<bool> Update(User user) {
        try {
            string tableName = "User";
            string PGQuery =
                $"UPDATE \"{tableName}\" SET \"Username\" = @Username, \"Password\" = @Password, \"Type\" = @Type " +
                $"WHERE \"Id\" = '{user.Id}' RETURNING \"Id\";";
            long result = await _dataAccess.SaveDataQuery(PGQuery, user, _connectionString.SqlConnectionName);
            return true;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}
