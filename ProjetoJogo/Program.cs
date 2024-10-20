using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using API.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<JogoContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// CRUD - Jogadores
app.MapGet("/jogadores", async (JogoContext db) =>
{
    var jogadores = await db.Jogadores
        .Include(j => j.Escolhas)
        .Include(j => j.FinalJogo)
        .ToListAsync();
    return await db.Jogadores.ToListAsync();
});

app.MapGet("/jogador/{id:int}", async (int id, JogoContext db) =>
{
    var jogador = await db.Jogadores
        .Include(j => j.Escolhas)
        .Include(j => j.FinalJogo)
        .FirstOrDefaultAsync(j => j.Id == id);
    if (jogador == null)
    {
        return Results.NotFound("Jogador não encontrado.");
    }
    return Results.Ok(jogador);
});

app.MapPost("/jogadores", async (JogoContext db, Jogador jogador) =>
{
    db.Jogadores.Add(jogador);
    await db.SaveChangesAsync();
    return Results.Ok(jogador);
});

app.MapPut("/jogadores/{id}", async (JogoContext db, int id, Jogador updatedJogador) =>
{
    var jogador = await db.Jogadores.FindAsync(id);
    if (jogador == null) return Results.NotFound();


    jogador.FinalJogoId = updatedJogador.FinalJogoId;
    await db.SaveChangesAsync();
    return Results.Ok(jogador);
});

app.MapDelete("/jogadores/{id}", async (JogoContext db, int id) =>
{
    var jogador = await db.Jogadores.FindAsync(id);
    if (jogador == null) return Results.NotFound();

    db.Jogadores.Remove(jogador);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// Cenários e Finais
app.MapPost("/iniciar-jogo", async (JogoContext db, string nomeJogador) =>
{
    var jogador = new Jogador { FinalJogoId = 1 };
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

app.MapPost("/escolher1", async (HttpContext context, JogoContext db) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcao = formData["opcao"];
    
    if (opcao == "1") return Results.Redirect("/cenario2");
    else return Results.Redirect("/Final: Morte");
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

app.MapPost("/escolher2", async (HttpContext context, JogoContext db) =>
{
    var formData = await context.Request.ReadFormAsync();
    var opcaoEscolhida = formData["opção"];
    string? opcao = formData["opcao"];

    Cenario2 cenario = new Cenario2();

    string resultado = opcaoEscolhida == "1" ? cenario.EscolherOpcao(cenario.Opcao1) : cenario.EscolherOpcao(cenario.Opcao2);

    if (opcao == "1") return Results.Redirect("/cenario5");
    else return Results.Redirect("/cenario3");
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
            <form action='/escolher3' method='post'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

app.MapPost("/escolher3", async (HttpContext context, JogoContext db) =>
{
    var formData = await context.Request.ReadFormAsync();
    string? opcao = formData["opcao"];
    
    if (opcao == "1") return Results.Redirect("/cenario4");
    else return Results.Redirect("/cenario3");
});

//Cenário 4
app.MapGet("/cenario4", () => 
{
    var cenario = new Cenario4();
    var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
<h3>Cenário 4: </h3> 
        <p>{cenario.Descricao}</p>
            <form action='/cenariofinalruim' method='get'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

//Cenário 5
app.MapGet("/cenario5", () => 
{
    var cenario = new Cenario5();
    var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
<h3>Cenário 5: </h3> 
        <p>{cenario.Descricao}</p>
            <form action='/Final: Bom' method='get'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

//Cenário 6
app.MapGet("/CenarioFinalRuim", () => 
{
    var cenario = new CenarioFinalRuim();
    var html = $@"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Minha Aplicação ASP.NET</title>
</head>
<body>
<h3>Cenário Final: </h3> 
        <p>{cenario.Descricao}</p>
            <form action='/Final: Ruim' method='get'>
                <input type='radio' name='opcao' value='1' required> {cenario.Opcao1}<br>
                <button type='submit' style='margin-top: 10px;'>Enviar Escolha</button>
            </form>
</body>
</html>";
    return Results.Text(html, "text/html"); 
});

app.MapGet("/Final: Ruim", () =>
{
    var html = @"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Final 2</title>
</head>
<body>
    <h3>Final 3: Contaminação</h3>
    <p>Você conseguiu fugir, porém se transformou em um dos monstros e contaminou toda a nave, acabando com o restante da raça humana que ainda estava viva.</p>
</body>
</html>";
    return Results.Text(html, "text/html");
});

app.MapGet("/Final: Bom", () =>
{
    var html = @"
    <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Final 2</title>
</head>
<body>
    <h3>Final 2: Fuga</h3>
    <p>Você Chegou até a Nave. Fim de jogo.</p>
</body>
</html>";
    return Results.Text(html, "text/html");
});

app.MapGet("/Final: Morte", () =>
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

