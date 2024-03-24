using ECommerceShop.Models;

namespace ECommerceShop.Services
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);
        void RemoveItem (string productId);

        void ClearCart();

        Cart GetCart ();
    }
}
