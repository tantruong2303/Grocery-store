using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Backend.Utils;
using Backend.Utils.Locale;
using Backend.Utils.Interface;
using FluentValidation;
using System.Globalization;
using Backend.Services;
using Backend.Services.Interface;
using Backend.Controllers;
using Backend.DAO.Interface;
using Backend.DAO;
using Backend.Pipe;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConfig, Config>();
            services.AddScoped<IUploadFileService, UploadFileService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<DBContext, DBContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<AuthGuard>();

            services.AddSession();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        async public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfig config)
        {
            ValidatorOptions.Global.LanguageManager = new CustomLanguageValidator();
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.Use(next => context =>
                       {
                           ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
                           return next(context);
                       });
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            await DBContext.InitDatabase(config);
        }
    }
}
