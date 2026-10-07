namespace TargetSistemas_Desafio.Desafio01
{
    public class ComissaoVendedorService
    {
        public List<Comissao> getListaComissao(List<Venda> vendas)
        {
            var vendasPorVendedor = vendas.GroupBy((venda) => venda.Vendedor);
            var comissoes = vendasPorVendedor.Select((group) =>
            {
                var totalVendido = group.Sum((item) => item.Valor);
                var valorComissao = CalculeComissao(totalVendido);

                return new Comissao(group.Key, totalVendido, valorComissao);
            }).ToList();

            return comissoes;
        }

        public decimal CalculeComissao(decimal valor)
        {
            if (valor < 100) { return 0m; }

            var percentual = valor < 500 ? 0.01m : 0.05m;
            return valor * percentual;
        }
    }
}