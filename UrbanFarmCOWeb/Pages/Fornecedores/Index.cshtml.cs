using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Data;
using UrbanFarmCOWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UrbanFarmCOWeb.Pages.Fornecedores
{
    public class IndexModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        public IndexModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        public IList<UrbanFarmCOWeb.Models.Fornecedor> Fornecedores { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            var fornecedores = from f in _context.Fornecedores
                               select f;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                fornecedores = fornecedores.Where(f => f.Nome.Contains(SearchTerm) || f.CNPJ.Contains(SearchTerm));
            }

            Fornecedores = await fornecedores.ToListAsync();
        }
    }
}
