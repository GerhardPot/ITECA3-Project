using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pcrepairshop.Models
{
    public enum Status
    {
        Pickup = 1,
        Delivery,
        Repair,
        Ewaste,
        Warehouse,
        Inspection,
        Repairing,
        Testing,
        Approved,
        Closed
    }

    public enum InitialStatus
    {
        Repair = 1,
        Ewaste
    }

    public class Ticket
    {
        [Key] public int Id { get; set; }
        public InitialStatus InitialStatus { get; set; }
        public Status Status { get; set; }
        [ForeignKey("User")] public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Inventory")] public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}