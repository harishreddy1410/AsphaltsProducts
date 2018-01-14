using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsphaltsProducts.Presentation.Layer.Helpers.ComplexObjects;
using AsphaltsProducts.Presentation.Layer.Helpers.Session;
using Microsoft.AspNetCore.Mvc;

namespace AsphaltsProducts.Presentation.Layer.Controllers
{
    public class CartController : Controller
    {
        private readonly ISessionFactory _session;
        public CartController(ISessionFactory sessionFactory)
        {
            _session = sessionFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Method used to store user selected items in session 
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        public JsonResult ToggleCartSelection(ProductAddedToCart selectedItem)
        {
            var itemsInCart = _session.Get<CartProducts>(SessionKey.CART_ITEMS);
            if (itemsInCart == null)
            {
                itemsInCart = new CartProducts() { CartItems = new List<ProductAddedToCart>() };
            }
            if (itemsInCart.CartItems.Any(x => x.ProductId == selectedItem.ProductId))
                 itemsInCart.CartItems.RemoveAll(x => x.ProductId == selectedItem.ProductId);
            else
                itemsInCart.CartItems.Add(selectedItem);
            _session.Set<CartProducts>(SessionKey.CART_ITEMS, itemsInCart);
            return Json(itemsInCart);
        }

        /// <summary>
        /// Method used to get all the items present cart which is added by user
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCartItems()
        {
            var cartItems = _session.Get<CartProducts>(SessionKey.CART_ITEMS);
            if (cartItems == null)
            {
                cartItems = new CartProducts() { CartItems = new List<ProductAddedToCart>() };
            }            
            return Json(cartItems);
        }
    }
}