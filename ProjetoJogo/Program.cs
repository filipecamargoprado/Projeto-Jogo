using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Rota inicial que retorna um HTML simples
app.MapGet("/", () => 
{
    var cenario = new Cenario1();


    var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
        <h1>{cenario.Descricao}</h1>
            <form action='/escolher' method='post'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <input type='radio' name='opcao' value='2'> {cenario.Opcao2}<br>
                <button type='submit'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); // Retorna o HTML com o tipo de conteúdo correto
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

