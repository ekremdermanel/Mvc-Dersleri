using Microsoft.EntityFrameworkCore;

namespace TelefonRehberi.Models {
    public class KisiContext : DbContext {
        public KisiContext() { }
        public KisiContext(DbContextOptions<KisiContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
           optionsBuilder.UseSqlite("Data Source=Rehber.db");
        }

        public DbSet<Kisi> Kisiler { get; set; }
    }
}