using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;
        var connectionString = configuration.GetConnectionString("SalesWebMvcContext");

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        builder.Services.AddDbContext<SalesWebMvcContext>(options =>
        {
            options.UseMySql(connectionString, serverVersion);
        });

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<SeedingService>();

        var app = builder.Build();      


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // Ensure database is created and seeded
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<SalesWebMvcContext>();
            var seedingService = services.GetRequiredService<SeedingService>();
            context.Database.Migrate();
            seedingService.Seed();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();



        app.UseRouting();

        app.UseAuthorization();
       

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}