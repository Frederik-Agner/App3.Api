using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IEquipmentStatusRepository {
    Task<List<Equipment>> GetEquipmentStatusByEquipmentId(long equipmentId);
    Task<List<Equipment>> GetEquipmentStatusByUserId(long userId);
    Task<long> RentEquipment(EquipmentStatus equipmentStatus);
}
