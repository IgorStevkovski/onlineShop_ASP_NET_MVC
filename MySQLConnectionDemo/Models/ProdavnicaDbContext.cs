using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySQLConnectionDemo.Models
{
    public class ProdavnicaDbContext : IdentityDbContext
    {
        public ProdavnicaDbContext()
            : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
        
        //public DbSet<Student> Students { get; set; }
        public DbSet<Pratka> Pratki { get; set; }
        public DbSet<Produkt> Produkti { get; set; }
        public DbSet<Tip> Tipovi { get; set; }
        public DbSet<Naracka> Naracki { get; set; }
    }
}