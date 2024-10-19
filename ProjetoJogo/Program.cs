using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Rota inicial que retorna um HTML simples
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
    <h1>Bem-vindo à Minha Aplicação!</h1>
            <p>Digite um valor para B:</p>
            <form action='/capturar' method='post'>
                <input type='number' name='valor' required>
                <button type='submit'>Enviar</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); // Retorna o HTML com o tipo de conteúdo correto
});

// Endpoint para capturar o valor
app.MapPost("/capturar", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    if (formData.ContainsKey("valor"))
    {
        if (int.TryParse(formData["valor"], out int valor))
        {
            return Results.Text($"Valor {valor} capturado com sucesso!", "text/html"); // Retorna a resposta como HTML
        }
        else
        {
            return Results.Text("Por favor, insira um número válido.", "text/html");
        }
    }
    return Results.Text("Valor não fornecido.", "text/html");
});

app.Run();
