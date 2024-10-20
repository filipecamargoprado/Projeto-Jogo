using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using API.Models;



namespace API.Models
{
    public class FinalJogoTeste
    {
        public int Id { get; set; }
        public string? TipoFinal { get; set; } // Ex: "Final Bom", "Final Ruim", "Morte"
    }
}
