namespace TyskaForSmaUpptackare.ViewModel
{
	public class OrderConfirmationViewModel
	{
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
    }

    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
