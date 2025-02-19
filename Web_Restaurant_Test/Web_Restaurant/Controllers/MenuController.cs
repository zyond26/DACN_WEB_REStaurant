using Microsoft.AspNetCore.Mvc;
using WebRestaurant.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebRestaurant.Controllers
{
    public class MenuController : Controller
    {
        // Danh sách mẫu các món ăn
        private static List<FoodItem> FoodItems = new List<FoodItem>
{
    // Món chính
    new FoodItem { Id = 1, Name = "Pizza Phô Mai", Description = "Pizza phô mai thơm ngon", Price = 9.99m, Category = "Món Chính", ImageUrl = "https://img.freepik.com/free-photo/top-view-pepperoni-pizza-with-mushroom-sausages-bell-pepper-olive-corn-black-wooden_141793-2158.jpg?semt=ais_hybrid" },
    new FoodItem { Id = 2, Name = "Bánh Mì Kẹp Thịt Bò", Description = "Bánh mì kẹp thịt bò mềm và ngon", Price = 5.99m, Category = "Món Chính", ImageUrl = "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_640.jpg" },
    new FoodItem { Id = 3, Name = "Bò Bít Tết", Description = "Bít tết bò nướng với bơ tỏi", Price = 19.99m, Category = "Món Chính", ImageUrl = "https://fujifoods.vn/wp-content/themes/yootheme/cache/10/Japanese-Steak-10cead81.jpeg" },
    new FoodItem { Id = 4, Name = "Mì Ý Carbonara", Description = "Mì Ý sốt kem với thịt xông khói và phô mai Parmesan", Price = 11.99m, Category = "Món Chính", ImageUrl = "https://nguyenhafood.vn/uploads/files/cong-thuc-spaghetti-carbonara-don-gian-cung-nguyen-ha-food%20%286%29.jpg" },
    new FoodItem { Id = 5, Name = "Sushi Tổng Hợp", Description = "Set sushi nhiều loại với cá tươi", Price = 14.99m, Category = "Món Chính", ImageUrl = "https://sushi88.vn/wp-content/uploads/2018/06/Nigiri-T%E1%BB%95ng-h%E1%BB%A3p-228k-1170x679.jpg" },

    // Món khai vị
    new FoodItem { Id = 6, Name = "Bánh Mì Bơ Tỏi", Description = "Bánh mì nướng giòn phủ bơ tỏi và phô mai", Price = 4.50m, Category = "Khai Vị", ImageUrl = "https://daubepgiadinh.vn/wp-content/uploads/2018/08/banh-mi-bo-toi-1-600x400.jpg" },
    new FoodItem { Id = 7, Name = "Salad Caesar", Description = "Salad Caesar cổ điển với sốt đặc biệt và phô mai Parmesan", Price = 6.99m, Category = "Khai Vị", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSP4LuPshHWqdhU8INKDFDRtB76SE4VEECwel11SBkeZc76PAicCGdfPlbHC_bw811RvyI&usqp=CAU" },
    new FoodItem { Id = 9, Name = "Khoai Tây Chiên", Description = "Khoai tây chiên giòn vàng", Price = 3.99m, Category = "Khai Vị", ImageUrl = "https://lamsonfood.com/wp-content/uploads/2022/04/cach-lam-khoai-tay-chien-1.jpg" },

    // Món tráng miệng
    new FoodItem { Id = 10, Name = "Bánh Sô Cô La", Description = "Bánh sô cô la mềm và đậm đà", Price = 6.99m, Category = "Tráng Miệng", ImageUrl =" https://file.hstatic.net/1000396324/file/cach-lam-banh-socola-tan-chay-2_b31f8132eb3e44bfa206896c9a274c0e_grande.jpg" },
    new FoodItem { Id = 11, Name = "Bánh Phô Mai", Description = "Bánh phô mai kem béo với sốt dâu", Price = 7.50m, Category = "Tráng Miệng", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTw3fKqeVufLr5AIZtYmvpJk6mRIUjhXTNfTA&s" },
    new FoodItem { Id = 12, Name = "Kem Ly Hoa quả ", Description = "Kem vani với hoa quả tươi ", Price = 5.50m, Category = "Tráng Miệng", ImageUrl = "https://danviet.mediacdn.vn/296231569849192448/2021/7/6/1-1625507746087908266247.jpg" },

};

        public IActionResult Menu()
        {
            ViewBag.MenuItems = FoodItems;
            return View();
        }

        public IActionResult FoodDetails(int id)
        {
            var food = FoodItems.FirstOrDefault(f => f.Id == id);
            if (food == null)
                return NotFound();
            return View(food);
        }
    }
}
