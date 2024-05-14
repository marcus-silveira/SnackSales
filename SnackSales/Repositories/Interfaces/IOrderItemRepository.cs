using SnackSales.Models;
using SnackSales.Services.Implementation;

namespace SnackSales.Repositories.Interfaces;

public interface IOrderItemRepository
{
	Task<OrderItem?> GetItem(int snackId, Guid orderId);
	Task<IList<OrderItem>> GetItems(Guid orderId);
	Task<OrderItem> Add(OrderItem item);
	Task<bool> Update(OrderItem item);
	Task<bool> Remove(OrderItem item);
	Task<bool> RemoveItems(IList<OrderItem> items);

}