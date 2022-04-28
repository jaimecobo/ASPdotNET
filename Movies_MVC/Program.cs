using L08HandsOnASPNetDB.Data;
using L08HandsOnASPNetDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedAccount = true; })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();


//Authorize access to CRUD only to user Admin
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin",
        p => p.Requirements.Add(new L08HandsOnASPNetDB.Policy.SpecificUserRequirement("admin@cobo.live")));
});

var connectionStringSqlite = "Data Source=Movies.db";
builder.Services.AddDbContext<MoviesContext>(options => options.UseSqlite(connectionStringSqlite));

//connectionString = "Data Source=WatchedMovies.db";
//builder.Services.AddDbContext<WatchedMoviesContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run(); 