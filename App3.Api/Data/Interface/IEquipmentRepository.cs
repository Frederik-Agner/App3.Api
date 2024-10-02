using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IEquipmentRepository {
    Task<List<Equipment>> GetAllEquipment();
    Task<long> RegisterNewEquipment(Equipment equipment);
}
