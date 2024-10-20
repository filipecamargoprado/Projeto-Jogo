using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario3
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }

        public Cenario3()
        {
            Descricao = "Você acaba por escutar um barulho ensurdecedor onde fica com medo e sai a correr até achar uma porta, ao tentar abri-la a mesma se encontra trancada:";
            Opcao1 = "Tentar arrombar a porta";
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
            <form action='/cenario4' method='get'>
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


