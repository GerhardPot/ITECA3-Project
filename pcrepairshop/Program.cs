using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pcrepairshop.Data;
using pcrepairshop.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PCrepairshopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("pcrepairshopDbContext") ?? throw new InvalidOperationException("Connection string 'pcrepairshopDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<PCrepairshopDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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
