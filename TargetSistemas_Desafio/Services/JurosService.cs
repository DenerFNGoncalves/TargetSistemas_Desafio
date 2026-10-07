namespace TargetSistemas_Desafio.Desafio03
{
    public class JurosService
    {
        private const decimal TaxaDiaria = 0.025m;

        public static decimal Calcular(DateTime diaAtual, DateTime dataVencimento, decimal valor)
        {
            if (valor < 0) throw new ArgumentException("O valor não pode ser negativo.");

            if (diaAtual <= dataVencimento) return 0;

            var diasEmAtraso = (diaAtual.Date - dataVencimento.Date).Days;

            return valor * TaxaDiaria * diasEmAtraso;
        }
    }
}