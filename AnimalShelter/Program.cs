using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AnimalShelter.Models;

namespace AnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();
            DBConfiguration.ConnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

            app.UseRouting();
            app.UseStaticFiles();

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}"
            );


            app.Run();
        }
    }
}