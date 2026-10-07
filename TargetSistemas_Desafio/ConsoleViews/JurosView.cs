using System.Globalization;
using TargetSistemas_Desafio.Desafio03;

public class JurosView
{
    public void Start()
    {

        Console.Clear();
        Console.WriteLine("\nCálculo de Juros Diário!\n");
        var DataVencimento = GetDataVencimento();
        if (DataVencimento == null) return;

        var Valor = GetValor();
        if (Valor == null) return;

        try
        {
            var Juros = JurosService.Calcular(DateTime.Now, DataVencimento.Value, Valor.Value);

            if (Juros == 0) Console.WriteLine("Nenhum Juros à Pagar!");
            else Console.WriteLine($"\t- O Juros à Pagar é de: {Juros:F2}.\n\t- Valor Total: {Valor + Juros:F2}");
        }
        catch (Exception e)
        {

            Console.WriteLine($"<< Erro: {e.Message}>>");
            Console.WriteLine();
        }


    }


    private DateTime? GetDataVencimento()
    {
        DateTime? data = null;
        while (data == null)
        {
            Console.Write($"Informe a Data de vencimento (dd/MM/yyyy) [Cancelar (c)]: ");
            var strVencimento = Console.ReadLine()?.Trim();
            if (strVencimento == "c")
            {
                return null;
            }

            data = DateTime.TryParseExact(
                strVencimento,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime tentativa
            ) ? tentativa : null;


            if (data == null)
            {
                Console.WriteLine("<< Erro: Data Inválida! Tente Novamente! >>");
                Console.WriteLine();
            }

        }

        return data.Value;
    }

    private decimal? GetValor()
    {
        decimal? valor = null;
        while (valor == null)
        {
            Console.Write($"Informe o valor [Cancelar (c)]: ");
            var strValor = Console.ReadLine()?.Trim();
            if (strValor == "c")
            {
                return null;
            }

            decimal.TryParse(strValor, out decimal tentativa);

            if (tentativa > 0)
            {
                valor = tentativa;
                break;
            }
            else
            {
                Console.WriteLine("<< Erro: Valor Inválido! Deve ser Positivo maior que ZERO! >>");
                Console.WriteLine();
            }

        }

        return valor.Value;
    }
}