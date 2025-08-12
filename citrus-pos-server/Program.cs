using Microsoft.EntityFrameworkCore;

using Citrus.Contexts;
using Citrus.Models;
using Citrus.Services.Interfaces;
using Citrus.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//DATABASE CONTEXT CONSTRUCTION
builder.Services.AddDbContext<SqliteDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

// ADD SERVICES TO THE DI
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductAddonService, ProductAddonService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// KESTREL SERVER OPTIONS
builder.WebHost.UseKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(6445, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
