using ShopperStopInReact_Shared.DbContextData;
using ShopperStopInReact_Shared.IRepository.ICustomerRepository;
using ShopperStopInReact_Shared.Model.Customer;
using ShopperStopInReact_Shared.ViewModel.Customer;

namespace ShopperStopInReact_Shared.Repositoy.CustomerRepository
{
    public class CartAndWishListRepository : ICartAndWishListRepository
    {
        private readonly ShoppingDbContext _DbContext;
        public CartAndWishListRepository(ShoppingDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }
        public void AddCartItems(CartItems addToCartItems)
        {
            try
            {
                _DbContext.CartItems?.Add(addToCartItems);
                _DbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? GetCartCount()
        {
            int? count = 0;
            try
            {
                count = _DbContext.CartItems?.ToList().Count;
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public List<CartItemsViewModel> GetCartItems()
        {
            List<CartItemsViewModel>? cartItems = new List<CartItemsViewModel>();
            try
            {
                cartItems = (from product in _DbContext.Product
                             join cartItem in _DbContext.CartItems
                             on product.ProductId equals cartItem.ProductId
                             where cartItem.ProductId > 0 && cartItem.IsRemoved == false
                             select new CartItemsViewModel()
                             {
                                 ProductName = product.ProductName,
                                 Description = product.Description,
                                 Image = product.Image,
                                 Price = cartItem.Price,
                                 InsertedDate = cartItem.InsertedDate,
                                 IsRemoved = cartItem.IsRemoved,
                                 Count = cartItem.Count,
                                 ProductId = product.ProductId,
                             }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return cartItems;
        }

        public CartItems GetCartItemsById(int productId)
        {
            CartItems? addToCartItems = new CartItems();
            try
            {
                addToCartItems = _DbContext.CartItems?.Where(x => x.ProductId == productId && x.IsRemoved != true).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return addToCartItems;
        }

        public bool RemoveItemFromCart(int ProductId)
        {
            try
            {
                CartItems addToCartItems = _DbContext.CartItems?.Where(x => x.ProductId == ProductId && x.IsRemoved != true).FirstOrDefault();
                if (addToCartItems != null)
                {
                    addToCartItems.IsRemoved = true;
                    _DbContext.CartItems.Update(addToCartItems);
                    _DbContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public void UpdateCartItems(CartItems addToCartItems)
        {
            try
            {
                _DbContext.CartItems.Update(addToCartItems);
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            };
        }
        public int GetItemCountOfProduct(int productId)
        {
            int count = 0;
            try
            {
                count = _DbContext.CartItems.Where(x => x.ProductId == productId && x.IsRemoved == false).Select(x => x.Count).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public bool AddItemToWishList(WishListItem wishListItem)
        {
            try
            {
                _DbContext.WishListItem.Add(wishListItem);
                int count = _DbContext.SaveChanges();
                if (count > 0)
                    return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public List<WishListItemsViewModel> GetWishListItems()
        {
            List<WishListItemsViewModel>? wishListItems = new List<WishListItemsViewModel>();
            try
            {
                wishListItems = (from product in _DbContext.Product
                                 join wishList in _DbContext.WishListItem
                                 on product.ProductId equals wishList.ProductId
                                 where wishList.ProductId > 0 && wishList.IsRemoved == false
                                 select new WishListItemsViewModel()
                                 {
                                     ProductName = product.ProductName,
                                     Description = product.Description,
                                     Image = product.Image,
                                     Price = wishList.Price,
                                     InsertedDate = wishList.InsertedDate,
                                     IsRemoved = wishList.IsRemoved,
                                     Count = wishList.Count,
                                     ProductId = product.ProductId,
                                 }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return wishListItems;
        }

        public WishListItem GetWishListItemsById(int productId)
        {
            WishListItem? wishListItem = new WishListItem();
            try
            {
                wishListItem = _DbContext.WishListItem?.Where(x => x.ProductId == productId && x.IsRemoved != true).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return wishListItem;
        }

        public void UpdateWishListItem(WishListItem wishItem)
        {
            try
            {
                _DbContext.WishListItem.Update(wishItem);
                _DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            };
        }

        public bool RemoveWishListItem(int productId)
        {
            try
            {
                WishListItem? wishListItem = _DbContext.WishListItem?.Where(x => x.ProductId == productId && x.IsRemoved != true).FirstOrDefault();
                if (wishListItem != null)
                {
                    wishListItem.IsRemoved = true;
                    _DbContext.WishListItem.Update(wishListItem);
                    int count = _DbContext.SaveChanges();
                    if (count > 0)
                        return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}
