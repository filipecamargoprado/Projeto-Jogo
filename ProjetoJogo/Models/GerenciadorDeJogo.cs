using System.Runtime.InteropServices;
using API.Models;

namespace API.Models
{
    public class GerenciadorDeJogo
    {
        public void IniciarJogo()
        {
            Cenario1 cenario = new Cenario1();
            Console.WriteLine(cenario.Descricao);

            // Exibe as opções
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. " + cenario.Opcao1);
            Console.WriteLine("2. " + cenario.Opcao2);

            // Captura a escolha do usuário
            string? escolhaUsuario = Console.ReadLine();
            string escolha = escolhaUsuario == "1" ? cenario.Opcao1 : cenario.Opcao2;

            // Mostra o resultado baseado na escolha
            string resultado = cenario.EscolherOpcao(escolha);
            Console.WriteLine(resultado);
        }
    }
}
