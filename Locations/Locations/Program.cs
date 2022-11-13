using Locations.Context;
using Locations.Services;
using Locations.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IIBGEService, IBGEService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseMySql(
        "server=locations.cpdb1zmgllha.us-east-1.rds.amazonaws.com:3306;initial catalog=DB_LOCALIDADES;uid=admin;pwd=FPqRA1TrltfFLPafC97X",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));

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
