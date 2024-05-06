using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Models;
using PharmacyDB.Services;

namespace PharmacyDB.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private ImyService _service;
    
    public MyController(ImyService service)
    {
        _service = service;
    }

    /// <summary>
    /// Endpoints used to Get Doctor detsiles and their list of perscritions.
    /// </summary>
    /// <returns>doctor info and list of perscriptions</returns>

    [HttpGet("/api/doctors/{idDoctor:int}")]
    public async Task<IActionResult> GetDoctor(int idDoctor)
    {
        var a = await _service.GetDoctorPerscriptionsAsync(idDoctor);
        Console.WriteLine("Read");
        if (a == null)
        {
            return BadRequest();
        }
        return Ok(a);
    }
    
    /// <summary>
    /// Endpoints used to Get Doctor detsiles and their list of perscritions.
    /// </summary>
    /// <returns>doctor info and list of perscriptions</returns>

    [HttpDelete("/api/doctors/{idDoctor:int}")]
    public async Task<IActionResult> DeleteDoctor(int idDoctor)
    {
        var a = await _service.DeleteDoctor(idDoctor);
        return Ok($"{a} rows effected");
    }

    

    
}