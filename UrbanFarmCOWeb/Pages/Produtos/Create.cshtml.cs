using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        public CreateModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produto Produto { get; set; } = default!;

        public SelectList FornecedoresSelectList { get; set; } = default!;

        public IActionResult OnGet()
        {
            FornecedoresSelectList = new SelectList(_context.Fornecedores, "FornecedorID", "Nome");
            return Page();
        }

        // Para mais informações, veja https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                FornecedoresSelectList = new SelectList(_context.Fornecedores, "FornecedorID", "Nome");
                return Page();
            }

            _context.Produtos.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
