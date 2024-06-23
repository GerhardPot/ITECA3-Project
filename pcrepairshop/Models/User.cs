using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pcrepairshop.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }
    }
}