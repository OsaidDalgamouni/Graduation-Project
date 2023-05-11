using DonationBank.Data;
using DonationBank.Models;
using DonationBank.Repository.IRepository;

namespace DonationBank.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly AppDBContext _db;
        

        public ApplicationUserRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
