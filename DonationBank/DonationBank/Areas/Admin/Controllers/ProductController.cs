using DonationBank.Models;
using DonationBank.Models.AcceptProduct;
using DonationBank.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DonationBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _Unit;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductController(IUnitOfWork Unit, IWebHostEnvironment webHostEnvironment)
        {
            _Unit = Unit;
            _WebHostEnvironment = webHostEnvironment;

        }
        //get
        public IActionResult Index()
        {

            return View();
        }

        //get
       public IActionResult Donate()
        {
          




         

                //create product
                return View();
           
                
            }



        
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
      public IActionResult Donate(Product obj, IFormFile? file)
        {
          

                string wwwroot = _WebHostEnvironment.WebRootPath;
                if (file != null)
                {
                var cliamsIdentity = (ClaimsIdentity)User.Identity;
                var cliam = cliamsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                obj.ApplicationUserId = cliam.Value;
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwroot, @"Image\Products");
                    var exttension = Path.GetExtension(file.FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + exttension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImagePath = @"\Image\Products\" + fileName + exttension;
                }
           
              
                 _Unit.Product.Add(obj);
              
              

                _Unit.Save();
            
            TempData["success"] = "Product created successfuly";
                return View("Donate");
            
          

        }
        public IActionResult Check() {

            return View();
        }
        [HttpGet]
       
        public IActionResult Accept(int? id)
            {
                if (id == null)
                {

                }
                var obj = _Unit.Product.GetFirstOrDefault(u => u.Id == id);
                obj.Accepted = true;
            _Unit.Product.Update(obj);
            _Unit.Save();
            return View("Donate");
        }
           

          


              


        #region API CALLS        
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _Unit.Product.GetAll(includeProperties: "ApplicationUser");
            productList = productList.Where(u => u.Accepted == false);
          
            return Json(new { data = productList });
        }
        [HttpDelete]

        public IActionResult Delete(int? id)

        {
            var  ProductFromDb=_Unit.Product.GetFirstOrDefault(x => x.Id == id);
           
            if (ProductFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            var oldimagepath = Path.Combine(_WebHostEnvironment.WebRootPath, ProductFromDb.ImagePath.TrimStart('\\'));
            if (System.IO.File.Exists(oldimagepath))
            {
                System.IO.File.Delete(oldimagepath);
            }
            _Unit.Product.Remove(ProductFromDb);
            _Unit.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }


        #endregion

    }
}
