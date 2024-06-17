using Microsoft.EntityFrameworkCore;
using Wardrobe.Models;

namespace Wardrobe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress01;Database=wardrobedb;Trusted_Connection=true;TrustServerCertificate=True;");
        }

        public DbSet<PairOfShoes> PairOfShoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {/*
            modelBuilder.Entity<PairOfShoes>()
                .OwnsMany(x => x.UsageLogs);*/

            modelBuilder.Entity<PairOfShoes>()
                .OwnsMany(v => v.UsageLogs, ul =>
                {
                    ul.WithOwner().HasForeignKey("PairOfShoesId"); // Foreign key in UsageLog table to reference shoe
                    ul.Property<int>("Id"); // Shadow property to make UsageLog identifiable
                    ul.HasKey("Id");
                });
        }
    }
}
