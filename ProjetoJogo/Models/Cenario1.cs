using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario1
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }

        public Cenario1()
        {
            Descricao = "Você encontra uma bifurcação no caminho. O que você faz?";
            Opcao1 = "Ir para a esquerda";
            Opcao2 = "Ir para a direita";
        }

        public string EscolherOpcao(string escolha)
        {
            if (escolha == Opcao1)
            {
                return "Você foi pela esquerda e encontrou um tesouro!";
            }
            else if (escolha == Opcao2)
            {
                return "Você foi pela direita e encontrou um monstro!";
            }
            else
            {
                return "Opção inválida.";
            }
        }
    }
}
