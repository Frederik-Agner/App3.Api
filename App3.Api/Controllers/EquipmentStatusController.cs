using App3.Api.Data.Interface;
using App3.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace App3.Api.Controllers;

[Route("API/[controller]/[action]")]
[ApiController]
public class EquipmentStatusController : ControllerBase {
    private readonly IEquipmentStatusRepository _equipStatusRepo;

    public EquipmentStatusController(IEquipmentStatusRepository equipStatusRepo) {
        _equipStatusRepo = equipStatusRepo;
    }

    [HttpPost]
    public async Task<IActionResult> RentEquipment(EquipmentStatus equipmentStatus) {
        try {
            long Result = await _equipStatusRepo.RentEquipment(equipmentStatus);
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
