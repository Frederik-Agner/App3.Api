using App3.Api.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace App3.Api.Controllers;

[Route("API/[controller]/[action]")]
[ApiController]
public class DataController : ControllerBase {
    private readonly IDataRepository _dataRepo;

    public DataController(IDataRepository dataRepo) {
        _dataRepo = dataRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetDataBySomething(string something) {
        try {
            return Ok();
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
