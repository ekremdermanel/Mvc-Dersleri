using Microsoft.EntityFrameworkCore;

namespace TelefonRehberiApi.Models
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./wwwroot/TelefonRehberiDB.db");
        }

        public DbSet<Kisi> Kisiler { get; set; }
    }
}