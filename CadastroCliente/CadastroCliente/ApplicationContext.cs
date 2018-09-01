using CadastroCliente.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbProjeto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}