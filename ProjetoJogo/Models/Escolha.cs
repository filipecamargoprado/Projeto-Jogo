using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using API.Models;

namespace API.Models
{
    public class Escolha
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? OpcaoEscolhida { get; set; }
        public int JogadorId { get; set; } // Relacionamento com Jogador
        public Jogador? Jogador { get; set; }
    }
}
