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
    public async Task<IActionResult> GetAllEquipment() {
        try {
            return Ok();
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> RegisterNewEquipment(Equipment equipment) {
        try {
            return Ok();
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
