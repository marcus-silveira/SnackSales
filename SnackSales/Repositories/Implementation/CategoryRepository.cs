using Microsoft.EntityFrameworkCore;
using SnackSales.Context;
using SnackSales.Models;
using SnackSales.Repositories.Interfaces;

namespace SnackSales.Repositories.Implementation;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category?> Get(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync();
    }

    public IQueryable<Category> GetAll()
    {
        return _dbContext.Categories;   
    }

    public async Task<bool> Create(Category category)
    {
        try
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(Category category)
    {
        try
        {
             _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}