using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IEquipmentRepository {
    Task<List<Equipment>> GetAll();
    Task<long> Register(Equipment equipment);
    Task<bool> Update(Equipment equipment);
}
