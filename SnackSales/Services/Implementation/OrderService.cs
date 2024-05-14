using SnackSales.Models;
using SnackSales.Repositories.Interfaces;
using SnackSales.Services.Interfaces;

namespace SnackSales.Services.Implementation;

public class OrderService : IOrderService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IOrderItemRepository _itemOrderRepository;

    public OrderService(IOrderItemRepository itemOrderRepository, IHttpContextAccessor httpContextAccessor)
    {
        _itemOrderRepository = itemOrderRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<Order> GetOrCreateOrder()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var orderId = session.GetString("OrderId");

        if (string.IsNullOrEmpty(orderId))
        {
            orderId = Guid.NewGuid().ToString();
            session.SetString("OrderId", orderId);
        }

        return new Order { OrderId = Guid.Parse(orderId) };
    }
    
    public async Task AddItemToOrder(Snack snack)
    {
        var order = await GetOrCreateOrder();
        var orderItem = await _itemOrderRepository.GetItem(snack.SnackId, order.OrderId);

        if (orderItem == null)
        {
            orderItem = new OrderItem
            {
                OrderId = order.OrderId,
                Snack = snack,
                Quantity = 1
            };
            await _itemOrderRepository.Add(orderItem);
        }
        else
        {
            orderItem.Quantity++;
            await _itemOrderRepository.Update(orderItem);
        }
    }

    public async Task<int> RemoveItemToOrder(int snackId)
    {
        var order = await GetOrCreateOrder();
        var orderItem = await _itemOrderRepository.GetItem(snackId, order.OrderId);

        if (orderItem != null)
        {
            if (orderItem.Quantity > 1)
            {
                orderItem.Quantity--;
                await _itemOrderRepository.Update(orderItem);
                return orderItem.Quantity;
            }

            await _itemOrderRepository.Remove(orderItem);
            return 0;
        }

        return 0;
    }

    public async Task<IList<OrderItem>> GetOrderItems()
    {
        var order = await GetOrCreateOrder();
        return await _itemOrderRepository.GetItems(order.OrderId);
    }

    public async Task ClearOrder()
    {
        var order = await GetOrCreateOrder();
        var items = await _itemOrderRepository.GetItems(order.OrderId);
        await _itemOrderRepository.RemoveItems(items);
    }

    public async Task<decimal> GetTotalOrder()
    {
        var order = await GetOrCreateOrder();
        var items = await _itemOrderRepository.GetItems(order.OrderId);
        var total = items.Sum(i => i.Quantity * i.Snack.Price);

        return total;
    }
}