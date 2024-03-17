using Microsoft.AspNetCore.Mvc;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.Maper;
using ShopperStopInReact_Shared.Model.Admin;
using ShopperStopInReact_Shared.ViewModel.Admin;

namespace ShopperStop.Server.Controllers.Admin
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _IPrductrepository;
        private readonly ICategoryRepository _ICategoryrepository;
        public ProductController(IProductRepository _IPrductrepository, ICategoryRepository _ICategoryrepository)
        {
            this._IPrductrepository = _IPrductrepository;
            this._ICategoryrepository = _ICategoryrepository;
        }
        [HttpPost]
        public IActionResult AddProducts(ProductViewModel productViewModel)
        {
            try
            {
                ProductDetails productDetails = new ProductDetails();
                productDetails.InsertedDate = DateTime.Now;
                Category category = new Category();
                if (productViewModel != null)
                {
                    //Saving Data in Product Table
                    MappingProfile.MapObjectData(productViewModel, productDetails);
                    _IPrductrepository.AddProducts(productDetails);

                    //Saving Data in Category Table
                    MappingProfile.MapObjectData(productViewModel, category);
                    category.ProductId = productDetails.ProductId;
                    _ICategoryrepository.AddProductCategory(category);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult ProductsGet()
        {
            List<ProductDetails>? products = null;
            try
            {
                products = _IPrductrepository.GetProducts();


                if (products != null)
                {
                    return Ok(products);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetProductByProductId(int ProductId)
        {
            try
            {
                ProductViewModel productViewModel = _IPrductrepository.GetProductByProductId(ProductId);
                if (productViewModel != null)
                {
                    return Ok(productViewModel);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
    }
}
