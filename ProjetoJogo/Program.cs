var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Página inicial
app.MapGet("/", () => 
    "Jogo - Escolhas do destino\n\n" +
    "Explicação do jogo: O jogo consiste em uma escolha de opções conforme a história " +
    "vai se desenvolvendo, o que resulta no destino final do jogador, cada escolha tem uma consequência.\n\n" +
    "Escolha uma opção:\n" +
    "1. [Opção 1](http://localhost:5000/opcao1)\n" +
    "2. [Opção 2](http://localhost:5000/opcao2)"
);

// Rota para a Opção 1
app.MapGet("/opcao1", () => 
    "Você escolheu a Opção 1! Agora, a história segue esse caminho...");

// Rota para a Opção 2
app.MapGet("/opcao2", () => 
    "Você escolheu a Opção 2! Agora, a história segue esse caminho...");

app.Run();
