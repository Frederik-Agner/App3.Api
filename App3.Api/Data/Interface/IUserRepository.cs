using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IUserRepository {
    Task<List<User>> GetAll();
    Task<long> Register(User user);
    Task<bool> Update(User user);
}
