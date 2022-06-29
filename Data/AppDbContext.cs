using AluraFlix.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Data
{
    //Representação do Banco de Dados, onde ele é mapeado
    public class AppDbContext : DbContext
    {
        // O DbSet é a representação da tabela de vídeos
        public DbSet<Video> Videos { get; set; }

        //Aqui estou setando a ConnectionString do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
