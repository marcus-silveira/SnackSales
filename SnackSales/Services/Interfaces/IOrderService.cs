using SnackSales.Models;

namespace SnackSales.Services.Interfaces;

public interface IOrderService
{
	Task<Order> GetOrCreateOrder();
	Task AddItemToOrder(Snack snack);
	Task<int> RemoveItemToOrder(int snackId);
	Task<IList<OrderItem>> GetOrderItems();
	Task ClearOrder();
	Task<Decimal> GetTotalOrder();
}