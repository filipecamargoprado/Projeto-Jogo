using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Escolha>? Escolhas { get; set; }
        public int FinalJogoId { get; set; } // Relacionamento com FinalJogo
        public FinalJogo? FinalJogo { get; set; }
    }
}
