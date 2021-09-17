using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Utils.Interface;

namespace Backend.Utils
{
    public class DBContext : DbContext
    {
        private IConfig Config;
        public DBContext(IConfig config)
        {
            this.Config = config;
        }

        public DbSet<User> User { set; get; }
        public DbSet<Category> Category { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<OrderItem> OrderItem { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this.Config.GetEnvByKey("DB_URL"));
        }

        public static async Task<Boolean> InitDatabase(IConfig config)
        {
            var dbContext = new DBContext(config);
            bool result = await dbContext.Database.EnsureCreatedAsync();
            if (result)
            {
                Console.WriteLine("Database created");
            }

            return true;
        }
    }
}