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
    }
}
