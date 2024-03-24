using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceShop.Data;
using ECommerceShop.Models;
using ECommerceShop.Services;

namespace ECommerceShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        private readonly CartService _cartService;

        public ProductsController(ProductContext context , CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            /*return _context.Products !=null ? View (await _context.Products.ToListAsync()) :
                Problem("Entity set 'ProductContext.Products' is null");*/

            var products = await _context.Products.ToListAsync();

            var cart = _cartService.GetCart();

            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Product.Id);
                if (product != null)
                {
                    product.Quantity = item.Quantity;
                }
            }

            return View(products);

        }

        public IActionResult Remove(string productId)
        {
            _cartService.RemoveItem(productId);
            return RedirectToAction("Index", "Cart");
        }







        
        
        }
    }

