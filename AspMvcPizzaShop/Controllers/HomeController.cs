using AspMvcPizzaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspMvcPizzaShop.Controllers
{
    public class HomeController : Controller
    {
        AplicationContext db = new AplicationContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Create()
        {
            return View("CreatePizza");
        }
        public IActionResult CreateClient()
        {
            return View("CreateOrder");
        }
        public async Task<IActionResult> Index()
        {
            ViewModel view = new ViewModel();
            view.Orders = db.Orders.ToList();
            view.Pizzas = db.Pizzas.ToList();
            return View("Index", view);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> CreatePizza(ViewImage dres)
        {
                Pizza person = dres.Pizzas;
                if (dres.Avatar != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(dres.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)dres.Avatar.Length);
                    }
                    // установка массива байтов
                    person.Img = imageData;
                }
                db.Pizzas.Add(person);
                db.SaveChanges();         
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateOrderFunc(Order ord)
        {
            if(ord.Size <= 20)
            {
                ord.Price += 10;
            }
            if(ord.Size <= 40 & ord.Size > 20)
            {
                ord.Price += 20;
            }
            if (ord.Size > 40)
            {
                ord.Price += 30;
            }
            if (ord.Ingred.Sausage == true)
            {
                ord.Price += 20;
            }
            if (ord.Ingred.Ananas == true)
            {
                ord.Price += 20;
            }
            if (ord.Ingred.DoubleCheese == true)
            {
                ord.Price += 40;
            }
            if (ord.Ingred.Mushrooms == true)
            {
                ord.Price += 20;
            }
            db.Orders.Add(ord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}