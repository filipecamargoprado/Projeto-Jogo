using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using API.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<JogoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

app.MapPost("/iniciar-jogo", async (JogoContext db, string nomeJogador) =>
{
    var jogador = new Jogador { Nome = nomeJogador, FinalJogoId = 1 }; // Final "indefinido" no início
    db.Jogadores.Add(jogador);
    await db.SaveChangesAsync();
    return Results.Ok(jogador);
});


//Pagina inicial do jogo
app.MapGet("/", () => 
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
        <h1>Jogo - Escolhas do Destino</h1>
        <p>Seja bem-vindo ao jogo Escolhas do Destino. Você está em um cenário pós-apocalíptico e precisa tomar decisões para sobreviver. Boa sorte!</p>
        <p><strong> Instruções do jogo: </strong> Em cada cenário, você terá duas opções de escolha. Cada escolha levará a um resultado diferente. Escolha sabiamente!</p>
        <h5>Para começar, clique no botão para iniciar o jogo:</h5>
        <form action='/cenario1' method='get'>
            <button type='submit'>Iniciar jogo</button>
        </form>    
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

//Cenário 1
app.MapGet("/cenario1", () => 
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
<h3>Cenário 1: </h3> 
        <p>{cenario.Descricao}</p>
            <form action='/escolher1' method='post'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <input type='radio' name='opcao' value='2'> {cenario.Opcao2}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

app.MapPost("/escolher1", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcaoEscolhida = formData["opcao"];

    Cenario1 cenario = new Cenario1();
    if (opcaoEscolhida == "1")
        {
            return Results.Redirect("/cenario2");
            
        }
        else
        {
            return Results.Redirect("/Final: Morte");
        }

});

//Cenário 2
app.MapGet("/cenario2", () => 
{
    var cenario = new Cenario2();
    var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
<h3>Cenário 2: </h3> 
        <p>{cenario.Descricao}</p>
            <form action='/escolher2' method='post'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <input type='radio' name='opcao' value='2'> {cenario.Opcao2}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

app.MapPost("/escolher2", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcaoEscolhida = formData["opcao"];

    Cenario2 cenario = new Cenario2();
    string resultado = opcaoEscolhida == "1" ? cenario.EscolherOpcao(cenario.Opcao1) : cenario.EscolherOpcao(cenario.Opcao2);

    return Results.Text($"<h3>Resultado: {resultado}</h3>", "text/html");
});

//Cenário 3
app.MapGet("/cenario3", () => 
{
    var cenario = new Cenario3();
    var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
<h3>Cenário 3: </h3> 
        <p>{cenario.Descricao}</p>
            <form action='/escolher2' method='post'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <input type='radio' name='opcao' value='2'> {cenario.Opcao2}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

app.MapPost("/escolher3", async (HttpContext context) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcaoEscolhida = formData["opcao"];

    Cenario3 cenario = new Cenario3();
    string resultado = opcaoEscolhida == "1" ? cenario.EscolherOpcao(cenario.Opcao1) : cenario.EscolherOpcao(cenario.Opcao2);

    return Results.Text($"<h3>Resultado: {resultado}</h3>", "text/html");
});







app.MapGet("/final: Morte", () =>
{
    var html = @"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Final 1</title>
</head>
<body>
    <h3>Final 1: Morte</h3>
    <p>Você desistiu da sua jornada e acabou sendo derrotado pelas circunstâncias. Fim de jogo.</p>
</body>
</html>";
    return Results.Text(html, "text/html");
});

app.Run();

