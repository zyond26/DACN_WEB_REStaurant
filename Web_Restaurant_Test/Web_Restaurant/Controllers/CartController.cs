using Microsoft.AspNetCore.Mvc;
using WebRestaurant.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebRestaurant.Controllers
{
    public class CartController : Controller
    {
        // Danh sách tĩnh chứa các mặt hàng trong giỏ
        private static List<CartItem> CartItems = new List<CartItem>();

        public IActionResult Cart()
        {
            ViewBag.CartItems = CartItems;
            ViewBag.CartTotal = CartItems.Sum(item => item.Total);
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int foodId, string name, decimal price, int quantity = 1)
        {
            var item = CartItems.FirstOrDefault(c => c.FoodId == foodId);
            if (item == null)
            {
                CartItems.Add(new CartItem { FoodId = foodId, Name = name, Price = price, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int foodId)
        {
            var item = CartItems.FirstOrDefault(c => c.FoodId == foodId);
            if (item != null)
            {
                CartItems.Remove(item);
            }
            return RedirectToAction("Cart");
        }

        public IActionResult Checkout()
        {
            ViewBag.CartItems = CartItems;
            ViewBag.CartTotal = CartItems.Sum(item => item.Total);
            return View();
        }

        // Các phương thức tiện ích để truy xuất và xóa giỏ hàng (sử dụng trong OrderController)
        public static List<CartItem> GetCartItems() => CartItems;
        public static void ClearCart() => CartItems.Clear();
    }
}
