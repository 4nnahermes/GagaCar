using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GagaCar.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GagaCarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GagaCarContext") ?? throw new InvalidOperationException("Connection string 'GagaCarContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
