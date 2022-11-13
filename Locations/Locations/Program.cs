using Locations.Context;
using Locations.Services;
using Locations.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dbconn = System.Environment.GetEnvironmentVariable("DB_CONN_LOCATIONS", EnvironmentVariableTarget.Machine);

builder.Services.AddTransient<IIBGEService, IBGEService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseMySql(
              dbconn,
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"), options => options.EnableRetryOnFailure()));
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
