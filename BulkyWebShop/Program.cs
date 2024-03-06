using BulkyWebShop.Data;
using BulkyWebShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// explicit typing for better type visibiity
Action<DbContextOptionsBuilder> OPT = options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// add EF Core to the project
builder.Services.AddDbContext<ApplicationDbContext>(OPT);

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
