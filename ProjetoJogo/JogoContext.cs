using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class JogoContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Escolha> Escolhas { get; set; }
        public DbSet<FinalJogo> Finais { get; set; }

        public JogoContext(DbContextOptions<JogoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed inicial para os finais
            modelBuilder.Entity<FinalJogo>().HasData(
                new FinalJogo { Id = 1, TipoFinal = "Final Indefinido" },
                new FinalJogo { Id = 2, TipoFinal = "Final Bom" },
                new FinalJogo { Id = 3, TipoFinal = "Final Ruim" },
                new FinalJogo { Id = 4, TipoFinal = "Morte" }
            );
        }
    }
}