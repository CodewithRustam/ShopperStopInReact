using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ShopperStopInReact_Shared.ViewModel.Admin
{
    public class ProductListViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
        public decimal MaxPrice { get; set; }
        public string? Description { get; set; }
        public Image? Image { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
