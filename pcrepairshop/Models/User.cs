using System.ComponentModel.DataAnnotations;

namespace pcrepairshop.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Role { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}