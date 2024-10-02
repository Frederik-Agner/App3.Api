using App3.Api.Data.Interface;
using App3.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
            return Ok();
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
