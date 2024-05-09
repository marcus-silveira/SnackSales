using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SnackSales.Context;
using SnackSales.Models;
using SnackSales.Repositories.Interfaces;

namespace SnackSales.Repositories.Implementation;

public class SnackRepository : ISnackRepository
{
    private readonly AppDbContext _dbContext;

    public SnackRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Snack?> Get(Expression<Func<Snack, bool>> expression)
    {
        return await _dbContext.Snacks.FirstOrDefaultAsync(expression);
    }

    public IQueryable<Snack> GetAll()
    {
        return _dbContext.Snacks;
    }

    public async Task<bool> Create(Snack snack)
    {
        try
        {
            await _dbContext.Snacks.AddAsync(snack);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(Snack snack)
    {
        try
        {
            _dbContext.Snacks.Remove(snack);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}