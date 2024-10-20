using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario5
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }

        public Cenario5()
        {
            Descricao = "Você silenciosamente entra em uma casa abandonada onde encontra uma barra de ferro e encontra um monstro que está preste a te atacar";
            Opcao1 = "Executar monstro";
        }

        public string EscolherOpcao(string escolha)
        {
            if (escolha == Opcao1)
            {
                var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
<p>Nada acontece.</p>
            <form action='' method='get'>
            <button type='submit'>Continuar jogo</button>
        </form>    
</body>
</html>";
                return html;
            }
            else
            {
                return "Opção inválida.";
            }
        }
    }
}


