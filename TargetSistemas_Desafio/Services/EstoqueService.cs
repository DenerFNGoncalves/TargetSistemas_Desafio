namespace TargetSistemas_Desafio.Desafio02
{
    public class EstoqueService
    {
        public List<Produto>? Produtos { get; private set; }

        public List<MovimentacaoEstoque> Movimentacoes { get; private set; } = [];

        public EstoqueService(List<Produto>? produtos)
        {
            inicializarProdutos(produtos);
        }

        private void inicializarProdutos(List<Produto>? produtos)
        {
            if (produtos == null || produtos.Count == 0)
            { this.Produtos = []; }
            else
            {
                Produtos = produtos
                .GroupBy(produto => produto.CodigoProduto)
                .Select(grupo =>
                {
                    var qtdeTotal = grupo.Sum(item => item.Estoque);
                    if (qtdeTotal < 0) { qtdeTotal = 0; }
                    var desc = grupo.First().DescricaoProduto;
                    return new Produto(grupo.Key, desc, qtdeTotal);
                })
                .ToList();
            }


        }

        public Produto? ObterProduto(int codigoProduto)
        {
            return Produtos?.Find(produto => produto.CodigoProduto == codigoProduto);
        }

        public Produto? MovimentarEstoque(int codigo, TipoMovimentacao movimentacao, int quantidade)
        {
            var produto = ObterProduto(codigo);
            if (produto == null)
            {
                throw new Exception("Produto Inválido!");
            }

            if (movimentacao == TipoMovimentacao.Entrada)
            {
                produto.Estoque += quantidade;
            }
            else
            {
                if (produto.Estoque < quantidade)
                {
                    throw new InvalidOperationException("Quantidade de Baixa além da existente!");
                }

                produto.Estoque -= quantidade;
            }

            Movimentacoes.Add(new MovimentacaoEstoque
            {
                Id = Guid.NewGuid(),
                CodigoProduto = produto.CodigoProduto,
                Quantidade = quantidade,
                Tipo = movimentacao,
                Data = DateTime.Now,
            });

            return produto;
        }
    }
}