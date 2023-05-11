using DonationBank.Models;
using DonationBank.Models.VM;
using DonationBank.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DonationBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            OrderVM = new OrderVM()
            {
                OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(x => x.Id == id, includeproperties: "ApplicationUser"),
                Details = _unitOfWork.OrderDetails.GetAll(u => u.OrderId == id, includeProperties: "Product"),

               
            };
            return View(OrderVM);
        }
        public IActionResult AcceptOrder(int?id)
        {
            OrderVM = new OrderVM()
            {
                OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(x => x.Id == id, includeproperties: "ApplicationUser"),

                Details= (IEnumerable<OrderDetails>)_unitOfWork.OrderDetails.GetFirstOrDefault(u => u.OrderId==id),
               
                
            };
            foreach(var pro in OrderVM.Details)
            {
                pro.Product.Accepted = false;
            }
            return View();
        }
        #region API CALLS        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<OrderHeader> orderHeaders;
           orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            return Json(new { data = orderHeaders });
        }
        #endregion
    }
}
