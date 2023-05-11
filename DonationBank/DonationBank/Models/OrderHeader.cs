using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonationBank.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string? ApplicationReceiverId { get; set; }
        [ForeignKey("ApplicationReceiverId")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

    }
}