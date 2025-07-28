using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class CalculoSeguroService : ICalculoSeguroService
    {
        private const decimal MARGEM_SEGURANCA = 0.03m; 
        private const decimal LUCRO = 0.05m;

        public CalculoSeguroResult Calcular(Veiculo veiculo)
        {
            var taxaRisco = (veiculo.Valor * 5) / (2 * veiculo.Valor);
            var premioRisco = (taxaRisco / 100) * veiculo.Valor;
            var premioPuro = premioRisco * (1 + MARGEM_SEGURANCA);
            var premioComercial = LUCRO * premioPuro;
            var valorSeguro = premioPuro + premioComercial;

            return new CalculoSeguroResult
            {
                TaxaRisco = taxaRisco,
                PremioRisco = premioRisco,
                PremioPuro = premioPuro,
                PremioComercial = premioComercial,
                ValorSeguro = valorSeguro
            };
        }
    }

    public class CalculoSeguroResult
    {
        public decimal TaxaRisco { get; set; }
        public decimal PremioRisco { get; set; }
        public decimal PremioPuro { get; set; }
        public decimal PremioComercial { get; set; }
        public decimal ValorSeguro { get; set; }
    }
}

