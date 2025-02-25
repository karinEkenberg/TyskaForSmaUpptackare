namespace TyskaForSmaUpptackare.ViewModel
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public class CartItemViewModel
        {
            public int CartItemId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}