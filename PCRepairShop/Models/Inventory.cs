using PCRepairShop.Data;
using System.ComponentModel.DataAnnotations;

namespace PCRepairShop.Models
{
    public class Inventory
    {
        public DateTime Inserted { get; set; } = DateTime.Now;
        [Key] public string InventoryID { get; set; }
        public string Description { get; set; }
        public InvType InvType { get; set; }
    }
}
