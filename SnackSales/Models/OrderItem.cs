using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackSales.Models;

public class OrderItem
{
	public int OrderItemId { get; set; }
	public Guid OrderId { get; set; }
	public Order Order { get; set; }
	public int SnackID { get; set; }
	public Snack Snack { get; set; }

	public int Quantity { get; set; }
	[Column(TypeName = "decimal(10,2)")]
	public decimal UnitPrice { get; set; }
}