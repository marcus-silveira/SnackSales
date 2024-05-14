using Microsoft.EntityFrameworkCore;
using SnackSales.Context;
using SnackSales.Models;
using SnackSales.Repositories.Interfaces;

namespace SnackSales.Repositories.Implementation;

public class OrderRepository : IOrderRepository
{
	private readonly AppDbContext _dbContext;

	public OrderRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public  IQueryable<Order> Get()
	{
		return _dbContext.Orders;
	}

	public async Task<bool> Save(Order order)
	{
		try
		{
			await _dbContext.Orders.AddAsync(order);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			return false;
		}
	}

	public async Task<Order> Update(Order order)
	{
		_dbContext.Update(order);
		await _dbContext.SaveChangesAsync();
		return order;
	}
}