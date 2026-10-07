namespace TargetSistemas_Desafio.Desafio01
{

    public class DadosDeVendas
    {
        public List<Venda> Vendas { get; set; }

        public DadosDeVendas(List<Venda> vendas)
        {
            Vendas = vendas;
        }

    }

    public class Venda
    {
        public string Vendedor { get; set; }
        public decimal Valor { get; set; }

        public Venda(string vendedor, decimal valor)
        {
            Vendedor = vendedor;
            Valor = valor;
        }
    }
}