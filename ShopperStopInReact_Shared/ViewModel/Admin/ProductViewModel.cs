namespace ShopperStopInReact_Shared.ViewModel.Admin
{
    public class ProductViewModel
    {
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
        public decimal MaxPrice { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
    }
}
