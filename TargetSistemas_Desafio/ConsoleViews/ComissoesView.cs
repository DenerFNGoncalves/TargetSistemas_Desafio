
using TargetSistemas_Desafio;
using TargetSistemas_Desafio.Desafio01;

public class ComissoesView
{
    public static void Start()
    {
        var comissaoService = new ComissaoVendedorService();

        Console.WriteLine("=== Desafio 01 ===");
        try
        {
            Console.WriteLine("Lendo dados arquivo de vendas...");
            var dadosVendas = JsonReader.Read<DadosDeVendas>("./Data/vendas.json");

            Console.WriteLine($"Idenfificado {dadosVendas.Vendas.Count} vendas realizadas... ");

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
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}