using TargetSistemas_Desafio;
using TargetSistemas_Desafio.Desafio02;

public class EstoqueView
{
    private readonly string DEFAULT_PATH = "./Data/Desafio02/estoque.json";

    private EstoqueService ServicoEstoque;

    public void Start()
    {

        Console.Clear();
        Console.Write($"Informe o arquivo inicial do estoque, ou ENTER para usar padrão ({DEFAULT_PATH}):");
        var caminhoArquivo = Console.ReadLine()?.Trim();

        if (String.IsNullOrEmpty(caminhoArquivo))
        {
            caminhoArquivo = DEFAULT_PATH;
        }

        try
        {
            Console.WriteLine($"Carregando estoque... ");
            var dadosEstoque = JsonReader.Read<DadosEstoque>(caminhoArquivo);
            ServicoEstoque = new EstoqueService(dadosEstoque.estoque);

            Console.WriteLine("Estoque carregado...");

            EstoqueActions(dadosEstoque);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"<< Erro: {ex.Message} >>");
        }
    }

    private void EstoqueActions(DadosEstoque dados)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" ==== Sistema de Movimentação de Estoque ====");
            Console.WriteLine("\nEscolha uma opção...");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Consultar Produto");
            Console.WriteLine("3 - Realizar Movimentação");
            Console.WriteLine("4 - Ver Movimentações");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            var opt = Console.ReadLine()?.Trim();

            switch (opt)
            {
                case "0":
                    return;
                case "1":
                    Listar();
                    break;
                case "2":
                    Consultar();
                    break;
                case "3":
                    Movimentar();
                    break;
                case "4":
                    VerMovimentacoes();
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nPressione ENTER para continuar");
            Console.ReadLine();
        }
    }

    private void Listar()
    {
        ImprimirHeaderProduto();
        foreach (var produto in ServicoEstoque.Produtos ?? [])
        {
            ImprimirProduto(produto);
        }
    }

    private void Consultar()
    {
        Console.WriteLine();
        Console.Write("- Informe o Código do Produto: ");
        var codigoInput = Console.ReadLine()?.Trim();

        int.TryParse(codigoInput, out int codigo);
        var produto = ServicoEstoque.ObterProduto(codigo);

        if (produto == null)
        {
            Console.WriteLine("Código de Produto Inválido!");
        }
        else
        {
            ImprimirHeaderProduto();
            ImprimirProduto(produto);
        }
    }

    private void Movimentar()
    {
        TipoMovimentacao? movimentacao = null;
        while (movimentacao == null)
        {
            Console.Write("- Tipo de movimentação - Entrada(E) ou Saída(S) - [ou Cancelar (c)]: ");
            var mov = Console.ReadLine()?.Trim().ToLower();

            switch (mov)
            {
                case "e":
                    movimentacao = TipoMovimentacao.Entrada;
                    break;
                case "s":
                    movimentacao = TipoMovimentacao.Saida;
                    break;
                case "c":
                    return;
                default:
                    Console.WriteLine("<< Erro: Opção Inválida. Tente Novamente! >>");
                    Console.WriteLine();
                    break;
            }
        }

        int codigo = 0;
        int quantidade = 0;

        while (codigo == 0 || quantidade <= 0)
        {
            Console.Write("- Informe o Código do Produto e quantidade (ex. 101 - 3) [ou Cancelar (c)]: ");
            var resposta = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (resposta == "c")
            {
                return;
            }

            var valores = resposta.Split("-") ?? [];
            if (valores.Count() != 2)
            {
                Console.WriteLine("<< Erro: Valor Inválido. Tente Novamente! >>");
                Console.WriteLine();
                continue;
            }

            int.TryParse(valores[0], out codigo);
            int.TryParse(valores[1], out quantidade);

            if (codigo == 0 || quantidade <= 0)
            {
                Console.WriteLine("<< Erro: Valor Inválido. Tente Novamente! >>");
                Console.WriteLine();
            }
        }

        try
        {
            var produto = ServicoEstoque.MovimentarEstoque(codigo, movimentacao.Value, quantidade);

            Console.WriteLine();
            Console.WriteLine($"{movimentacao.Value} de Estoque realizada com sucesso!");
            ImprimirHeaderProduto();
            ImprimirProduto(produto);
        }
        catch (Exception e)
        {
            Console.WriteLine($"<< Erro: {e.Message} >>");
            Console.WriteLine();
        }
    }

    private void VerMovimentacoes()
    {
        var colCod = "Produto".PadRight(8);
        var colMov = "Tipo Movimentação".PadRight(20);
        var colQtde = "Qtde".PadRight(6);
        var colData = "Data".PadRight(22);
        Console.WriteLine($" | {colCod}\t| {colMov}\t| {colQtde} \t| {colData} |");

        if (ServicoEstoque.Movimentacoes.Count == 0)
        {
            Console.WriteLine($"<< Nenhuma Movimentação realizada! >>");
            Console.WriteLine();
        }
        else
        {
            foreach (var movimentacao in ServicoEstoque.Movimentacoes)
            {
                var codProduto = movimentacao.CodigoProduto.ToString().PadRight(8);
                var tipoMovimentacao = movimentacao.Tipo.ToString().PadRight(20);
                var qtde = movimentacao.Quantidade.ToString().PadLeft(6);
                var data = movimentacao.Data.ToString("dd/MM/yyyy HH:mm:ss").PadRight(22);
                Console.WriteLine($" | {codProduto}\t| {tipoMovimentacao}\t| {qtde} \t| {data} |");
            }
        }
    }

    private void ImprimirHeaderProduto()
    {
        var colCod = "Código".PadRight(6);
        var colDesc = "Descrição".PadRight(30);
        var colEstoque = "Estoque".PadRight(8);
        Console.WriteLine($" | {colCod}\t| {colDesc}\t| {colEstoque} |");

    }

    private void ImprimirProduto(Produto item)
    {
        var cod = item.CodigoProduto.ToString().PadRight(6);
        var desc = item.DescricaoProduto.Substring(0, Math.Min(item.DescricaoProduto.Length, 30));
        desc = desc.PadRight(30);
        var estoque = item.Estoque.ToString().PadLeft(8);
        Console.WriteLine($" | {cod}\t| {desc}\t| {estoque} |");
    }
}