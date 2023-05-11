using DonationBank.Data;
using DonationBank.Repository.IRepository;


namespace DonationBank.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderDetails OrderDetails { get; private set; }
        public  IOrderHeaderRepository OrderHeader { get; private set; }

        public UnitOfWork(AppDBContext db)
        {
            _db = db;
            OrderDetails= new OrderDetailsRepository(_db);
            OrderHeader= new OrderHeaderRepository(_db);
            
            Product = new ProductRepository(_db);
           
            ShoppingCart= new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);  



        }
        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
