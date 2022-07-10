using AluraFlix.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.API.Data
{
    //Representação do Banco de Dados, onde ocorre o mapeamento das entidades para as tabelas
    public class AppDbContext : DbContext
    {
        // O DbSet é a representação da tabela das classes
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }

        //Aqui estou setando a ConnectionString do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria { Id = 1, Titulo = "Livre", Cor = "#81C784" });
            modelBuilder.Entity<Video>().Property(x => x.CategoriaId).HasDefaultValue(1);
        }

    }
}
