using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class FinalJogo
    {
        public int Id { get; set; }
        public string? TipoFinal { get; set; } // Ex: "Final Bom", "Final Ruim", "Morte"
    }
}
