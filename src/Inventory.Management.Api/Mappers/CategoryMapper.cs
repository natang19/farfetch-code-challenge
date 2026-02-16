using Inventory.Management.Api.Domains.Category;
using Inventory.Management.Api.Domains.Category.Responses;

namespace Inventory.Management.Api.Mappers;

public static class CategoryMapper
{
    public static IQueryable<CategoryResponse> ToCategoryResponse(this IQueryable<Category> categories)
    {
        return categories.Select(c => c.ToCategoryResponse());
    }
    
    public static CategoryResponse ToCategoryResponse(this Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Shortcut = category.Shortcut,
            CategoryParent = category.CategoryParent.ToCategoryParentResponse()
        };
    }
    
    private static CategoryParentResponse? ToCategoryParentResponse(this Category? categoryParent)
    {
        return categoryParent is null ? null : new CategoryParentResponse
        {
            Id = categoryParent.Id,
            Name = categoryParent.Name,
            Shortcut = categoryParent.Shortcut
        };
    }
}