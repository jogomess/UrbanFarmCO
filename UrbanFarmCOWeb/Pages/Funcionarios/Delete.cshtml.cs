﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Pages.Funcionarios
{
    public class DeleteModel : PageModel
    {
        private readonly UrbanFarmCOWeb.Data.UrbanFarmDbContext _context;

        public DeleteModel(UrbanFarmCOWeb.Data.UrbanFarmDbContext context)
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

            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(m => m.FuncionarioID == id);

            if (funcionario == null)
            {
                return NotFound();
            }
            else
            {
                Funcionario = funcionario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                Funcionario = funcionario;
                _context.Funcionarios.Remove(Funcionario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
