
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonationBank.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
       
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
       public Product? Product { get; set; }
        public string? ApplicationReceiverId { get; set; }
        [ForeignKey("ApplicationReceiverId")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
