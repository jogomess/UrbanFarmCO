using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar o UrbanFarmDbContext no cont�iner de servi�os
builder.Services.AddDbContext<UrbanFarmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrbanFarmDb")));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
