using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopperStopInReact_Shared.Model.Admin;
using ShopperStopInReact_Shared.ViewModel.Admin;

namespace ShopperStopInReact_Shared.IRepository.IAdminRepository
{
    public interface IProductRepository
    {
        void AddProducts(ProductDetails product);
        List<ProductDetails> GetProducts();
        ProductDetails GetProductsById(int productId);
        ProductViewModel GetProductByProductId(int productId);

    }
}
