using System.Runtime.InteropServices;
using API.Models;


namespace API.Models
{
    public class CenarioFinalBom
    {
        public string Descricao { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }

        public CenarioFinalBom()
        {
            Descricao = "Você escolhe ir a nave ou não?";
            Opcao1 = "Ir a nave!";
            Opcao2 = "Ficar!";
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
<p>Você chega a nave, entretanto quando a nave decola e todas as pessoas chegam até o espaço, você vira um daqueles monstros e mata a todos que estão na nave acabando assim com toda a população humana.</p>
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
<p>Você morre se sentindo um heroi, mas é esquecido como havia sido antes. Entretanto por conta de voce nao ter entrado na nave, a humanidade se safa de todos os problemas envolvendo zumbis existentes.</p>
            <form action='/' method='get'>
            <button type='submit'>Finalizar</button>
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


