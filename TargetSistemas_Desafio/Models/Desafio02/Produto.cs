namespace TargetSistemas_Desafio.Desafio02
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int Estoque { get; set; }

        public Produto(int codigoProduto, string descricaoProduto, int estoque)
        {
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            Estoque = estoque;
        }
    }
}