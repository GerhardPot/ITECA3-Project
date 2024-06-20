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
        [Required] public InitialStatus InitialStatus { get; set; }
        [Required] public Status Status { get; set; }
        [Required] [StringLength(200, ErrorMessage = "The description must be less than 200 characters", MinimumLength = 10)]
        public string DeviceDescription { get; set; }
        public User User { get; set; }
    }
}