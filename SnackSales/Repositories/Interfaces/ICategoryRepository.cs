using SnackSales.Models;

namespace SnackSales.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> Get(int id);
    IQueryable<Category> GetAll();
    Task<bool> Create(Category category);
    Task<bool> Delete(Category category);
}