using App3.Api.Data.Interface;
using App3.Api.Data.DB;
using App3.Api.Models;

namespace App3.Api.Data.Repository;

public class EquipmentRepository : IEquipmentRepository {
    private readonly DataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;

    public EquipmentRepository(DataAccess dataAccess, ConnectionStringData connectionString) {
        _dataAccess = dataAccess;
        _connectionString = connectionString;
    }

    public async Task<List<Equipment>> GetAll() {
        try {
            string tableName = "Equipment";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\"";
            List<Equipment> result = await _dataAccess.LoadDataQuery<Equipment, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result.Count > 0) return result;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public async Task<long> Register(Equipment equipment) {
        try {
            string tableName = "Equipment";
            string PGQuery =
                $"INSERT INTO public.\"{tableName}\" (\"Name\", \"RetireDate\") " +
                $"VALUES (@Name, @RetireDate) " +
                "RETURNING \"Id\";";
            equipment.Id = await _dataAccess.SaveDataQuery(PGQuery, equipment, _connectionString.SqlConnectionName);
            return equipment.Id;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return 0;
        }
    }

    public async Task<bool> Update(Equipment equipment) {
        try {
            string tableName = "Equipment";
            string PGQuery =
                $"UPDATE \"{tableName}\" SET \"Name\" = @Name, \"RetireDate\" = @RetireDate " +
                $"WHERE \"Id\" = '{equipment.Id}' RETURNING \"Id\";";
            long result = await _dataAccess.SaveDataQuery(PGQuery, equipment, _connectionString.SqlConnectionName);
            return true;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}
