using Microsoft.AspNetCore.Mvc;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.IRepository.ICustomerRepository;
using ShopperStopInReact_Shared.Maper;
using ShopperStopInReact_Shared.Model.Admin;
using ShopperStopInReact_Shared.Model.Customer;
using ShopperStopInReact_Shared.ViewModel.Customer;

namespace ShopperStopInReact.Server.Controllers.Customer
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {
        private readonly ICartAndWishListRepository _IAddtoCartRepository;
        private readonly IProductRepository _IProductRepository;
        public AddToCartController(ICartAndWishListRepository _IAddtoCartRepository, IProductRepository _IProductRepository)
        {
            this._IAddtoCartRepository = _IAddtoCartRepository;
            this._IProductRepository = _IProductRepository;
        }
        [HttpGet]
        public IActionResult AddToCart(int ProductId, int UserId)
        {
            try
            {
                CartItems addToCartItems = new CartItems();
                ProductDetails products = _IProductRepository.GetProductsById(ProductId);
                if (products != null)
                {
                    CartItems cartItem = _IAddtoCartRepository.GetCartItemsById(ProductId);
                    if (cartItem != null && cartItem.AddToCartItemsID > 0)
                    {
                        cartItem.Count = cartItem.Count + 1;
                        cartItem.Price = cartItem.Price + products.Price;
                        _IAddtoCartRepository.UpdateCartItems(cartItem);
                        return Ok();
                    }
                    else
                    {
                        MappingProfile.MapObjectData(products, addToCartItems);
                        addToCartItems.Count = 1;
                        addToCartItems.InsertedDate = DateTime.Now;
                        addToCartItems.UserId = UserId;
                        _IAddtoCartRepository.AddCartItems(addToCartItems);
                        return Ok();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetCartItems()
        {
            List<CartItemsViewModel> cartItems = new List<CartItemsViewModel>();
            try
            {
                cartItems = _IAddtoCartRepository.GetCartItems();

                if (cartItems.Count > 0)
                {
                    return Ok(cartItems);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest("No Added Cart Items Found");
        }
        [HttpGet]
        public IActionResult GetCartCount()
        {
            int? count = 0;
            try
            {
                count = _IAddtoCartRepository.GetCartCount();
                return Ok(count);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult IncreamentCartCount(int ProductId)
        {
            try
            {
                CartItems addToCartItems = new CartItems();
                ProductDetails products = _IProductRepository.GetProductsById(ProductId);
                if (products != null)
                {
                    CartItems cartItem = _IAddtoCartRepository.GetCartItemsById(ProductId);
                    if (cartItem != null && cartItem.AddToCartItemsID > 0)
                    {
                        cartItem.Count = cartItem.Count + 1;
                        cartItem.Price = cartItem.Price + products.Price;
                        _IAddtoCartRepository.UpdateCartItems(cartItem);
                        return Ok(_IAddtoCartRepository.GetItemCountOfProduct(ProductId));
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult DecreamentCartCount(int ProductId)
        {
            try
            {
                CartItems addToCartItems = new CartItems();
                ProductDetails products = _IProductRepository.GetProductsById(ProductId);
                if (products != null)
                {
                    CartItems cartItem = _IAddtoCartRepository.GetCartItemsById(ProductId);
                    if (cartItem != null && cartItem.AddToCartItemsID > 0)
                    {
                        cartItem.Count = cartItem.Count - 1;
                        cartItem.Price -= products.Price;
                        _IAddtoCartRepository.UpdateCartItems(cartItem);
                        return Ok(_IAddtoCartRepository.GetItemCountOfProduct(ProductId));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult RemoveFromCart(int ProductId)
        {
            try
            {
                bool flag = _IAddtoCartRepository.RemoveItemFromCart(ProductId);
                if (flag)
                    return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult AddWishListItem(int ProductId, int UserId)
        {
            try
            {
                WishListItem wishListItem = new WishListItem();
                ProductDetails products = _IProductRepository.GetProductsById(ProductId);
                if (products != null)
                {
                    WishListItem wishItem = _IAddtoCartRepository.GetWishListItemsById(ProductId);
                    if (wishItem != null && wishItem.WishListItemID > 0)
                    {
                        return Ok("Product Already in WishList !!");
                    }
                    else
                    {
                        MappingProfile.MapObjectData(products, wishListItem);
                        wishListItem.Count = 1;
                        wishListItem.InsertedDate = DateTime.Now;
                        wishListItem.UserId = UserId;
                        bool flag = _IAddtoCartRepository.AddItemToWishList(wishListItem);
                        if (flag)
                            return Ok();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetWishListItems()
        {
            try
            {
                List<WishListItemsViewModel> wishListItemsViewModel = _IAddtoCartRepository.GetWishListItems();
                if (wishListItemsViewModel.Count > 0)
                    return Ok(wishListItemsViewModel);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult RemoveWishListItem(int ProductId)
        {
            try
            {
                bool flag = _IAddtoCartRepository.RemoveWishListItem(ProductId);
                if (flag)
                    return Ok();
            }
            catch (Exception)
            {
                throw;
            }
            return BadRequest();
        }
    }

}
