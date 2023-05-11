using DonationBank.Models;

namespace DonationBank.Repository.IRepository
{
    public interface IOrderDetails : IRepository<OrderDetails>
    {
        void Update (OrderDetails obj);
    }
}
