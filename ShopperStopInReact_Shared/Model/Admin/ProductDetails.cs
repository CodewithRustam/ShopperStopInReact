using System.ComponentModel.DataAnnotations;

namespace ShopperStopInReact_Shared.Model.Admin
{
    public class ProductDetails
    {
        [Key]
        public int ProductId { get; set; }
        public string? Brand { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal MaxPrice { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public DateTime InsertedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
