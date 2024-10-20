using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using API.Models;


using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class JogoContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Escolha> Escolhas { get; set; }
        public DbSet<FinalJogo> Finais { get; set; }

        public JogoContext(DbContextOptions<JogoContext> options) : base(options) { }
    }
}
