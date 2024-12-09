using lab12MVC.Data;
using lab12MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lab12MVC;Trusted_Connection=True;"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Companies.Any())
    {
        context.Companies.AddRange(
            new Company { Name = "Microsoft", Address = "Redmond, WA", EmployeesCount = 144000 },
            new Company { Name = "Google", Address = "Mountain View, CA", EmployeesCount = 118899 },
            new Company { Name = "Apple", Address = "Cupertino, CA", EmployeesCount = 154000 },
            new Company { Name = "Amazon", Address = "Seattle, WA", EmployeesCount = 1600000 },
            new Company { Name = "Meta", Address = "Menlo Park, CA", EmployeesCount = 71970 }
        );
        context.SaveChanges();
    }
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Company}/{action=Index}/{id?}");

app.Run();
