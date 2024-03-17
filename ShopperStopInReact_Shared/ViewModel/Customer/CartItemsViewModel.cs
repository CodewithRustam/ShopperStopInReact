namespace ShopperStopInReact_Shared.ViewModel.Customer
{
    public class CartItemsViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertedDate { get; set; }
        public bool IsRemoved { get; set; }
        public int Count { get; set; }
    }
}
