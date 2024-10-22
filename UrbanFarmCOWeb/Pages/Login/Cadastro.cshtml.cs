using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Pages.Login
{
    public class CadastroModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        [BindProperty]
        public Funcionario Funcionario { get; set; } = new Funcionario();

        public CadastroModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Lógica para a página de cadastro quando for carregada.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Se a validação falhar, volte para a mesma página.
            }

            // Adiciona o novo funcionário ao banco de dados
            _context.Funcionarios.Add(Funcionario);
            await _context.SaveChangesAsync();

            // Redireciona para a página de login após o cadastro bem-sucedido
            return RedirectToPage("/Login/Login");
        }
    }
}
