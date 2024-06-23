using PCRepairShop.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pcrepairshop.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Reason for Tickets")]
        public eInitStatus InitialStatus { get; set; }
        [Required]
        [DisplayName("Current Status")]
        public eStatus Status { get; set; }
        [Required]
        [DisplayName("Inventory Type")]
        public eInvType InventoryType { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The description must be more than 10 and less than 200 characters", MinimumLength = 10)]
        [DisplayName("Device Description")]
        public string DeviceDescription { get; set; }
        public string User { get; set; }
    }
}