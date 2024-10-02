using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IEquipmentStatusRepository {
    Task<long> RentEquipment(EquipmentStatus equipmentStatus);
}
