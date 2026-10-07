
using TargetSistemas_Desafio;
using TargetSistemas_Desafio.Desafio01;

public class ComissoesView
{
    private readonly string DEFAULT_PATH = "./Data/Desafio01/vendas.json";
    public void Start()
    {
        var comissaoService = new ComissaoVendedorService();

        Console.WriteLine("=== Desafio 01 ===");
        try
        {
            Console.Write($"Informe o arquivo inicial do estoque, ou ENTER para usar padrão ({DEFAULT_PATH}):");
            var caminhoArquivo = Console.ReadLine()?.Trim() ?? DEFAULT_PATH;
            if (String.IsNullOrEmpty(caminhoArquivo))
            {
                caminhoArquivo = DEFAULT_PATH;
            }

            Console.WriteLine("Lendo dados arquivo de vendas...");
            var dadosVendas = JsonReader.Read<DadosDeVendas>(caminhoArquivo);

            Console.WriteLine($"Idenficado {dadosVendas.Vendas.Count} vendas realizadas... ");

            Console.WriteLine("Calculando comissões... ");
            var comissoes = comissaoService.getListaComissao(dadosVendas.Vendas);

            Console.WriteLine("\nResultado:");
            foreach (var comissao in comissoes)
            {
                Console.WriteLine(
                    $"\t- {comissao.Vendedor}: Vendeu R$ {comissao.TotalVendido:F2}. Comissão: R$ {comissao.ValorComissao:F2}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"<< Erro: {ex.Message} >> ");
            Console.WriteLine();
        }
    }
}