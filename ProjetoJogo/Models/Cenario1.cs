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
            Descricao = "Droga, não acredito estavamos a caminho da grande nave quando derrepente eu acordo aqui sozinho! Estou achando que me deixaram para tras, me abandonaram como um lixo descartavel que não teria mais motivo para efetuar coisa alguma neste horrivel mundo. Só sei que tenho a obrigação de escapar daqui, de tentar ir para algum lugar melhor, onde eu possa viver em paz, longe desses grandes problemas";
            Opcao1 = "Decidir correr contra o tempo";
            Opcao2 = "Decidir desistir";
        }

        public string EscolherOpcao(string escolha)
        {
            if (escolha == Opcao1)
            {
                return "Você acredita que ainda possa haver alguma salvação e acaba por continuar achando tentativas de se virar para chegar até a grande nave!";
            }
            else if (escolha == Opcao2)
            {
                return "Você acaba por ficar parado esperando até seu ultimo suspiro, quando aparece uma maldita criatura e arranca seu pescoço, com uma mordida somente!";
            }
            else
            {
                return "Opção inválida.";
            }
        }
    }
}


