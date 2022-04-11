//using SecurityTesting.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvc();


builder.Services.AddAuthentication("MyScheme")
    .AddCookie("MyScheme", options => {
         options.ExpireTimeSpan = TimeSpan.FromSeconds(20);
         options.SlidingExpiration = true;

         options.AccessDeniedPath = "/account/denied";  
         options.LoginPath = "/account/login";

     });



builder.Services.AddDataProtection( option => option.ApplicationDiscriminator="SecurityFromScratch");
//builder.Services.AddControllersWithViews();

//########################################################################################################
//// ######################## LOOKS LIKE THIS CODE ISN'T NECESSARY IN .NET6 ######################## \\\\
//########################################################################################################

//static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//    .ConfigureWebHostDefaults(webBuilder =>
//    {
//        webBuilder.ConfigureAppConfiguration((context, builder) => builder.AddMyCustomConfiguration());
//        webBuilder.UseStartup<Program>();
//    });

//########################################################################################################
//// ######################## LOOKS LIKE THIS CODE ISN'T NECESSARY IN .NET6 ######################## ////
//########################################################################################################

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


//app.MapGet("/", () => "Hello World!");


app.MapDefaultControllerRoute();
app.Run();
