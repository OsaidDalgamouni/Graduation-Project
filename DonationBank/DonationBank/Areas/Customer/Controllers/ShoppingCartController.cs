using DonationBank.Models;
using DonationBank.Models.VM;
using DonationBank.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DonationBank.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var cliamsIdentity = (ClaimsIdentity)User.Identity;
            var cliam = cliamsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM() {
                ListCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationReceiverId == cliam.Value, includeProperties: "Product"),
             
           };
        

            


            return View(ShoppingCartVM);
        }
        public IActionResult Delete(int? id)
        {
          var obj =  _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.ShoppingCart.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Summary(ShoppingCartVM ShoppingCartVM)
        {
            if(ShoppingCartVM == null)
            {

                
            }
            var cliamsIdentity = (ClaimsIdentity)User.Identity;
            var cliam = cliamsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            { OrderHeader = new() };
                ShoppingCartVM.ListCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationReceiverId == cliam.Value, includeProperties: "Product");
            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationReceiverId = cliam.Value;
            _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
          _unitOfWork.Save();
            foreach(var cart in ShoppingCartVM.ListCarts)
            {
                OrderDetails orderDetail = new()
                {
                    ProductId = (int)cart.ProductId,
                    OrderId = ShoppingCartVM.OrderHeader.Id,

                };
                _unitOfWork.OrderDetails.Add(orderDetail);
                _unitOfWork.Save();
            }
            _unitOfWork.ShoppingCart.RemoveRange(ShoppingCartVM.ListCarts);
            _unitOfWork.Save();

           return RedirectToAction("Index");   
        }
    }
}
