using DonationBank.Data;
using DonationBank.Models;
using DonationBank.Repository.IRepository;

namespace DonationBank.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDBContext _db;
        public ProductRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Clothes.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {

                objFromDb.Description = obj.Description;


                objFromDb.Size = obj.Size;
                objFromDb.Category = obj.Category;
                if (obj.ImagePath != null)
                {
                    objFromDb.ImagePath = obj.ImagePath;
                }

            }
        }
    }
}
