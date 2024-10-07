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
    public async Task<IActionResult> GetAllEquipment() {
        try {
            List<Equipment> Result = await _equipRepo.GetAllEquipment();
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
    public async Task<IActionResult> RegisterNewEquipment(Equipment equipment) {
        try {
            long Result = await _equipRepo.RegisterNewEquipment(equipment);
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
    public async Task<IActionResult> UpdateEquipment([FromBody] Equipment equipment) {
        try {
            bool Result = await _equipRepo.UpdateEquipment(equipment);
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
