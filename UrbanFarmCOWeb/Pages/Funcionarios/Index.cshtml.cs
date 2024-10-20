using System;
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
    public class IndexModel : PageModel
    {
        private readonly UrbanFarmCOWeb.Data.UrbanFarmDbContext _context;

        public IndexModel(UrbanFarmCOWeb.Data.UrbanFarmDbContext context)
        {
            _context = context;
        }

        public IList<Funcionario> Funcionario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Funcionario = await _context.Funcionarios.ToListAsync();
        }
    }
}
