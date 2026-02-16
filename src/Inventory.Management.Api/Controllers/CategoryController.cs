using System.Net.Mime;
using Inventory.Management.Api.Domains.Category.Commands;
using Inventory.Management.Api.Domains.Category.Requests;
using Inventory.Management.Api.Domains.Category.Responses;
using Inventory.Management.Api.Mappers;
using Inventory.Management.Api.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Inventory.Management.Api.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/category")]
public class CategoryController(ISender sender, ICategoryRepository categoryRepository) : ControllerBase
{
    /// <summary>
    /// Get all categories
    /// </summary>
    /// <response code="200">List of existing categories</response>
    /// <response code="500">internal error occurs during the get all categories request</response>
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> Get()
    {
        var result = await categoryRepository.GetAll();
        return Ok(result);
    }
    
    /// <summary>
    /// Get a category by its identifier
    /// </summary>
    /// <param name="id">Category unique identifier.</param>
    /// <response code="200">Category found and returned</response>
    /// <response code="404">Category not found</response>
    /// <response code="500">internal error occurs during the get request</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetById([FromRoute] Guid id)
    {
        var result = await categoryRepository.GetById(id);
        return result is null ? NotFound() : Ok(result.ToCategoryResponse());
    }
    
    /// <summary>
    /// Creates a new category
    /// </summary>
    /// <param name="category">Category data</param>
    /// <response code="201">Category successfully created</response>
    /// <response code="400">Invalid request data</response>
    /// <response code="500">internal error occurs during category creation</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CategoryRequest category)
    {
        var result = await sender.Send(new CreateCategoryCommand(category));
        
        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    /// <param name="id">Category identifier</param>
    /// <response code="204">Category successfully deleted</response>
    /// <response code="500">internal error occurs during category deletion</response>
    [HttpDelete("{id:guid}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await sender.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}