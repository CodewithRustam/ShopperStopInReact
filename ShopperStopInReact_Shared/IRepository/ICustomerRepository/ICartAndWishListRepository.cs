using ShopperStopInReact_Shared.Model.Customer;
using ShopperStopInReact_Shared.ViewModel.Customer;

namespace ShopperStopInReact_Shared.IRepository.ICustomerRepository
{
    public interface ICartAndWishListRepository
    {
        void AddCartItems(CartItems addToCartItems);
        int? GetCartCount();
        List<CartItemsViewModel> GetCartItems();
        CartItems GetCartItemsById(int productId);
        bool RemoveItemFromCart(int ProductId);
        void UpdateCartItems(CartItems addToCartItems);
        int GetItemCountOfProduct(int productId);
        bool AddItemToWishList(WishListItem wishListItem);
        List<WishListItemsViewModel> GetWishListItems();
        WishListItem GetWishListItemsById(int productId);
        void UpdateWishListItem(WishListItem wishItem);
        bool RemoveWishListItem(int productId);
    }
}
