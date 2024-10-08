using Microsoft.AspNetCore.Mvc;
using App3.Api.Data.Interface;
using App3.Api.Models;

namespace App3.Api.Controllers;

[Route("API/[controller]/[action]")]
[ApiController]
public class EquipmentController : ControllerBase {
    private readonly IEquipmentRepository _equipRepo;

    public EquipmentController(IEquipmentRepository equipRepo) {
        _equipRepo = equipRepo;
    }

    [HttpGet]
    public IActionResult TestConnection() {
        return Ok("A Connection has been made");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try {
            List<Equipment> Result = await _equipRepo.GetAll();
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
    public async Task<IActionResult> Register(Equipment equipment) {
        try {
            long Result = await _equipRepo.Register(equipment);
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
    public async Task<IActionResult> Update([FromBody] Equipment equipment) {
        try {
            bool Result = await _equipRepo.Update(equipment);
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
