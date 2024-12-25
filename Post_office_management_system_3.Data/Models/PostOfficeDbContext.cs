using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Post_office_management_system_3.Data.Models
{
    public class PostOfficeDbContext : DbContext
    {
        public PostOfficeDbContext(DbContextOptions<PostOfficeDbContext> options) : base(options)
        {

        }
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=Localhost;Database=post_office041124_db;User=root;Password=******;",
            new MySqlServerVersion(new Version(8, 3,0 )));
    }
        public DbSet<HeadPostOffice> HeadPostOffices { get; set; }
        public DbSet<PostOffice> PostOffices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostOffice>()
                .HasOne(po => po.HeadPostOffice)
                .WithMany(hpo => hpo.PostOffices)
                .HasForeignKey(po => po.HeadPostOfficeId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.HeadPostOffice)
                .WithMany(hpo => hpo.Employees)
                .HasForeignKey(e => e.HeadPostOfficeId);

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Parcels)
                .HasForeignKey(p => p.ClientId);

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.PostOfficeSend)
                .WithMany(po => po.ParcelsSend)
                .HasForeignKey(p => p.PostOfficeSendId);

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.PostOfficeCome)
                .WithMany(po => po.ParcelsCome)
                .HasForeignKey(p => p.PostOfficeComeId);
           
        
          
        
    }
    }
}
