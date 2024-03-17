using System.ComponentModel.DataAnnotations;

namespace ShopperStopInReact_Shared.Model.Customer
{
    public class WishListItem
    {
        [Key]
        public int WishListItemID { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertedDate { get; set; }
        public bool IsRemoved { get; set; }
        public int Count { get; set; }

    }
}
