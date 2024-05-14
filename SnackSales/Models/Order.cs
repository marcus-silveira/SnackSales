using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackSales.Models;

public class Order
{
	public Guid OrderId { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
	public DateTime OrderDate { get; set; }

	[Column(TypeName = "decimal(10,2)")]
	public decimal TotalPrice { get; set; }
	public string ShippingAddress { get; set; }

	public IList<OrderItem> OrderItems { get; set; }
	//public Payment PaymentMethod { get; set; }
	//public Status OrderStatus { get; set; }
}