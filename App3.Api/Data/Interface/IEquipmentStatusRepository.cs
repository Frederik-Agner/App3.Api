using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IEquipmentStatusRepository {
    Task<List<EquipmentStatus>> GetByEquipmentId(long equipmentId);
    Task<List<EquipmentStatus>> GetByUserId(long userId);
    Task<List<EquipmentStatus>> GetAllOpenStatus();
    Task<long> RentEquipment(EquipmentStatus equipmentStatus);
    Task<bool> Update(EquipmentStatus equipmentStatus);
}
