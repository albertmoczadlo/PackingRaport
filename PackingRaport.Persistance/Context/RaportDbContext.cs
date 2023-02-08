using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackingRaport.Domain.Models;

namespace PackingRaport.Persistance.Context
{
    public class RaportDbContext: IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Raport> Raports { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tank> Tanks { get; set; }

        public RaportDbContext(DbContextOptions<RaportDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            {
                builder.Entity<Raport>()
                    .HasOne<User>(r => r.User)
                    .WithMany(r => r.Raports)
                    .HasForeignKey(u => u.UserId);
            }

            {
                builder.Entity<Product>()
                    .HasOne<Raport>(r => r.Raports)
                    .WithMany(r => r.Products)
                    .HasForeignKey(u => u.RaportId);

                builder.Entity<Container>()
                    .HasOne<Raport>(r => r.Raports)
                    .WithMany(r => r.Containers)
                    .HasForeignKey(u => u.RaportId);
            }

            {
                builder.Entity<Tank>()
                    .HasOne<Container>(r => r.Containers)
                    .WithMany(r => r.Tanks)
                    .HasForeignKey(u => u.ContainerId);
            }
        }

        public class AppUserEntityConfiguration : IEntityTypeConfiguration<User>
        {

            public void Configure(EntityTypeBuilder<User> builder)
            {

                builder.Property(p => p.Name).HasMaxLength(50);
                builder.Property(p => p.Surname).HasMaxLength(50);
                //builder.Property(c => c.Id).HasColumnName("ID").IsRequired();
            }
        }
    }
}
