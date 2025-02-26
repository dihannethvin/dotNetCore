using DotnetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register an In-Memory Database (Temporary Storage)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UserDatabase"));

var app = builder.Build(); // Build the app once

// Configure middleware
app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Map static assets and controller routes
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Run the app asynchronously
await app.RunAsync(); // Correctly run asynchronously
