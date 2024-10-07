using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IUserRepository {
    Task<List<User>> GetAllUsers();
    Task<long> RegisterNewUser(User user);
    Task<bool> UpdateUser(User user);
}
