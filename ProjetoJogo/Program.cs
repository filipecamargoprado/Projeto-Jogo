using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => 
{
    var html = @"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<style>

button {
  margin-top: 10px;
}

</style>
<body>
        <h1>Jogo - Escolhas do destino</h1>
        <h3>Instruções do jogo</h3> 
        <p>Selecione a opção que você deseja escolher, o jogo baseia-se em uma história onde o usuário vai criando seu final e vai selecionando os próximos passos.</p>
            <form action='/escolher' method='post'>
                <input type='radio' name='opcao' value='1' required> Opção 1<br>
                <input type='radio' name='opcao' value='2'> Opção 2<br>
                <button type='submit'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});



app.MapPost("/escolher", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcaoEscolhida = formData["opcao"];

    Cenario1 cenario = new Cenario1();
    string resultado = opcaoEscolhida == "1" ? cenario.EscolherOpcao(cenario.Opcao1) : cenario.EscolherOpcao(cenario.Opcao2);

    return Results.Text($"<h1>Resultado: {resultado}</h1>", "text/html");
});
app.Run();
