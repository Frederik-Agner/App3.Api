using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IEquipmentStatusRepository {
    Task<List<EquipmentStatus>> GetEquipmentStatusByEquipmentId(long equipmentId);
    Task<List<EquipmentStatus>> GetEquipmentStatusByUserId(long userId);
    Task<List<EquipmentStatus>> GetAllOpenStatus();
    Task<long> RentEquipment(EquipmentStatus equipmentStatus);
    Task<bool> UpdateEquipmentStatus(EquipmentStatus equipmentStatus);
}
