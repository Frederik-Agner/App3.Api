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

    public async Task<List<EquipmentStatus>> GetByEquipmentId(long equipmentId) {
        try {
            string tableName = "EquipmentStatus";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\" WHERE \"EquipmentId\" = '{equipmentId}' AND \"Closed\" is null";
            List<EquipmentStatus> result = await _dataAccess.LoadDataQuery<EquipmentStatus, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result.Count > 0) return result;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public async Task<List<EquipmentStatus>> GetByUserId(long userId) {
        try {
            string tableName = "EquipmentStatus";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\" WHERE \"UserId\" = '{userId}'";
            List<EquipmentStatus> result = await _dataAccess.LoadDataQuery<EquipmentStatus, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result.Count > 0) return result;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null;
    }

    public async Task<List<EquipmentStatus>> GetAllOpenStatus() {
        try {
            string tableName = "EquipmentStatus";
            string PGQuery =
                $"SELECT * FROM \"{tableName}\" WHERE \"Closed\" is null";
            List<EquipmentStatus> result = await _dataAccess.LoadDataQuery<EquipmentStatus, dynamic>(PGQuery, _connectionString.SqlConnectionName);
            if (result != null) return result;
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
                $"INSERT INTO public.\"{tableName}\" (\"Date\", \"ReturnDate\", \"Status\", \"EquipmentId\", \"UserId\", \"Closed\") " +
                $"VALUES (@Date, @ReturnDate, @Status, @EquipmentId, @UserId, @Closed) " +
                "RETURNING \"Id\";";
            equipmentStatus.Id = await _dataAccess.SaveDataQuery(PGQuery, equipmentStatus, _connectionString.SqlConnectionName);
            return equipmentStatus.Id;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return 0;
        }
    }

    public async Task<bool> Update(EquipmentStatus equipmentStatus) {
        try {
            string tableName = "EquipmentStatus";
            string PGQuery =
                $"UPDATE \"{tableName}\" SET \"ReturnDate\" = @ReturnDate, \"Status\" = @Status, \"Closed\" = @Closed " +
                $"WHERE \"Id\" = '{equipmentStatus.Id}' RETURNING \"Id\";";
            long result = await _dataAccess.SaveDataQuery(PGQuery, equipmentStatus, _connectionString.SqlConnectionName);
            return true;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}
