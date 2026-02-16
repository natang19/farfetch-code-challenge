using MediatR;

namespace Inventory.Management.Api.Domains.Category.Commands;

public record DeleteCategoryCommand(Guid CategoryId) : IRequest;