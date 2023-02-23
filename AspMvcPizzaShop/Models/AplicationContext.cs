using Microsoft.EntityFrameworkCore;

namespace AspMvcPizzaShop.Models
{
    public class AplicationContext : DbContext
    {
        public DbSet<Models.Pizza> Pizzas { get; set; }
        public DbSet<Models.Ingredient> Ingredients { get; set; }
        public DbSet<Models.Order> Orders { get; set; }

        private string sqlConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
