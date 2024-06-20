using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace pcrepairshop.Models
{
    public class User : IdentityUser
    {
        [Required] [MaxLength(40)]
        public string Name { get; set; }
        [Required] [MaxLength(40)] 
        public string Surname { get; set; }
        [Required] [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }
        [Required] [DataType(DataType.Password)] [StringLength(32, ErrorMessage = "The password must be 10 - 32 characters", MinimumLength = 10)]
        public string Password { get; set; }
        [Required] [DataType(DataType.PhoneNumber)] public string CellNumber { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string Suburb { get; set; }
        [Required] public string City { get; set; }
        [Required] public int PostalCode { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}