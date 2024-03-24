using ECommerceShop.Data;
using ECommerceShop.Models;
using ECommerceShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShop.Controllers
{
    public class CartController : Controller
    {

        private readonly CartService _cartService;
        private readonly ProductContext _context;

        public CartController(CartService cartService, ProductContext context)
        {
            _cartService = cartService;
            _context = context;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        
        public IActionResult AddToCart ([FromBody] AddToCartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cart = _cartService.GetCart();

                //check if the product already exists in cart
                var existingItem = cart.Items.FirstOrDefault(item=>item.Product.Id == model.ProductId);

                if (existingItem != null)
                {

                    //update the quantity existing item

                    existingItem.Quantity = model.Quantity;
                    _cartService.UpdateCart(cart);

                    //return a Json response with the updated flag

                    return Json(new {updated =  true});

                }

                //The product isn't in cart

                _cartService.AddToCart(model.ProductId, model.Quantity);
                _cartService.UpdateCart(cart);

                //return a Json response with the updated flag set to false
                return Json(new {updated = false});

            }

            //model validation failed
            return BadRequest();
        }

        public IActionResult Remove (string ProductId)
        {
            _cartService.RemoveItem(ProductId);
            return RedirectToAction("Index","Cart");

        }


    }

}
