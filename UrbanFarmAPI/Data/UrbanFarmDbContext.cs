using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UrbanFarmAPI.Models;

namespace UrbanFarmAPI.Data
{
    public class UrbanFarmDbContext : DbContext
    {
        public UrbanFarmDbContext(DbContextOptions<UrbanFarmDbContext> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
