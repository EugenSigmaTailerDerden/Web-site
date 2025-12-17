using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<Mobile> mobiles = new() {
            new Mobile
            {
                Id = 101,
                Title = "iPhone 15 Pro",
                Category = "Smartphone",
                Price = 45000,
                Quantity = 15,
                Discount = 42000,
                ImageUrl = "https://ifranko.ua/wp-content/uploads/2023/09/img_6189.jpg"
            },
            
            // 2. Створення другого об'єкту Mobile
            new Mobile
            {
                Id = 203,
                Title = "Samsung Galaxy S24",
                Category = "Smartphone",
                Price = 35000,
                Quantity = 22,
                ImageUrl = "https://mobileplanet.ua/uploads/product/2024-1-22/samsung-galaxy-s24-ultra-12-256gb-titani-300746.webp"
            },
            
            // 3. Створення третього об'єкту Mobile
            new Mobile
            {
                Id = 310,
                Title = "Xiaomi Redmi Note 13",
                Category = "Mid-range",
                Price = 12000,
                Quantity = 50,
                ImageUrl = "https://hotline.ua/img/tx/549/549339529_s265.jpg"
            },

            // 4. Створення четвертого об'єкту Mobile
            new Mobile
            {
                Id = 405,
                Title = "Google Pixel 8",
                Category = "Smartphone",
                Price = 30000,
                Quantity = 18,
                ImageUrl = "https://maifon.ua/media/catalog/product/cache/e6f66b203dae525185dd78e2797d0685/r/d/rd2ykpy2shysd91b3aema9cgwtyhf15o-webp_1.jpg"
            },

            // 5. Створення п'ятого об'єкту Mobile
            new Mobile
            {
                Id = 502,
                Title = "Nokia 3310 (2017)",
                Category = "Feature Phone",
                Price = 2500,
                Quantity = 100,
                ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/590557138.png"
            }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Mobile element)
        {
            var index = mobiles.FindIndex(x => x.Id == element.Id);

            if (index != -1)
                mobiles[index] = element;

            return RedirectToAction("Admin");

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveMobile(Mobile element)
        {
            mobiles.Add(element);
            return RedirectToAction("Admin");

        }

       

        public IActionResult Details(int id)
        {
            var item = mobiles.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        public IActionResult Mobile()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var item = mobiles.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound(); 
            return View(item);
        }
        public IActionResult Admin()
        {
            return View(mobiles);
        }

        public IActionResult Delete(int id)
        {
            // Delete logic
            var item = mobiles.Find(x => x. Id == id );
            if (item == null)
                return NotFound();
            mobiles.Remove(item);


            return RedirectToAction("Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
