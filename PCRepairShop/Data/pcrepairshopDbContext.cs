using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using pcrepairshop.Models;

namespace pcrepairshop.Data
{
    public class PCrepairshopDbContext : IdentityDbContext<User>
    {
        public PCrepairshopDbContext (DbContextOptions<PCrepairshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Ticket { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<InvType> InvType { get; set; } = default!;
        public DbSet<Status> Status{ get; set; } = default!;
        public DbSet<InitStatus> InitStatus{ get; set; } = default!;

    }
}
