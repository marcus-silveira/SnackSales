using System.Linq.Expressions;
using SnackSales.Models;

namespace SnackSales.Repositories.Interfaces;

public interface ISnackRepository
{
    Task<Snack?> Get(Expression<Func<Snack,bool>> expression);
    IQueryable<Snack> GetAll();
    Task<bool> Create(Snack snack);
    Task<bool> Delete(Snack snack);
}