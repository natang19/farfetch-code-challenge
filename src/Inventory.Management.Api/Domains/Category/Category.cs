using Microsoft.AspNetCore.Mvc;

namespace Inventory.Management.Api.Domains.Category;

[ApiExplorerSettings(IgnoreApi = true)]
public class Category
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Shortcut { get; set; }
    public Category? CategoryParent { get; set; }
}