﻿using Microsoft.AspNetCore.Mvc;
using App3.Api.Data.Interface;
using App3.Api.Models;

namespace App3.Api.Controllers;

[Route("API/[controller]/[action]")]
[ApiController]
public class EquipmentStatusController : ControllerBase {
    private readonly IEquipmentStatusRepository _equipStatusRepo;

    public EquipmentStatusController(IEquipmentStatusRepository equipStatusRepo) {
        _equipStatusRepo = equipStatusRepo;
    }    

    [HttpGet]
    public async Task<IActionResult> GetByEquipmentId(long equipmentId) {
        try {
            List<EquipmentStatus> Result = await _equipStatusRepo.GetByEquipmentId(equipmentId);
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

    [HttpGet]
    public async Task<IActionResult> GetByUserId(long userId) {
        try {
            List<EquipmentStatus> Result = await _equipStatusRepo.GetByUserId(userId);
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

    [HttpGet]
    public async Task<IActionResult> GetAllOpenStatus() {
        try {
            List<EquipmentStatus> Result = await _equipStatusRepo.GetAllOpenStatus();
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

    [HttpPut]
    public async Task<IActionResult> Update(EquipmentStatus equipmentStatus) {
        try {
            bool Result = await _equipStatusRepo.Update(equipmentStatus);
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
