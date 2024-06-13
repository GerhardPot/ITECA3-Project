using PCRepairShop.Data;
using System.ComponentModel.DataAnnotations;

namespace PCRepairShop.Models
{
    public class Tickets
    {
        public DateTime Inserted { get; set; } = DateTime.Now;
        [Key] public string TicketID { get; set; }
        public Status Status { get; set; }
        public string UserID { get; set; }
        public string InventoryID { get; set; }
        public InitStatus InitialStatus { get; set; }


        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
