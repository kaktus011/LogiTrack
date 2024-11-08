using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LogiTrack.Infrastructure;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.Services;
using LogiTrack.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IAccountantService, AccountantService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ICashRegisterService, CashRegisterService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<GeocodingService>();

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
