namespace DonationBank.Models.VM
{
    public class OrderVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetails> Details { get; set; }
        public OrderDetails DetailsDetails { get; set; }
    }
}
