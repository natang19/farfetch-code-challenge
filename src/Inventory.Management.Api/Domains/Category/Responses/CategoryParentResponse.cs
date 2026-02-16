namespace Inventory.Management.Api.Domains.Category.Responses;

/// <summary>
/// Represents the parent category in a hierarchy.
/// </summary>
public record CategoryParentResponse
{
    /// <summary>
    /// Unique identifier of the parent category.
    /// </summary>
    /// <example>987e6543-e21b-45d3-b654-123456789000</example>
    public required Guid Id { get; set; }

    /// <summary>
    /// Display name of the parent category.
    /// </summary>
    /// <example>Technologies</example>
    public required string Name { get; set; }

    /// <summary>
    /// Short code used to identify the parent category.
    /// </summary>
    /// <example>TECH</example>
    public required string Shortcut { get; set; }
}