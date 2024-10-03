using App3.Api.Data.Interface;
using App3.Api.Data.DB;
using App3.Api.Models;

namespace App3.Api.Data.Repository;

public class EquipmentStatusRepository : IEquipmentStatusRepository {
    private readonly DataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;

    public EquipmentStatusRepository(DataAccess dataAccess, ConnectionStringData connectionString) {
        _dataAccess = dataAccess;
        _connectionString = connectionString;
    }

    public async Task<List<Equipment>> GetEquipmentStatusByEquipmentId(long equipmentId) {
        try {
            string tableName = "Equipment";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\" WHERE \"EquipmentId\" = '{equipmentId}'";
            List<Equipment> result = await _dataAccess.LoadDataQuery<Equipment, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result.Count > 0) return result;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public async Task<List<Equipment>> GetEquipmentStatusByUserId(long userId) {
        try {
            string tableName = "Equipment";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\" WHERE \"UserId\" = '{userId}'";
            List<Equipment> result = await _dataAccess.LoadDataQuery<Equipment, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result.Count > 0) return result;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public async Task<long> RentEquipment(EquipmentStatus equipmentStatus) {
        try {
            string tableName = "EquipmentStatus";
            string PGQuery =
                $"INSERT INTO public.\"{tableName}\" (\"Date\", \"ReturnDate\", \"Status\", \"EquipmentId\", \"UserId\") " +
                $"VALUES (@Date, @ReturnDate, @Status, @EquipmentId, @UserId) " +
                "RETURNING \"Id\";";
            equipmentStatus.Id = await _dataAccess.SaveDataQuery(PGQuery, equipmentStatus, _connectionString.SqlConnectionName);
            return equipmentStatus.Id;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return 0;
        }
    }
}
