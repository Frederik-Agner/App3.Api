using App3.Api.Models;

namespace App3.Api.Data.Interface;

public interface IUserRepository {
    Task<long> RegisterNewUser(User user);
}
