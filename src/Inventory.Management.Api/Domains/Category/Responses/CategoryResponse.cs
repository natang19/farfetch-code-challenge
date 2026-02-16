namespace Inventory.Management.Api.Domains.Category.Responses;

/// <summary>
/// Represents a product category.
/// </summary>
public record CategoryResponse
{
    /// <summary>
    /// Unique identifier of the category.
    /// </summary>
    /// <example>123e4567-e89b-12d3-a456-426614174000</example>
    public required Guid Id { get; set; }

    /// <summary>
    /// Display name of the category.
    /// </summary>
    /// <example>Electronics</example>
    public required string Name { get; set; }

    /// <summary>
    /// Short code used to identify the category.
    /// </summary>
    /// <example>ELEC</example>
    public required string Shortcut { get; set; }

    /// <summary>
    /// Parent category when this category is part of a hierarchy.
    /// Null when it is a root category.
    /// </summary>
    public CategoryParentResponse? CategoryParent { get; set; }
}