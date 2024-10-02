using App3.Api.Data.Interface;
using App3.Api.Data.DB;
using App3.Api.Models;

namespace App3.Api.Data.Repository;

public class EquipmentRepository : IEquipmentRepository {
    private readonly DataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;

    public async Task<List<Equipment>> GetAllEquipment() {
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

    public async Task<long> RegisterNewEquipment(Equipment equipment) {
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
}
