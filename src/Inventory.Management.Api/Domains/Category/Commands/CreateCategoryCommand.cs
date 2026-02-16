using Inventory.Management.Api.Domains.Category.Requests;
using Inventory.Management.Api.Domains.Category.Responses;
using MediatR;

namespace Inventory.Management.Api.Domains.Category.Commands;

public record CreateCategoryCommand(CategoryRequest Request) : IRequest<CategoryResponse>;