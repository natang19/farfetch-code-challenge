using Microsoft.AspNetCore.Mvc;

namespace Inventory.Management.Api.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{

    [HttpGet(Name = "GetCategories")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        return Ok();
    }
}