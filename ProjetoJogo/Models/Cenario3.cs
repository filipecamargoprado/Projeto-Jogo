using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario3
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }

        public Cenario3()
        {
            Descricao = "Você acaba por escutar um barulhjo ensurdecedor onde fica com medo e sai a correr até achar uma porta, ao tentar abri-la a mesma se encontra trancada:";
            Opcao1 = "Tentar arrombar a porta";
            Opcao2 = "Voltar para outra direção";
        }

        public string EscolherOpcao(string escolha)
        {
            if (escolha == Opcao1)
            {
                return "Nada acontece.";
            }
            else if (escolha == Opcao2)
            {
                return " Voce acaba voltando para a direção na qual veio e acha um maldito monstro, com grandes dificuldades voce acaba sendo mordido pelo monstro, mas o mata estando livre para se decidir se opta por chegar a nave ou não";
            }
            else
            {
                return "Opção inválida.";
            }
        }
    }
}


