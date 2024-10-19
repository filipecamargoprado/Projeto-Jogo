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
    <h1>Jogo - Escolhas do Destino</h1>
    <h3> Explicação: O jogo consiste na escolha de diferentes opções que resultam em diferentes finais.</h3> 
    <p> Opção 1: </p> 
    <p> Opção 2: </p> 
            <p>Digite o número da opção escolhida:</p>
            <form action='/capturar' method='post'>
                <input type='number' name='valor' required>
                <button type='submit'>Enviar</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

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

app.Run();
