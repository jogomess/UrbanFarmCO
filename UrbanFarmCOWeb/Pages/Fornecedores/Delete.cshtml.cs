using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Pages.Fornecedor
{
    public class DeleteModel : PageModel
    {
        private readonly UrbanFarmCOWeb.Data.UrbanFarmDbContext _context;

        public DeleteModel(UrbanFarmCOWeb.Data.UrbanFarmDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UrbanFarmCOWeb.Models.Fornecedor Fornecedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(m => m.FornecedorID == id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            else
            {
                Fornecedor = fornecedor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                Fornecedor = fornecedor;
                _context.Fornecedores.Remove(Fornecedor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
