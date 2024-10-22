using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace UrbanFarmCOWeb.Pages.Login
{
    public class RedefinirSenhaModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        [BindProperty]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }

        [BindProperty]
        [Required]
        [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem.")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }

        public RedefinirSenhaModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return RedirectToPage("/Login/Login");
            }

            Email = email;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar o usuário pelo email
            var user = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Email == Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
                return Page();
            }

            // Atualizar a senha (simplesmente para efeito de simulação)
            user.SenhaHash = NovaSenha; // Idealmente, você deve usar hash para salvar senhas.
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login/Login");
        }
    }
}
