using Microsoft.AspNetCore.Mvc;
using App3.Api.Data.Interface;
using App3.Api.Models;
using System.Formats.Asn1;

namespace App3.Api.Controllers;

[Route("API/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IUserRepository _userRepo;

    public UserController(IUserRepository userRepo) {
        _userRepo = userRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers() {
        try {
            List<User> Result = await _userRepo.GetAllUsers();
            if (Result != null) {
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

    [HttpPut]
    public async Task<IActionResult> ChangeUserRoles([FromBody] User user) {
        try {
            bool Result = await _userRepo.UpdateUser(user);
            if (Result) {
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
