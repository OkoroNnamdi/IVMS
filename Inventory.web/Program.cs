using Inventory.Utility.HelperClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventory.Repository;
using Inventory.Models;
using Inventory.Services.BillTypeService;
using Inventory.Services;
using Inventory.Repository.customerTypes;
using Inventory.Repository.InventoryCustomerType;

namespace Inventory.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         var connectionString = builder.Configuration.GetConnectionString("Dbconnnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

         builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
         

         builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container.
          builder.Services.AddControllersWithViews();
          builder.Services.AddScoped<IBillTypeRepo, BillTypeRepo>();
            builder.Services.AddScoped<ICustomerTypeRepo, CustomerTypeRepo>();
            builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}