using Microsoft.EntityFrameworkCore;
using SnackSales.Context;
using SnackSales.Models;
using SnackSales.Repositories.Interfaces;
using SnackSales.Services.Implementation;

namespace SnackSales.Repositories.Implementation;

public class OrderItemRepository : IOrderItemRepository
{
	private readonly AppDbContext _dbContext;

	public OrderItemRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<OrderItem?> GetItem(int snackId, Guid orderId)
	{
		return await _dbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderId == orderId && o.SnackID == snackId);
	}

	public async Task<IList<OrderItem>> GetItems(Guid orderId)
	{
		return await _dbContext.OrderItems.Where(o => o.OrderId == orderId)
			.Include(s => s.Snack).ToListAsync();
	}

	public async Task<OrderItem> Add(OrderItem item)
	{
		await _dbContext.OrderItems.AddAsync(item);
		await _dbContext.SaveChangesAsync();
		return item;
	}

	public async Task<bool> Update(OrderItem item)
	{
		var existingItem = await _dbContext.FindAsync<OrderItem>(item.OrderItemId);
		if (existingItem != null)
		{
			_dbContext.Attach(item);
			_dbContext.Entry(item).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return true;
		}
		return false;
	}

	public async Task<bool> Remove(OrderItem item)
	{ 
		try
		{
			_dbContext.Remove(item);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			return false;
		}
	}

	public async Task<bool> RemoveItems(IList<OrderItem> items)
	{
		try
		{
			_dbContext.RemoveRange(items);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			return false;
		}	
	}
}