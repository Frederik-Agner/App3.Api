using Microsoft.AspNetCore.Mvc;
using App3.Api.Data.Interface;
using App3.Api.Models;

namespace App3.Api.Controllers;

[Route("API/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IUserRepository _userRepo;

    public UserController(IUserRepository userRepo) {
        _userRepo = userRepo;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterNewUser(User user) {
        try {
            long Result = await _userRepo.RegisterNewUser(user);
            if (Result != 0) {
                return Ok(Result);
            }
            else {
                return NotFound();
            }
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
