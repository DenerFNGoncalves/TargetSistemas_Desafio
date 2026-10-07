namespace TargetSistemas_Desafio.Desafio01
{
    public class Comissao
    {
        public string Vendedor { get; }
        public decimal TotalVendido { get; }
        public decimal ValorComissao { get; }

        public Comissao(string vendedor, decimal totalVendido, decimal valorComissao)
        {
            Vendedor = vendedor;
            TotalVendido = totalVendido;
            ValorComissao = valorComissao;
        }

    }
}