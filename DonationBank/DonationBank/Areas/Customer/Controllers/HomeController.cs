using DonationBank.Models;
using DonationBank.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Diagnostics;
using System.Drawing;
using System.Security.Claims;

namespace DonationBank.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Showproduct(string Category)
        {
            IEnumerable<Product> prodectList = _unitOfWork.Product.GetAll();
            switch (Category)
            {

                case "Woman":
                    prodectList=prodectList.Where(u => u.Category == Category);
                    break;
                case "Men":
                prodectList = prodectList.Where(u => u.Category == Category);
                    break;
                case "Kids":
                  prodectList = prodectList.Where(u => u.Category == Category);
                    break;
                default:
       
                    break;
            }
            return View(prodectList);
        }
        //get
        public IActionResult Details(int ProductId)
        {
            ShoppingCart cartobj = new()
            {
                ProductId = ProductId,
                Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == ProductId, includeproperties: "ApplicationUser"),
            };
          
            return View(cartobj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)

        {
            var cliamsIdentity = (ClaimsIdentity)User.Identity;
            var cliam = cliamsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationReceiverId = cliam.Value;
            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
            return RedirectToAction("Showproduct");

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}