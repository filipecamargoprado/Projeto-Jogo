using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario4
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }

        public Cenario4()
        {
            Descricao = "Você arromba a porta e é pego desprevinido por um monstro";
            Opcao1 = "Tentar fugir";
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
            <form action='/cenariofinalruim' method='get'>
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


