using Inventory.Management.Api.Domains.Category.Commands;
using Inventory.Management.Api.Repositories;
using MediatR;

namespace Inventory.Management.Api.Domains.Category.Handlers;

public class DeleteCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(
        DeleteCategoryCommand command,
        CancellationToken ct)
    {
        await categoryRepository.Delete(command.CategoryId);
    }
}