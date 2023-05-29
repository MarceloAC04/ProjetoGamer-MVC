using Microsoft.EntityFrameworkCore;
using ProjetoGamer_MVC.Models;

namespace ProjetoGamer_MVC.Infra
{
    public class Context : DbContext
    {
        public Context()
        {  
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
           {
            // string de conexão com o banco
            // Data source : o nome do gerenciador do banco
            // initial catalog : o nome do banco de dados

            // Autenticação do Windows
            // Integrated Security : Autenticação do Windows
            // TrustServerCertificate :

            // Autenticação pelo SqlServer
            //User Id = "Nome do seu usuario de login"
            //pmd = "senha do seu usuario"

             optionsBuilder.UseSqlServer("Data Source = ; initial catalog = gamerMVC; Integrated Security = true; TrustServerCertificate = true");
           }
        }
    }

    public DbSet<Jogador> Jogador {get; set;}

    public DbSet<Equipe> Equipe {get; set;}
}