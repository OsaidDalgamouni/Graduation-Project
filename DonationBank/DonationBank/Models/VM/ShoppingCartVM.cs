namespace DonationBank.Models.VM
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListCarts { get; set; }
        public OrderHeader OrderHeader { get; set; }
       
    }
}
