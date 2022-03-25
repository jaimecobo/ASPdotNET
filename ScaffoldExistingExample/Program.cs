//=====================================
//using System.IO;
//using Microsoft.EntityFrameworkCore;
//using ScaffoldExistingExample.Models;
//======================================


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//===========================================================
//void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllersWithViews();
//            services.AddDbContext<ApplicationDbContext>(options =>
//            options.UseSqlite("Data Source=" + Path.GetFullPath("chinook.db")));
//        }
//==========================================================

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
