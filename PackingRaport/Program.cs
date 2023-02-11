using Microsoft.EntityFrameworkCore;
using PackingRaport.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using PackingRaport.Infrastructure.InterfaceRepository;
using PackingRaport.Infrastructure.Repositories;
using PackingRaport.Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RaportDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PackingRaportConection")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<RaportDbContext>();

builder.Services.AddTransient<IRaportRepositories, RaportRepository>()
                .AddTransient<IUserRepository, UserRepository>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
