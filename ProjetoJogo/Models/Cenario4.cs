using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario4
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }

        public Cenario4()
        {
            Descricao = "Você escolhe ir a nave ou não?";
            Opcao1 = "Ir a nave!";
            Opcao2 = "Ficar!";
        }

        public string EscolherOpcao(string escolha)
        {
            if (escolha == Opcao1)
            {
                return "Você chega a nave, entretanto quando a nave decola e todas as pessoas chegam até o espaço, você vira um daqueles monstros e mata a todos que estãoo na nave acabando assim com toda a população humana.";
            }
            else if (escolha == Opcao2)
            {
                return "Você morre se sentindo um heroi, mas é esquecido como havia sido antes. Entretanto por conta de voce nao ter entrado na nave, a humanidade se safa de todos os problemas envolvendo zumbis existentes";
            }
            else
            {
                return "Opção inválida.";
            }
        }
    }
}


