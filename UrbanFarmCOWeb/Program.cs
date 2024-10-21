using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar o UrbanFarmDbContext no contêiner de serviços
builder.Services.AddDbContext<UrbanFarmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrbanFarmDb")));

builder.Services.AddRazorPages();

// Configurar o serviço de autenticação
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login"; // Define a página de login padrão
        options.LogoutPath = "/Login/Login"; // Define a página de logout, se houver
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Coloque UseAuthentication antes de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

// Middleware para redirecionar usuários não autenticados
app.Use(async (context, next) =>
{
    if (!context.User.Identity.IsAuthenticated && context.Request.Path != "/Login/Login")
    {
        context.Response.Redirect("/Login/Login");
    }
    else
    {
        await next.Invoke();
    }
});

app.MapRazorPages();

app.Run();
