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
            else if (escolha == Opcao2)
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
<p>Voce acaba voltando para a direção na qual veio e acha um maldito monstro, com grandes dificuldades voce acaba sendo mordido pelo monstro, mas o mata estando livre para se decidir se opta por chegar a nave ou não.</p>
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


