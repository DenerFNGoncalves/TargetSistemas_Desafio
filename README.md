# Target Sistemas: Desafios

Este projeto é um teste/desafio em C# desenvolvido como aplicação de console. Ele apresenta um menu com três desafios diferentes, que podem ser executados separadamente:

- Desafio 01: Cálculo de comissão de vendas
- Desafio 02: Gestão de estoque
- Desafio 03: Cálculo de juros

## Requisitos

Antes de executar o projeto, verifique se você possui o .NET SDK instalado.

- .NET SDK 10.0 ou superior

## Estrutura do projeto

- `TargetSistemas_Desafio/` - projeto principal da aplicação
- `Data/` - arquivos JSON utilizados pelos desafios
- `Models/` - modelos de domínio
- `Services/` - lógica de negócio
- `ConsoleViews/` - interface do menu e telas dos desafios

## Como executar

Abra o terminal na pasta raiz do projeto e execute os comandos abaixo:

```bash
dotnet restore
```

```bash
dotnet run --project TargetSistemas_Desafio/TargetSistemas_Desafio.csproj
```

Se preferir, pode navegar até a pasta do projeto e rodar:

```bash
cd TargetSistemas_Desafio
dotnet run
```

## Menu da aplicação

Ao iniciar, o programa exibe um menu com as opções:

1. Desafio 01
2. Desafio 02
3. Desafio 03
0. Sair

Selecione a opção desejada e siga as instruções exibidas no console.

## Observações

- O projeto foi construído como um teste prático de lógica e processamento em C#.
- Os dados de exemplo utilizados pelos desafios ficam na pasta `Data`.
- A execução é via terminal/console, sem interface gráfica.
