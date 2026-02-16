namespace Inventory.Management.Api.Domains.Category.Requests;

public record CategoryRequest
{
    public required string Name { get; init; }
    public required string Shortcut { get; init; }
    public Guid? CategoryParentId { get; init; }
};