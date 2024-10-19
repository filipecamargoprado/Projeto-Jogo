<<<<<<< HEAD
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using API.Models;

=======
>>>>>>> bbe4190f98e4aaf3aec1c33fd63126f0476882c5
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
<body>
<<<<<<< HEAD
        <h1>{cenario.Descricao}</h1>
            <form action='/escolher' method='post'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <input type='radio' name='opcao' value='2'> {cenario.Opcao2}<br>
                <button type='submit'>Enviar Escolha</button>
=======
    <h1>Jogo - Escolhas do Destino</h1>
    <h3> Explicação: O jogo consiste na escolha de diferentes opções que resultam em diferentes finais.</h3> 
    <p> Opção 1: </p> 
    <p> Opção 2: </p> 
            <p>Digite o número da opção escolhida:</p>
            <form action='/capturar' method='post'>
                <input type='number' name='valor' required>
                <button type='submit'>Enviar</button>
>>>>>>> bbe4190f98e4aaf3aec1c33fd63126f0476882c5
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

<<<<<<< HEAD

app.MapPost("/escolher", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcaoEscolhida = formData["opcao"];

    Cenario1 cenario = new Cenario1();
    string resultado = opcaoEscolhida == "1" ? cenario.EscolherOpcao(cenario.Opcao1) : cenario.EscolherOpcao(cenario.Opcao2);

    return Results.Text($"<h1>Resultado: {resultado}</h1>", "text/html");
});







// // Endpoint para capturar o valor
// app.MapPost("/capturar", async (HttpContext context) =>
// {
//     var formData = await context.Request.ReadFormAsync();
//     if (formData.ContainsKey("valor"))
//     {
//         if (int.TryParse(formData["valor"], out int valor))
//         {
//             return Results.Text($"Valor {valor} capturado com sucesso!", "text/html"); // Retorna a resposta como HTML
//         }
//         else
//         {
//             return Results.Text("Por favor, insira um número válido.", "text/html");
//         }
//     }
//     return Results.Text("Valor não fornecido.", "text/html");
// });
=======
app.MapPost("/capturar", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    if (formData.ContainsKey("valor"))
    {
        if (int.TryParse(formData["valor"], out int valor))
        {
            if (valor == 1)
            {
                context.Response.Redirect("/opcao1");
            }
            else if (valor == 2)
            {
                context.Response.Redirect("/opcao2");
            }
            else
            {
                context.Response.Redirect("/opcaoDefault"); 
            }
            return; 
        }
    }
});

// Rota para a Opção 1
app.MapGet("/opcao1", () => 
    "Você foi redirecionado para a Opção 1!");

// Rota para a Opção 2
app.MapGet("/opcao2", () => 
    "Você foi redirecionado para a Opção 2!");
>>>>>>> bbe4190f98e4aaf3aec1c33fd63126f0476882c5

app.Run();
