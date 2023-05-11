using DonationBank.Data;
using DonationBank.Models;
using DonationBank.Repository.IRepository;

namespace DonationBank.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails> ,IOrderDetails
    {

        private readonly AppDBContext _db;
        public OrderDetailsRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails obj)
        {
           _db.OrderDetail.Update(obj);
        }
    }
}
