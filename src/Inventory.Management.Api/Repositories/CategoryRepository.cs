using System.Collections.Concurrent;
using Inventory.Management.Api.Domains.Category;

namespace Inventory.Management.Api.Repositories;

public interface ICategoryRepository
{
    Task<IQueryable<Category>> GetAll();
    Task<Category?> GetById(Guid id);
    Task<bool> Add(Category category);
    Task<bool> Delete(Guid id);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly ConcurrentDictionary<Guid, Category> _categoriesDbSet = new();
    
    public Task<IQueryable<Category>> GetAll()
    {
        return Task.FromResult(_categoriesDbSet.Values.AsQueryable());
    }
    
    public Task<Category?> GetById(Guid id)
    {
        _categoriesDbSet.TryGetValue(id, out var category);
        return Task.FromResult(category);
    }
    
    public Task<bool> Add(Category category)
    {
        return Task.FromResult(_categoriesDbSet.TryAdd(category.Id, category));
    }
    
    public Task<bool> Delete(Guid id)
    {
        if (_categoriesDbSet.ContainsKey(id))
        {
            return Task.FromResult(_categoriesDbSet.TryRemove(id, out _));    
        }
        
        return Task.FromResult(true);
    }
}