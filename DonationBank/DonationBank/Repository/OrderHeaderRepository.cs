using DonationBank.Data;
using DonationBank.Models;
using DonationBank.Repository.IRepository;

namespace DonationBank.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>,IOrderHeaderRepository
    {
        private readonly AppDBContext _db;
        public OrderHeaderRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
           _db.OrderHeaders.Update(obj);
        }
    }
}
