using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;

namespace UrbanFarmCOWeb.Pages.Login
{
    public class EsqueciSenhaModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        [BindProperty]
        public string Email { get; set; }

        public string Mensagem { get; set; }

        public EsqueciSenhaModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                ModelState.AddModelError(string.Empty, "Email é obrigatório.");
                return Page();
            }

            // Verificar se o email existe no banco de dados
            var user = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Email == Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email não encontrado.");
                return Page();
            }

            // Redireciona para a página de redefinição de senha
            return RedirectToPage("/Login/RedefinirSenha", new { email = Email });
        }
    }
}
