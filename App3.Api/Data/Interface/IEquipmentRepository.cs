namespace App3.Api.Data.Interface;

public interface IEquipmentRepository {
    Task<List<object>> GetAllEquipment();
}
