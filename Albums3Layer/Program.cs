using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL;
using BLL.Interfaces;
using BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Hard-coded connection string for demonstration purposes
var connectionString = "Server=Mathijs\\MSSQLSERVER02;Database=AlbumExchange;User Id=test;Password=test;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=true;";

// Registering the review repository and service with the connection string
builder.Services.AddScoped<IReviewRepository>(provider => new ReviewRepository(connectionString));
builder.Services.AddScoped<ReviewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
