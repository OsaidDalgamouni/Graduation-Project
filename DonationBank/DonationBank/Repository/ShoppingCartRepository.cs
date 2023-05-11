using DonationBank.Data;
using DonationBank.Models;
using DonationBank.Repository.IRepository;

namespace DonationBank.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDBContext _db;
        public ShoppingCartRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
