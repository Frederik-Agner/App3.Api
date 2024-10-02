using App3.Api.Data.Interface;
using App3.Api.Data.DB;
using App3.Api.Models;

namespace App3.Api.Data.Repository;

public class UserRepository : IUserRepository {
    private readonly DataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;

    public async Task<long> RegisterNewUser(User user) {
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
}
