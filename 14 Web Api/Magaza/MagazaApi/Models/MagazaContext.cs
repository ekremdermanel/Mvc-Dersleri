using Microsoft.EntityFrameworkCore;

namespace MagazaApi.Models
{
    public class MagazaContext : DbContext
    {
        public MagazaContext() { }
        public MagazaContext(DbContextOptions<MagazaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MagazaDB.db");
        }

        public DbSet<Urun> Urunler { get; set; }
    }
}