using System.ComponentModel.DataAnnotations;

namespace pcrepairshop.Models
{
    public class Inventory
    {
        [Key] public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}