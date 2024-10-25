using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanFarmAPI.Data;
using UrbanFarmAPI.Models;

namespace UrbanFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly UrbanFarmDbContext _context;

        public FornecedoresController(UrbanFarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return fornecedor;
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> CreateFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.FornecedorID }, fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.FornecedorID)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Fornecedores.Any(e => e.FornecedorID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
