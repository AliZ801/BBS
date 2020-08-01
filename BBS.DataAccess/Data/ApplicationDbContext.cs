using System;
using System.Collections.Generic;
using System.Text;
using BBS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BBS.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BGroup> BGroup { get; set; }

        public DbSet<Hospital> Hospital { get; set; }

        public DbSet<Branch> Branch { get; set; }

        public DbSet<Inventory> Inventory { get; set; }
    }
}
