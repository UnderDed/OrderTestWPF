using Microsoft.EntityFrameworkCore;

namespace OrderTestWPF.DB
{
    public class MyContext : DbContext
    {
        private string cs =
            "Server = UNDERDEDPC; database = OrderTest; user id = sa; password = sa";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<Orders> orders { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Users> users { get; set; } 
    }
}
