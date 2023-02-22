using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

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
        builder.Services.AddScoped<SellerService>();
        builder.Services.AddScoped<DepartmentService>();
        builder.Services.AddScoped<SalesRecordService>();

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


        var enUs = new CultureInfo("en-US");
        var localizationOptions = (new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(enUs),
            SupportedCultures = new List<CultureInfo> { enUs },
            SupportedUICultures = new List<CultureInfo> { enUs }
        });

        app.UseRequestLocalization(localizationOptions);


        app.Run();
    }
}