using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanFarmAPI.Data;
using UrbanFarmAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly UrbanFarmDbContext _context;

        public FuncionariosController(UrbanFarmDbContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // POST: api/Funcionarios
        [HttpPost]
        public async Task<ActionResult<Funcionario>> CreateFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.FuncionarioID }, funcionario);
        }

        // PUT: api/Funcionarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioID)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Funcionarios/login
        [HttpPost("login")]
        public async Task<ActionResult<Funcionario>> Login([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Senha))
            {
                return BadRequest("E-mail e senha são obrigatórios.");
            }

            // Encontra o funcionário que corresponde ao e-mail e à senha fornecidos
            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Email == loginRequest.Email && f.SenhaHash == loginRequest.Senha);

            if (funcionario == null)
            {
                return Unauthorized("E-mail ou senha incorretos.");
            }

            return Ok(funcionario);
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioID == id);
        }

        // Classe auxiliar para representar os dados de login
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Senha { get; set; }
        }

        [HttpPut("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Email == request.Email);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            // Atualizar a senha (aqui você deve aplicar o hash adequado antes de salvar)
            funcionario.SenhaHash = request.SenhaHash; // Hash a senha apropriadamente
            await _context.SaveChangesAsync();

            return Ok("Senha atualizada com sucesso.");
        }

        public class ResetPasswordRequest
        {
            public string Email { get; set; }
            public string SenhaHash { get; set; }
        }


    }

}
