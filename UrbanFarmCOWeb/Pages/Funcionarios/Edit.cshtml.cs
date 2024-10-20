using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Pages.Funcionarios
{
    public class EditModel : PageModel
    {
        private readonly UrbanFarmCOWeb.Data.UrbanFarmDbContext _context;

        public EditModel(UrbanFarmCOWeb.Data.UrbanFarmDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcionario Funcionario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario =  await _context.Funcionarios.FirstOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            Funcionario = funcionario;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(Funcionario.FuncionarioID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioID == id);
        }
    }
}
