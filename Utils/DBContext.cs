using System;
using Microsoft.EntityFrameworkCore;

using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using backend.Models;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;

using backend.Utils;
using backend.Utils.Locale;
using backend.Utils.Interface;

using FluentValidation;
using System.Globalization;

namespace backend.Utils
{
    public class DBContext : DbContext
    {
        private IConfig config;
        public DBContext(IConfig config)
        {
            this.config = config;
        }

        public DbSet<User> user { set; get; }
        public DbSet<Category> category { set; get; }
        public DbSet<Product> product { set; get; }
        public DbSet<Order> order { set; get; }
        public DbSet<OrderItem> orderItem { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this.config.getEnvByKey("DB_URL"));
        }

        public static async Task<Boolean> initDatabase(IConfig config)
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