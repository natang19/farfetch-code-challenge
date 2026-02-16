using Inventory.Management.Api.Domains.Category.Commands;
using Inventory.Management.Api.Domains.Category.Responses;
using Inventory.Management.Api.Mappers;
using Inventory.Management.Api.Repositories;
using MediatR;

namespace Inventory.Management.Api.Domains.Category.Handlers;

public class CreateCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(
        CreateCategoryCommand command,
        CancellationToken ct)
    {
        Category? categoryParent = null;

        if (command.Request.CategoryParentId is not null)
        {
            categoryParent = await categoryRepository.GetById(command.Request.CategoryParentId.Value);

            if (categoryParent is null)
                throw new InvalidOperationException("Category parent not found");
        }

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = command.Request.Name,
            Shortcut = command.Request.Shortcut,
            CategoryParent = categoryParent
        };

        if (!await categoryRepository.Add(category))
        {
            throw new InvalidOperationException("Error creating category");
        };

        return category.ToCategoryResponse();
    }
}