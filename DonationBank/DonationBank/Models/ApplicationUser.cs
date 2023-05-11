using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DonationBank.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string name { get; set; }
     
        [Required]
        public string Address { get; set; }

    }
}
