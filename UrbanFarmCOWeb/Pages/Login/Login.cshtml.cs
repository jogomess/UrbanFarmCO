using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        public LoginModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Senha { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Verificar se o usu�rio existe no banco de dados
                var user = await _context.Funcionarios
                                         .FirstOrDefaultAsync(f => f.Email == Email && f.SenhaHash == Senha);
                if (user != null)
                {
                    // Configurar a autentica��o do usu�rio
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Nome),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redirecionar para o Dashboard
                    return RedirectToPage("/Dashboard/Dashboard");
                }
                else
                {
                    ErrorMessage = "Usu�rio ou senha inv�lidos.";
                }
            }
            return Page();
        }
    }
}
