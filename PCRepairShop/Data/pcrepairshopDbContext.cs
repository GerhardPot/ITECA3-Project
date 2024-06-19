using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pcrepairshop.Models;

namespace pcrepairshop.Data
{
    public class pcrepairshopDbContext : DbContext
    {
        public pcrepairshopDbContext (DbContextOptions<pcrepairshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<pcrepairshop.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<pcrepairshop.Models.User> User { get; set; } = default!;
        public DbSet<pcrepairshop.Models.Inventory> Inventory { get; set; } = default!;
    }
}
