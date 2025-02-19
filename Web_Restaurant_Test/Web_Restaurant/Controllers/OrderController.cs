using Microsoft.AspNetCore.Mvc;
using WebRestaurant.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebRestaurant.Controllers
{
    public class OrderController : Controller
    {
        // Danh sách đơn hàng
        private static List<Order> Orders = new List<Order>();

        public IActionResult OrderManagement()
        {
            ViewBag.Orders = Orders;
            return View();
        }

        public IActionResult OrderStatus(int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            order.OrderId = Orders.Count + 1;
            order.Status = "Processing";
            Orders.Add(order);
            return RedirectToAction("OrderStatus", new { orderId = order.OrderId });
        }

        // Xử lý xác nhận thanh toán từ trang Checkout
        [HttpPost]
        public IActionResult ConfirmOrder(string name, string address, string phone)
        {
            // Lấy danh sách Cart hiện tại
            var cartItems = CartController.GetCartItems();
            if (cartItems == null || !cartItems.Any())
            {
                return RedirectToAction("Cart", "Cart");
            }

            Order newOrder = new Order
            {
                OrderId = Orders.Count + 1,
                CustomerName = name,
                Address = address,
                Phone = phone,
                Items = cartItems,
                TotalAmount = cartItems.Sum(i => i.Total),
                Status = "Processing"
            };
            Orders.Add(newOrder);

            // Sau khi đặt hàng, xóa giỏ hàng
            CartController.ClearCart();
            return RedirectToAction("OrderStatus", new { orderId = newOrder.OrderId });
        }
    }
}
