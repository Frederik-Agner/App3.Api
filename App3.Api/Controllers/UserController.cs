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
    public async Task<IActionResult> GetAll() {
        try {
            List<User> Result = await _userRepo.GetAll();
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
    public async Task<IActionResult> Register(User user) {
        try {
            long Result = await _userRepo.Register(user);
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
    public async Task<IActionResult> Update([FromBody] User user) {
        try {
            bool Result = await _userRepo.Update(user);
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
