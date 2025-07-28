using Core.Entities;
using Core.Services;
using Xunit;

namespace Core.Tests
{
    public class CalculoSeguroServiceTests
    {
        private readonly CalculoSeguroService _calculoSeguroService;

        public CalculoSeguroServiceTests()
        {
            _calculoSeguroService = new CalculoSeguroService();
        }

        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaExemploDocumento()
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                Valor = 10000m,
                MarcaModelo = "Teste"
            };

            var resultado = _calculoSeguroService.Calcular(veiculo);

            Assert.Equal(2.5m, resultado.TaxaRisco); 
            Assert.Equal(250m, resultado.PremioRisco); 
            Assert.Equal(257.50m, resultado.PremioPuro); 
            Assert.Equal(12.875m, resultado.PremioComercial); 
            Assert.Equal(270.375m, resultado.ValorSeguro); 
        }

        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaValorDiferente()
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                Valor = 20000m,
                MarcaModelo = "Teste"
            };

            var resultado = _calculoSeguroService.Calcular(veiculo);

            Assert.Equal(2.5m, resultado.TaxaRisco); 
            Assert.Equal(500m, resultado.PremioRisco); 
            Assert.Equal(515m, resultado.PremioPuro); 
            Assert.Equal(25.75m, resultado.PremioComercial); 
            Assert.Equal(540.75m, resultado.ValorSeguro); 
        }

        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaValorMinimo()
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                Valor = 1000m,
                MarcaModelo = "Teste"
            };

            var resultado = _calculoSeguroService.Calcular(veiculo);

            Assert.Equal(2.5m, resultado.TaxaRisco);
            Assert.Equal(25m, resultado.PremioRisco);
            Assert.Equal(25.75m, resultado.PremioPuro);
            Assert.Equal(1.2875m, resultado.PremioComercial);
            Assert.Equal(27.0375m, resultado.ValorSeguro);
        }

        [Theory]
        [InlineData(5000, 125, 128.75, 6.4375, 135.1875)]
        [InlineData(15000, 375, 386.25, 19.3125, 405.5625)]
        [InlineData(30000, 750, 772.5, 38.625, 811.125)]
        public void Calcular_DeveRetornarValoresCorretos_ParaDiversosValores(
            decimal valorVeiculo,
            decimal premioRiscoEsperado,
            decimal premioPuroEsperado,
            decimal premioComercialEsperado,
            decimal valorSeguroEsperado)
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                Valor = valorVeiculo,
                MarcaModelo = "Teste"
            };

            var resultado = _calculoSeguroService.Calcular(veiculo);

            Assert.Equal(2.5m, resultado.TaxaRisco);
            Assert.Equal(premioRiscoEsperado, resultado.PremioRisco);
            Assert.Equal(premioPuroEsperado, resultado.PremioPuro);
            Assert.Equal(premioComercialEsperado, resultado.PremioComercial);
            Assert.Equal(valorSeguroEsperado, resultado.ValorSeguro);
        }
    }
}

