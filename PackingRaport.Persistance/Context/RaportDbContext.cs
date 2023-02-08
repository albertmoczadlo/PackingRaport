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

        public RaportDbContext(DbContextOptions<RaportDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
