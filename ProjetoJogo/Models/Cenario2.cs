using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class Cenario2
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }

        public Cenario2()
        {
            Descricao = "Voce estava desmaiado por algum tempo desconhecido, não sabe se dizer ao certo quanto tempo se passou desde que ocorrera o desmaio e então, você escuta o barulho de alguma coisa se aproximando:";
            Opcao1 = "Se esconder";
            Opcao2 = "Gritar por ajuda";
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
<p>Você corre até um lugar onde pode ficar escondido e encontra uma barra de ferro, o que te faz seguir seu caminho e continuar sua jornada de chegar até a nave, porém neste caminho você acaba por encontrar um maldito monstro que tenta arrancar sua cabeça com uma mordida somente, mas com uma barra de ferro voce acaba o matando e acabando com sua raça e consegue chegar a nave a tempo de se salvar e acabar com todos os problemas.</p>
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
<p>Voce acaba por escutar um barulhjo ensurdecedor onde fica com medo e sai a correr até achar uma porta, ao tentar abri-la a mesma se encontra trancada:</p>
            <form action='' method='get'>
            <button type='submit'>Continuar jogo</button>
        </form>    
</body>
</html>";
                return html;
            }//continua no cenario 3
            else
            {
                return "Opção inválida.";
            }
        }
    }
}


