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
    public class pcrepairshopDbContext : IdentityDbContext<User>
    {
        public pcrepairshopDbContext (DbContextOptions<pcrepairshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<pcrepairshop.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<pcrepairshop.Models.User> User { get; set; } = default!;
    }
}
