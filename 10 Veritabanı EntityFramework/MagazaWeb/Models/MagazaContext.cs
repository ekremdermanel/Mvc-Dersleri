using Microsoft.EntityFrameworkCore;

namespace MagazaWeb.Models {
    public class MagazaContext : DbContext {
        public MagazaContext() { }
        public MagazaContext(DbContextOptions<MagazaContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseMySQL("Server=localhost;Database=MagazaDB;Uid=root;Pwd=;");
        }

        public DbSet<Urun> Urunler { get; set; }
    }
}