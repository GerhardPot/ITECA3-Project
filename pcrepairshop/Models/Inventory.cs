using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pcrepairshop.Models
{
    public class Inventory
    {
        [Key] public int Id { get; set; }
        [Required] [Display(Name = "Device Description")] [MinLength(10)] [MaxLength(200)] public string Description { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}