using Microsoft.EntityFrameworkCore;
using UrbanFarmCOWeb.Models;

namespace UrbanFarmCOWeb.Data
{
    public class UrbanFarmDbContext : DbContext
    {
        public UrbanFarmDbContext(DbContextOptions<UrbanFarmDbContext> options) : base(options)
        {
        }

        // Defina os DbSets para as tabelas no banco de dados
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
