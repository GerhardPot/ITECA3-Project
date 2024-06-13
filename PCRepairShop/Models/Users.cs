using PCRepairShop.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCRepairShop.Models
{
    public class Users
    {
        [Key] public string UserID { get; set; }
        public DateTime Inserted { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Role Role { get; set; }
    }
}
