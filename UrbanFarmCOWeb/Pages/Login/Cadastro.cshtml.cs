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
            // L�gica para a p�gina de cadastro quando for carregada.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Se a valida��o falhar, volte para a mesma p�gina.
            }

            // Adiciona o novo funcion�rio ao banco de dados
            _context.Funcionarios.Add(Funcionario);
            await _context.SaveChangesAsync();

            // Redireciona para a p�gina de login ap�s o cadastro bem-sucedido
            return RedirectToPage("/Login/Login");
        }
    }
}
