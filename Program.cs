using Microsoft.AspNetCore.Mvc.Infrastructure;
using NetcoreKerryInventory.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Add session service
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
//builder.Services.AddScoped<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Add Context
builder.Services.AddDbContext<InventoryDBContext>();


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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Frontend}/{action=Index}");

app.Run();