using Microsoft.AspNetCore.Mvc;

namespace Inventory.Management.Api.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{

    /// <summary>
    /// Gell all categories
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetCategories")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        return Ok();
    }
}