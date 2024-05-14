using SnackSales.Models;

namespace SnackSales.Repositories.Interfaces;

public interface IOrderRepository
{
	IQueryable<Order> Get();
	Task<bool> Save(Order order);
	Task<Order> Update(Order order);
}