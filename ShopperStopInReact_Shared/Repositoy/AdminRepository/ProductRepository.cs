using ShopperStopInReact_Shared.DbContextData;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.Model.Admin;
using ShopperStopInReact_Shared.ViewModel.Admin;

namespace ShopperStopInReact_Shared.Repositoy.AdminRepository
{
    public class ProductRepository : IProductRepository
    {
        private ShoppingDbContext shoppingDbContext;
        public ProductRepository(ShoppingDbContext shoppingDbContext)
        {
            this.shoppingDbContext = shoppingDbContext;
        }
        public void AddProducts(ProductDetails product)
        {
            try
            {
                product.InsertedDate= DateTime.Now;
                shoppingDbContext.Product.Add(product);
                shoppingDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductViewModel GetProductByProductId(int productId)
        {
            ProductViewModel? productDetailViewModel = new ProductViewModel();
            try
            {
                productDetailViewModel = (from product in shoppingDbContext.Product
                                          join category in shoppingDbContext.Category
                                          on product.ProductId equals category.ProductId
                                          where product.ProductId == productId
                                          select new ProductViewModel()
                                          {
                                              ProductName = product.ProductName,
                                              Price = product.Price,
                                              Description = product.Description,
                                              Image = product.Image,
                                              InsertedDate = product.InsertedDate,
                                              CategoryName = category.CategoryName,
                                              SubCategoryName = category.SubCategoryName,
                                          }).FirstOrDefault();
                if (productDetailViewModel != null)
                {
                    return productDetailViewModel;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return productDetailViewModel;
        }

        public List<ProductDetails> GetProducts()
        {
            List<ProductDetails> products = new List<ProductDetails>();
            try
            {
                products = shoppingDbContext.Product.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        public ProductDetails GetProductsById(int productId)
        {
            ProductDetails productDetails = new ProductDetails();
            try
            {
                productDetails = shoppingDbContext.Product.Where(x => x.ProductId == productId).FirstOrDefault();
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return productDetails;
        }
    }
}
